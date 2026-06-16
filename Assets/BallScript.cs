using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.AI;
using UnityEngine.UI;

public class BallScript : MonoBehaviour
{
    private PaddleScript paddleScr;

    [SerializeField] private Rigidbody2D ballBody;
    [SerializeField] private float minSpeed, maxSpeed, changeDirStrenght, deadZone;
    [SerializeField] private int chanceForSpeedChange;
    private float currentSpeed;

    [SerializeField] private float defaultYPos;
    [SerializeField] private float waitTime;
    private float timer;
    private bool waiting = true;

    [SerializeField] private GameObject gameOverScreen;
    [SerializeField] private Text gameOverText;


    private void Start()
    {
        paddleScr = GameObject.Find("Paddle").GetComponent<PaddleScript>();

        transform.position = new Vector2(0, defaultYPos);
    }

    private void Update()
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
            ballBody.linearVelocity = new Vector2(UnityEngine.Random.Range(-1f, 1f), UnityEngine.Random.Range(0.5f, 1f)).normalized * currentSpeed;
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
            if ( GameObject.Find("Logic").GetComponent<LogicScript>() //gets Logic
                .RemoveHeart() == 0 )
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

        ballBody.linearVelocity = new Vector2(0, 0);
        paddleScr.enabled = false;
    }
    
    private void ResetBall()
    {
        waiting = true;
        ballBody.linearVelocity = new Vector2(0, 0);
        paddleScr.transform.position = new Vector2(0, paddleScr.transform.position.y);
        transform.position = new Vector2(0, defaultYPos);
    }

    private void RandSpeedChange()
    {
        if (UnityEngine.Random.Range(0, chanceForSpeedChange) == 0)
        {
            currentSpeed = UnityEngine.Random.Range(minSpeed, maxSpeed);
            ballBody.linearVelocity = ballBody.linearVelocity.normalized * currentSpeed;
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

        ballBody.linearVelocity = new Vector2(distOffCenter, yVelocity).normalized * currentSpeed;

    }

}
