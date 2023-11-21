using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    public Rigidbody2D ballBody;
    public float speed;

    void Start()
    {
        ballBody = GetComponent<Rigidbody2D>();

        ballBody.velocity = new Vector3 (2, 2, 0);
    }

    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Paddle")
        {
            Debug.Log("collision with paddle");
        }
    }
}
