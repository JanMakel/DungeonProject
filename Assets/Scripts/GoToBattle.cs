using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToBattle : MonoBehaviour
{
    public string battleScene;
    public static bool isBattle = false;
    
    public enum EnemyType { LongSword, Shield, Shadow, Spear, Archer, DarkKnight}

    public EnemyType enemyType;

    

    

    
    /// <summary>
    /// When Player Collides whith an enemy in the dungeon this function loads the battle and destroy the collider
    /// </summary>
    /// <param name="collision">Skeletons in Map</param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && !isBattle)
        {
            
            
            
            PlayerPrefs.SetInt("EnemySelected", GetEnemyInt());
           
            isBattle = true;

            SceneManager.LoadScene(battleScene, LoadSceneMode.Additive);
            MusicManager.Instance.PlayNextBackgroundMusic();
            
            Destroy(gameObject);
            ResetIsBattle();

        }
    }
    
    /// <summary>
    /// This functions Get the type of enemy has to be putted in the Battle Scene
    /// </summary>
    /// <returns>Enemy to battle</returns>
    public int GetEnemyInt()
    {
        return (int)enemyType;
    }

   /// <summary>
   /// This fuction is just to make sure once you are back to the map that you can battle again if you collide with an enemy
   /// </summary>
    public void ResetIsBattle()
    {
        isBattle = false;
    }
    

}
