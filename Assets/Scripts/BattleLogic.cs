using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BattleLogic : MonoBehaviour
{
    public static BattleLogic Instance; //TO DO: Acacbbar de completar config singleton
    [SerializeField]private GameObject player;
    [SerializeField]private GameObject enemy;
  
    [SerializeField] private GameObject attackPrefab;
    [SerializeField] private GameObject defensePrefab;
    [SerializeField] private GameObject objectPrefab;


    private GameObject currentAction;
    private GameObject attack;
    private GameObject defense;
    private GameObject objects;

    private AttackScript attackScript;

    private void Start()
    {
        
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            attackScript.Attack(enemy);
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            Debug.Log("Player Defense");
        }

        if (Input.GetKeyDown(KeyCode.O))
        {
            Debug.Log("Player Using Object");
        }
    }





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
