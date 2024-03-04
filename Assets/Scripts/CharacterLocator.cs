using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterLocator : MonoBehaviour
{
    private PlayerController player;
    private CameraFollow camera;

    public string uuid;
    void Start()
    {
        player = FindObjectOfType<PlayerController>();
        camera = FindObjectOfType<CameraFollow>();

        



        player.transform.position = this.transform.position;
        camera.transform.position = new Vector3(transform.position.x, transform.position.y, camera.transform.position.z);
    }

    
}
