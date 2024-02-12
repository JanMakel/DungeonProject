using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{



    public float speed = 10f;

    private Rigidbody2D _rigidbody;
    private bool walking = false;

    
    void Start()
    {
       _rigidbody = GetComponent<Rigidbody2D>();
    }

    
    void Update()
    {
        this.walking = false;

        float horziontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");
        Vector2 inputVector = Vector2.zero;

        if (Mathf.Abs(horziontalInput) > 0.2f)
        {
            //Vector3 tranlation = new Vector3(Input.GetAxisRaw("Horizontal") * speed * Time.deltaTime, 0, 0);
            //this.transform.Translate(tranlation);
            //_rigidbody.velocity = new Vector2(horziontalInput, _rigidbody.velocity.y);

            //this.walking = true;
        }
       

        if(Mathf.Abs(verticalInput) > 0.2f)
        {
            //Vector3 translation = new Vector3(0, Input.GetAxisRaw("Vertical") * speed * Time.deltaTime, 0);
            //this.transform.Translate(translation);
            //_rigidbody.velocity = new Vector2(_rigidbody.velocity.x,verticalInput);
            
            //this.walking = true;
        }
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
