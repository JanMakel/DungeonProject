using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class ReturnFromBattle : MonoBehaviour
{

    

    private string battle_Scene = "Battle_Scene";

    private string gameOver = "GameOver";


   
    public void Win()
    {
        SceneManager.UnloadScene(battle_Scene);
        MusicManager.Instance.PlayNextBackgroundMusic();
    }

    public void Lose()
    {
        SceneManager.UnloadScene(battle_Scene);
        SceneManager.LoadScene(gameOver);
    }
}
