using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ReturnFromBattle : MonoBehaviour
{

 

    private string Battle_Scene = "Battle_Scene";
    
   
    public void Win()
    {
        Destroy(GameObject.FindWithTag("Battle1"));
        
        SceneManager.UnloadScene(Battle_Scene);
    }
}
