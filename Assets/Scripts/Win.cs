using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class Win : MonoBehaviour
{



    private string winScene = "Win";
   

    /// <summary>
    /// This function Loads the win scene
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        SceneManager.LoadScene(winScene);
    }

}