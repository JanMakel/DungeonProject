using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{



    public float speed = 10f;
    void Start()
    {
        
    }

    
    void Update()
    {
        if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) > 0.2f)
        {
            Vector3 tranlation = new Vector3(Input.GetAxisRaw("Horizontal") * speed * Time.deltaTime, 0, 0);
            this.transform.Translate(tranlation);
        }

        if(Mathf.Abs(Input.GetAxisRaw("Vertical")) > 0.2f)
        {
            Vector3 translation = new Vector3(Input.GetAxisRaw("Vertical") * speed * Time.deltaTime, 0, 0);
            this.transform.Translate(translation);
        }
    }
}
