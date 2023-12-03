using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleScript : MonoBehaviour
{

    public float paddleSpeed, movementRange;

    void Start()
    {
        
    }

    void Update()
    {
        if(Input.GetKey(KeyCode.LeftArrow) && transform.position.x > -movementRange)
        {
            transform.position = new Vector2(transform.position.x - paddleSpeed * Time.deltaTime, transform.position.y);
        }
        if (Input.GetKey(KeyCode.RightArrow) && transform.position.x < movementRange)
        {
            transform.position = new Vector2(transform.position.x + paddleSpeed * Time.deltaTime, transform.position.y);
        }
    }
}
