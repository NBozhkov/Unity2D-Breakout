using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.AI;

public class BallScript : MonoBehaviour
{
    public PaddleScript paddleScr;

    public Rigidbody2D ballBody;
    public float speed, changeDirStrenght, deadZone;

    public GameObject gameOverScreen;

    void Start()
    {
        paddleScr = GameObject.FindGameObjectWithTag("Paddle").GetComponent<PaddleScript>();

        ballBody = GetComponent<Rigidbody2D>();

        ballBody.velocity = new Vector2(UnityEngine.Random.Range(-1f,1f), UnityEngine.Random.Range(0.5f, 1f)).normalized * speed;
    }

    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Paddle")
        {
            PaddleBounceAngle();
        }

        else if (collision.gameObject.name == "Frame" && transform.position.y < deadZone)
        {
            gameOverScreen.SetActive(true);
            ballBody.velocity = new Vector2(0, 0);
        }
    }

    private void PaddleBounceAngle()
    {
        float distOffCenter = transform.position.x - paddleScr.transform.position.x;
        float yVelocity;

        if (distOffCenter < 0f)
        {
            yVelocity = changeDirStrenght + distOffCenter;
        }
        else
        {
             yVelocity = changeDirStrenght - distOffCenter;
        }

        ballBody.velocity = new Vector2(distOffCenter, yVelocity).normalized * speed;

    }

}
