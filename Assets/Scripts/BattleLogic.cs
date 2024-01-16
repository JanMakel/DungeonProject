using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleLogic : MonoBehaviour
{
    public static BattleLogic Instance; //TODO: Acacbbar de completar config singleton
    private GameObject player;
    private GameObject enemy;
    private CharacterSO reciever;
    private CharacterSO attacker;
    [SerializeField] private GameObject attackPrefab;
    [SerializeField] private GameObject defensePrefab;
    [SerializeField] private GameObject objectPrefab;


    private GameObject currentAction;
    private GameObject attack;
    private GameObject defense;
    private GameObject objects;










    /*
    public void SelectAction(string action)
    {
        GameObject victim = player;
        if (reciever.enemy == true) 
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
    */

}
