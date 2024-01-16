using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackScript : MonoBehaviour
{

    


  

   

    private void Start()
    {
        
        
    }
    public void Attack(GameObject victim)
    {

        Debug.Log($"{gameObject.name} ataca a {victim.name}");
       
    }

    
}
