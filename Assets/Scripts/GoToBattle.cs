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
    

    public int GetEnemyInt()
    {
        return (int)enemyType;
    }

   
    public void ResetIsBattle()
    {
        isBattle = false;
    }
    

}
