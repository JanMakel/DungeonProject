using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;



public enum BattleState { START, PLAYERTURN, ENEMYTURN, WIN, LOST }

public class BattleSystem : MonoBehaviour
{
    

    public BattleState state;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject enemy;

    [SerializeField] private Transform playerStation;
    [SerializeField] private Transform enemyStation;

    public BattleHUD playerHUD;
    public BattleHUD enemyHUD;
    public TextMeshProUGUI battleText;

    private Unit playerUnit;
    private Unit enemyUnit;


    private bool inDefense = false;
    private int dodged;
    private int crit;
    private bool criticalHit = false;
    private int playerSpeed = 0;
    private int enemySpeed = 0;

    private Animator animator;



    private void Start()
    {
        //animator = playerUnit.GetComponent<Animator>();
        state = BattleState.START;

        StartCoroutine(SetupBattle());
    }


    private IEnumerator SetupBattle()
    {
        GameObject playerGameObject = Instantiate(player, playerStation);
        playerUnit = playerGameObject.GetComponent<Unit>();

        GameObject enemyGameObject = Instantiate(enemy, enemyStation);
        enemyUnit = enemyGameObject.GetComponent<Unit>();

        playerUnit.unitCurrentHp = playerUnit.unitMaxHp;
        enemyUnit.unitCurrentHp = enemyUnit.unitMaxHp;

        playerSpeed = 0;
        enemySpeed = 0;

        playerHUD.SetHUD(playerUnit);
        enemyHUD.SetHUD(enemyUnit);

        battleText.text = "A wild  " + enemyUnit.unitName + "  approaches";

        yield return new WaitForSeconds(2f);

        WhoIsTurn();
    }

    IEnumerator PlayerAttack()
    {

        //animator.SetTrigger("Attack");

        dodged = Random.Range(0, 100);
        if(dodged <= enemyUnit.unitDodge) 
        {
            battleText.text = enemyUnit.unitName + " evades the attack!";

            yield return new WaitForSeconds(2f);

            battleText.text = "Now is " + enemyUnit.unitName + " turn";

            yield return new WaitForSeconds(2f);

            WhoIsTurn();

        }
        else
        {
            crit = Random.Range(0, 100);
            
            if(crit <= playerUnit.unitCrit)
            {
                playerUnit.unitDamage = playerUnit.unitDamage * 2;
                criticalHit = true;
            }




            bool isDead = enemyUnit.TakeDamage(playerUnit.unitDamage);

            enemyHUD.SetHp(enemyUnit.unitCurrentHp);


            if(criticalHit)
            {
                battleText.text = "A CRITCAL HIT";
            }
            else
            {
                battleText.text = "It hits!";
            }
           
            yield return new WaitForSeconds(2f);

            if (isDead)
            {
                state = BattleState.WIN;
                battleText.text = "You won!!";
                EndBattle();
            }
            else
            {              
                WhoIsTurn();
            }
        }
      
        
    }

    IEnumerator PlayerDefense()
    {
        inDefense = true;
        playerUnit.unitDefense = playerUnit.unitDefense * 2;
        battleText.text = "Defending!";
        yield return new WaitForSeconds(2f);

        
        WhoIsTurn();
    }


    private void WhoIsTurn()
    {
        playerSpeed = playerSpeed += playerUnit.unitVelocity;
        enemySpeed = enemySpeed += enemyUnit.unitVelocity;

        if(playerSpeed >= enemySpeed)
        {
            playerSpeed = 0;
            state = BattleState.PLAYERTURN;
            PlayerTurn();
            
        }
        else
        {
            enemySpeed = 0;
            state = BattleState.ENEMYTURN;
            StartCoroutine(EnemyTurn());

        }
    }

    private void PlayerTurn()
    {
        if (inDefense)
        {
            playerUnit.unitDefense = playerUnit.unitDefense / 2;
            inDefense = false;
        }
        if (criticalHit)
        {
            playerUnit.unitDamage = playerUnit.unitDamage / 2;
            criticalHit = false;
        }
        battleText.text = "What will you do?...";
    }
    IEnumerator EnemyTurn()
    {
        battleText.text = "Now is " + enemyUnit.unitName + " turn";

        yield return new WaitForSeconds(2f);

        dodged = Random.Range(0, 100);
        if (dodged <= playerUnit.unitDodge)
        {
            battleText.text = playerUnit.unitName + " evades the attack!";

            yield return new WaitForSeconds(2f);

           WhoIsTurn();
        }
        else
        {
            crit = Random.Range(0, 100);
            if (crit <= enemyUnit.unitCrit)
            {
                playerUnit.unitDamage = enemyUnit.unitDamage * 2;
                criticalHit = true;
            }


           

            bool isDead = playerUnit.TakeDamage(enemyUnit.unitDamage);

            playerHUD.SetHp(playerUnit.unitCurrentHp);

            if (criticalHit)
            {
                battleText.text = "A CRITCAL HIT";
            }
            else
            {
                battleText.text = "That's going to hurt"; ;
            }


            if (criticalHit)
            {
                enemyUnit.unitDamage = enemyUnit.unitDamage / 2;
                criticalHit = false;
            }
            yield return new WaitForSeconds(2f);

            if (isDead)
            {
                state = BattleState.LOST;
                battleText.text = "You lost...";
                EndBattle();
            }
            else
            {
                WhoIsTurn();
            }

            yield return new WaitForSeconds(2f);
        }
       
    }

    private void EndBattle()
    {
        if(state == BattleState.WIN)
        {
            //Funcion de regreso al mapa
        }
        else if (state == BattleState.LOST)
        {
            //Funcion de Game Over
        }
    }

    public void onAttackButton()
    {
        if(state != BattleState.PLAYERTURN)
        {
            return;
        }

        StartCoroutine(PlayerAttack());
    }

    public void onDefenseButton()
    {
        if(state != BattleState.PLAYERTURN)
        {
            return;
        }

        StartCoroutine(PlayerDefense());
    }

}