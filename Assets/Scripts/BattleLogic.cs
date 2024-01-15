using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleLogic : MonoBehaviour
{
    private GameObject player;
    private GameObject enemy;

    [SerializeField] private GameObject attackPrefab;
    [SerializeField] private GameObject defensePrefab;
    [SerializeField] private GameObject objectPrefab;


    private GameObject currentAction;
    private GameObject attack;
    private GameObject defense;
    private GameObject objects;


    private void SelectAction(string action)
    {
        GameObject victim = player;
        if (tag == "player") 
        {
            victim = enemy;
        }
        if(action.CompareTo("Attack") == 0)
        {

            attack.GetComponent<AttackScript>().Attack(victim);
            Debug.Log("Attacking Enemy");
        }
        else if(action.CompareTo("Defense") == 0)
        {
            Debug.Log("Player Defending");
        }
        else
        {
            Debug.Log("Player using object");
        }
       
    }

}
