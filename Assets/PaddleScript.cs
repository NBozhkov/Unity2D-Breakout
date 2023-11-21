using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleScript : MonoBehaviour
{

    public Rigidbody2D paddleBody;
    public float keyPressDrag;


    void Start()
    {
        paddleBody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            paddleBody.velocity = new Vector3(-keyPressDrag, 0, 0);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            paddleBody.velocity = new Vector3(keyPressDrag, 0, 0);
        }
        else
        {
            paddleBody.velocity = new Vector3(0, 0, 0);
        }

    }

}
