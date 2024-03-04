using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class Win : MonoBehaviour
{



    private string winScene = "Win";
    private string battle_Scene = "Battle_Scene";


    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        SceneManager.LoadScene(winScene);
    }

}