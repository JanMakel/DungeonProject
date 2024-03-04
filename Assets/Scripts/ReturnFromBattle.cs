using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class ReturnFromBattle : MonoBehaviour
{

    

    private string battle_Scene = "Battle_Scene";

    private string gameOver = "GameOver";


   /// <summary>
   /// This funcction returns you from the battle if you win
   /// </summary>
    public void Win()
    {
        SceneManager.UnloadScene(battle_Scene);
        MusicManager.Instance.PlayNextBackgroundMusic();
    }
/// <summary>
/// This Function sends you to Game Over Scene if you lose
/// </summary>
    public void Lose()
    {
        SceneManager.UnloadScene(battle_Scene);
        SceneManager.LoadScene(gameOver);
    }
}
