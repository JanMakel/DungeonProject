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
    

    private Unit playerUnit;
    private Unit enemyUnit;

    private void Start()
    {
        state = BattleState.START;

        StartCoroutine(SetupBattle());
    }


    private IEnumerator SetupBattle()
    {
        GameObject playerGameObject = Instantiate(player, playerStation);
        playerUnit = playerGameObject.GetComponent<Unit>();

        GameObject enemyGameObject = Instantiate(enemy, enemyStation);
        enemyUnit = enemyGameObject.GetComponent<Unit>();

        playerHUD.SetHUD(playerUnit);
        enemyHUD.SetHUD(enemyUnit);

        yield return new WaitForSeconds(2f);

        state = BattleState.PLAYERTURN;
        
    }



    public void onAttackButton()
    {
        
    }

}