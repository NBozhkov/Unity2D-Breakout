using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.AI;

public class BallScript : MonoBehaviour
{
    public PaddleScript paddleScr;

    public Rigidbody2D ballBody;
    public float minSpeed, maxSpeed, changeDirStrenght, deadZone;
    public int chanceForSpeedChange;
    private float currentSpeed;

    private float timer;
    private bool waiting = true;
    public float waitTime;

    public GameObject gameOverScreen;

    void Start()
    {
        paddleScr = GameObject.FindGameObjectWithTag("Paddle").GetComponent<PaddleScript>();

        ballBody = GetComponent<Rigidbody2D>();

    }

    void Update()
    {
        if(timer < waitTime && waiting)
        {
            timer += Time.deltaTime;
        }
        else if (waiting)
        {
            waiting = false;

            currentSpeed = minSpeed;
            ballBody.velocity = new Vector2(UnityEngine.Random.Range(-1f, 1f), UnityEngine.Random.Range(0.5f, 1f)).normalized * currentSpeed;
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(UnityEngine.Random.Range(0, chanceForSpeedChange) == 0)
        {
            currentSpeed = UnityEngine.Random.Range(minSpeed, maxSpeed);
            ballBody.velocity = ballBody.velocity.normalized * currentSpeed;
        }


        if (collision.gameObject.name == "Paddle")
        {
            BounceAngleCalculation();
        }

        else if (collision.gameObject.name == "Frame" && transform.position.y < deadZone)
        {
            gameOverScreen.SetActive(true);
            ballBody.velocity = new Vector2(0, 0);
            paddleScr.paddleSpeed = 0;
        }
    }

    private void BounceAngleCalculation()
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

        ballBody.velocity = new Vector2(distOffCenter, yVelocity).normalized * currentSpeed;

    }

}
