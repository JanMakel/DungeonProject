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

    //public string uuid;

    public int enemyNum;

    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && !isBattle)
        {
            GetEnemy();
            EnemySelected();
            
            PlayerPrefs.SetInt("EnemySelected", enemyNum);
           
            isBattle = true;

            SceneManager.LoadScene(battleScene, LoadSceneMode.Additive);
            
            Destroy(gameObject);
            ResetIsBattle();

        }
    }


    public EnemyType GetEnemy()
    {
        return enemyType;
    }

    public int EnemySelected()
    {
        if (enemyType == EnemyType.LongSword)
        {
            return enemyNum = 0;
        }
        if(enemyType == EnemyType.Shield)
        {
            return enemyNum = 1;
        }
        if(enemyType == EnemyType.Shadow)
        {
            return enemyNum = 2;
        }
        if(enemyType == EnemyType.Spear)
        {
            return enemyNum = 3;
        }
        if(enemyType == EnemyType.Archer)
        {
            return enemyNum = 4;
        }
        if(enemyType == EnemyType.DarkKnight)
        {
            return enemyNum = 5;
        }

        return enemyNum;

    }
    public void ResetIsBattle()
    {
        isBattle = false;
    }
    

}
