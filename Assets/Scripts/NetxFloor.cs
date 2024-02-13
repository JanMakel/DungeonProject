using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class NetxFloor : MonoBehaviour
{
    public string netxFloor;

    public string uuid;
    private void OnTriggerEnter2D(Collider2D collision)
    {
            if(collision.gameObject.tag == "player")
        {
            FindObjectOfType<PlayerController>().netxUuid = uuid;
            SceneManager.LoadScene(netxFloor);
        }
    }
}