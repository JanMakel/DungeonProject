using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{



    public float speed = 10f;

    private Rigidbody2D _rigidbody;
    private bool walking = false;

    public static bool playerCreated;


    

    

    public string netxUuid;


   
    void Start()
    {
        PlayerPrefs.DeleteAll();
       _rigidbody = GetComponent<Rigidbody2D>();
      playerCreated = true;
    }

    
    void Update()
    {
        this.walking = false;

        float horziontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");
        Vector2 inputVector = Vector2.zero;

       
        if(Mathf.Abs(horziontalInput) > 0.2f || Mathf.Abs(verticalInput) > 0.2f)
        {
            inputVector = new Vector2(horziontalInput, verticalInput).normalized;
            this.walking = true;
        }
        _rigidbody.velocity = inputVector * speed;
        
       
        
        
    }


    private void LateUpdate()
    {
        if (!walking)
        {
            _rigidbody.velocity = Vector2.zero;
        }
    }



}
