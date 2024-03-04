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
    [SerializeField] private GameObject[] enemy;

    [SerializeField] private Transform playerStation;
    [SerializeField] private Transform enemyStation;

    public BattleHUD playerHUD;
    public BattleHUD enemyHUD;
    public TextMeshProUGUI battleText;

    public Unit playerUnit;
    private Unit enemyUnit;


    private bool inDefense = false;
    private int dodged;
    private int crit;
    private bool criticalHit = false;
    private int playerSpeed = 0;
    private int enemySpeed = 0;
    private string playerCurrentHpKey = "PlayerHP";
    private string playerMaxHpkey = "PlayerMaxHP";

   [SerializeField]private ParticleSystem[] playerParticleSystem;
   [SerializeField]private ParticleSystem enemyParticleSystem;


    private Animator playerAnimator;

    public ReturnFromBattle battleReturn;

  

    
    private void Start()
    {

        state = BattleState.START;

        StartCoroutine(SetupBattle());
    }

    
    private IEnumerator SetupBattle()
    {
        GameObject playerGameObject = Instantiate(player, playerStation);
        playerUnit = playerGameObject.GetComponent<Unit>();
        playerAnimator = playerGameObject.GetComponent<Animator>();

        battleReturn = playerGameObject.GetComponent<ReturnFromBattle>();
      

        GameObject enemyGameObject = Instantiate(enemy[PlayerPrefs.GetInt("EnemySelected", -1)], enemyStation);
        enemyUnit = enemyGameObject.GetComponent<Unit>();
        if(!PlayerPrefs.HasKey(playerMaxHpkey))
        {
            playerUnit.unitCurrentHp = playerUnit.unitMaxHp;
            PlayerPrefs.SetInt(playerMaxHpkey, playerUnit.unitMaxHp);
            PlayerPrefs.Save();
        }
        else
        {
            playerUnit.unitMaxHp = PlayerPrefs.GetInt(playerMaxHpkey);
        }
        if(PlayerPrefs.HasKey(playerCurrentHpKey))
        {
            playerUnit.unitCurrentHp = PlayerPrefs.GetInt(playerCurrentHpKey);
        }
        else
        {
            playerUnit.unitCurrentHp = playerUnit.unitMaxHp;
            PlayerPrefs.SetInt(playerCurrentHpKey, playerUnit.unitCurrentHp);
            PlayerPrefs.Save();
        }
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
        
        playerAnimator.SetTrigger("Attack");
        
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
                enemyParticleSystem.Play();
                MusicManager.Instance.PlaySoundEffect(0);
            }
            else
            {
                battleText.text = "It hits!";
                enemyParticleSystem.Play();
                MusicManager.Instance.PlaySoundEffect(0);
            }

            if (criticalHit)
            {
                playerUnit.unitDamage = playerUnit.unitDamage / 2;
                criticalHit = false;
            }

            yield return new WaitForSeconds(2f);

            if (isDead)
            {
                state = BattleState.WIN;
                battleText.text = "You won!!";
                MusicManager.Instance.backgroundMusicSource.Stop();
                MusicManager.Instance.PlaySoundEffect(3);
                yield return new WaitForSeconds(3f);
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

    
    IEnumerator PlayerHeal()
    {
        if (InventoryManager.Instance != null && InventoryManager.Instance.HasItem(InteractableObject.InteractableType.Potion))
        {
            if(playerUnit.unitCurrentHp < playerUnit.unitMaxHp)
            {
                battleText.text = "Healing";
                playerParticleSystem[1].Play();
                MusicManager.Instance.PlaySoundEffect(1);
                InventoryManager.Instance.RemoveItem(InteractableObject.InteractableType.Potion, 1);
                int healAmount = Mathf.Min(100, playerUnit.unitMaxHp - playerUnit.unitCurrentHp);
                playerUnit.unitCurrentHp += healAmount;
                playerHUD.SetHp(playerUnit.unitCurrentHp);
                yield return new WaitForSeconds(2f);
                WhoIsTurn();
            }
            else
            {
                battleText.text = "You have max Hp";
                yield return new WaitForSeconds(2f);
                battleText.text = "What will you do?";
            }
           
        }
        else
        {
            battleText.text = "You don't have potions";
            yield return new WaitForSeconds(2f);
            battleText.text = "What will you do?";
        }
        yield return new WaitForSeconds(1f);
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
                enemyUnit.unitDamage = enemyUnit.unitDamage * 2;
                criticalHit = true;
            }


           

            bool isDead = playerUnit.TakeDamage(enemyUnit.unitDamage);

            playerHUD.SetHp(playerUnit.unitCurrentHp);

            if (criticalHit)
            {
                battleText.text = "A CRITCAL HIT";
                playerParticleSystem[0].Play();
                MusicManager.Instance.PlaySoundEffect(0);
                enemyUnit.unitDamage = enemyUnit.unitDamage / 2;
                criticalHit = false;
            }
            else
            {
                battleText.text = "That's going to hurt";
                playerParticleSystem[0].Play();
                MusicManager.Instance.PlaySoundEffect(0);
            }


           
            yield return new WaitForSeconds(2f);

            if (isDead)
            {
                state = BattleState.LOST;
                battleText.text = "You lost...";
                MusicManager.Instance.backgroundMusicSource.Stop();
                MusicManager.Instance.PlaySoundEffect(2);
                yield return new WaitForSeconds(4f);
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
            PlayerPrefs.SetInt(playerCurrentHpKey, playerUnit.unitCurrentHp);
            PlayerPrefs.Save();
            Debug.Log("Save" + playerUnit.unitCurrentHp);
            battleReturn.Win();
        }
        else if (state == BattleState.LOST)
        {
            battleReturn.Lose();
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

    public void onObjectButton()
    {
        if(state != BattleState.PLAYERTURN)
        {
            return;
        }

        StartCoroutine(PlayerHeal());
    }
}