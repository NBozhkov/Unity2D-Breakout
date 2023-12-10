using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.AI;
using UnityEngine.UI;

public class BallScript : MonoBehaviour
{
    public PaddleScript paddleScr;
    public LogicScript logic;

    public Rigidbody2D ballBody;
    public float minSpeed, maxSpeed, changeDirStrenght, deadZone;
    public int chanceForSpeedChange;
    private float currentSpeed;

    public float defaultYPos;
    private float timer;
    private bool waiting = true;
    public float waitTime;

    public GameObject gameOverScreen;
    public Text gameOverText;


    void Start()
    {
        paddleScr = GameObject.FindGameObjectWithTag("Paddle").GetComponent<PaddleScript>();
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        ballBody = GetComponent<Rigidbody2D>();

        transform.position = new Vector2(0, defaultYPos);
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

            timer = 0;

            currentSpeed = minSpeed;
            ballBody.velocity = new Vector2(UnityEngine.Random.Range(-1f, 1f), UnityEngine.Random.Range(0.5f, 1f)).normalized * currentSpeed;
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        RandSpeedChange();

        if (collision.gameObject.name == "Paddle")
        {
            PaddleAngleCalc();
        }

        else if (collision.gameObject.name == "Frame" && transform.position.y < paddleScr.transform.position.y)
        {
            if (logic.LostHeart() == 0)
            {
                GameEnded("Game Over!");
            }
            else
            {
                ResetBall();
            }

        }
    }

    public void GameEnded(string gameOverMessage)
    {
        gameOverText.text = gameOverMessage;
        gameOverScreen.SetActive(true);

        ballBody.velocity = new Vector2(0, 0);
        paddleScr.paddleSpeed = 0;
    }
    
    private void ResetBall()
    {
        waiting = true;
        ballBody.velocity = new Vector2(0, 0);
        paddleScr.transform.position = new Vector2(0, paddleScr.transform.position.y);
        transform.position = new Vector2(0, defaultYPos);
    }

    private void RandSpeedChange()
    {
        if (UnityEngine.Random.Range(0, chanceForSpeedChange) == 0)
        {
            currentSpeed = UnityEngine.Random.Range(minSpeed, maxSpeed);
            ballBody.velocity = ballBody.velocity.normalized * currentSpeed;
        }
    }

    private void PaddleAngleCalc()
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
