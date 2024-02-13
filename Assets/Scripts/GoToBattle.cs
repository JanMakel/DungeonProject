using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToBattle : MonoBehaviour
{
    public string battleScene;
    public static bool isBattle = false;

    public string uuid;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            FindObjectOfType<PlayerController>().netxUuid = uuid;
            isBattle = true;
            SceneManager.LoadScene(battleScene);
        }
    }
}
