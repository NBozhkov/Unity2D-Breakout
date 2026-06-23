using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.AI;

public class BallScript : MonoBehaviour
{
    private PaddleScript paddleScr;

    [SerializeField] private Rigidbody2D ballBody;
    [SerializeField] private float defaultSpeed = 10, speedChangeCap = 1, changeDirStrenght = 1;
    [SerializeField] [Range(0,100)] private int chanceForSpeedChange = 50;
    private float currentSpeed;
    private float defaultYPos;

    [SerializeField] private float waitTime = 2;
    private float timer;
    private bool waiting = true;


    private void Start()
    {
        defaultYPos = transform.position.y;
        paddleScr = GameObject.Find("Paddle").GetComponent<PaddleScript>();

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

            RandSpeedChange();
            ballBody.linearVelocity = new Vector2( UnityEngine.Random.Range(-1f, 1f), UnityEngine.Random.Range(0.5f, 1f) ).normalized * currentSpeed;
        }

    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if( ! (ballBody.bodyType == RigidbodyType2D.Static) )
        {

            RandSpeedChange();

            if (collision.gameObject.name == "Paddle")
            {
                SetBallPaddleHitAngle();
            }

            else if (collision.gameObject.name == "Frame" && transform.position.y < paddleScr.transform.position.y)
            {
                GameObject.Find("Logic").GetComponent<LogicScript>().BallOut();
            }

        }
    }
    
    public void ResetBall()
    {
        waiting = true;
        ballBody.linearVelocity = new Vector2(0, 0);
        paddleScr.transform.position = new Vector2(0, paddleScr.transform.position.y);
        transform.position = new Vector2(0, defaultYPos);
    }

    public void StopMotion()
    {
        ballBody.bodyType = RigidbodyType2D.Static;
        paddleScr.enabled = false;
    }



    private void RandSpeedChange()
    {
        if (UnityEngine.Random.Range(1, 100) <= chanceForSpeedChange)
        {
            currentSpeed = UnityEngine.Random.Range(defaultSpeed - speedChangeCap, defaultSpeed + speedChangeCap);
            ballBody.linearVelocity = ballBody.linearVelocity.normalized * currentSpeed;
        }
    }


    private void SetBallPaddleHitAngle()
    {
        ballBody.linearVelocity = new Vector2
            ( (transform.position.x - paddleScr.transform.position.x) * changeDirStrenght ,
            paddleScr.GetComponent<BoxCollider2D>().bounds.extents.x )
                .normalized * currentSpeed;
    }

}
