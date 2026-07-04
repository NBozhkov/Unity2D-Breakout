using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Experimental.AI;

public class BallScript : MonoBehaviour
{
    private PaddleScript paddleScr;

    [SerializeField] private Rigidbody2D ballBody;
    [SerializeField] private float defaultSpeed = 10, speedChangeCap = 1, changeDirStrenght = 1;
    [SerializeField] [Range(0,90)] private float minVertAngle = 10;
    private float minVertAngleInRad;
    [SerializeField] [Range(0,100)] private int chanceForSpeedChange = 50;
    private float currentSpeed;
    private float defaultYPos;

    [SerializeField] private float waitTime = 2;


    private IEnumerator coroutine;


    private void Start()
    {
        defaultYPos = transform.position.y;
        paddleScr = GameObject.Find("Paddle").GetComponent<PaddleScript>();

        minVertAngleInRad = minVertAngle * Mathf.PI / 180f;



        StartCoroutine(StartGameWDelay());
    }

    private void Update()
    {

    }

    public IEnumerator StartGameWDelay()
    {

        yield return new WaitForSeconds(waitTime);

        ballBody.bodyType = RigidbodyType2D.Dynamic;
        RandSpeedChange();
        ballBody.linearVelocity = new Vector2(UnityEngine.Random.Range(-1f, 1f), UnityEngine.Random.Range(0.5f, 1f)).normalized * currentSpeed;
        
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(ballBody.bodyType == RigidbodyType2D.Dynamic)
        {

            if (collision.gameObject.name == "Frame" && transform.position.y < paddleScr.transform.position.y)
            {
                GameObject.Find("Logic").GetComponent<LogicScript>().BallOut();                
            }


            else
            {

                if (collision.gameObject.name == "Paddle")
                {
                    SetBallPaddleHitAngle();
                }

                RandSpeedChange();

                RestrictBallVelAngle();
            }

        }



    }
    


    private void RandSpeedChange()
    {
        if (UnityEngine.Random.Range(1, 100) <= chanceForSpeedChange)
        {
            currentSpeed = UnityEngine.Random.Range(defaultSpeed - speedChangeCap, defaultSpeed + speedChangeCap);
            ballBody.linearVelocity = ballBody.linearVelocity.normalized * currentSpeed;
        }
    }


    private Vector2 newDir;
    private void SetBallPaddleHitAngle()
    {
        newDir = new Vector2( (transform.position.x - paddleScr.transform.position.x) * changeDirStrenght, paddleScr.GetComponent<BoxCollider2D>().bounds.extents.x);

        ballBody.linearVelocity = newDir.normalized * currentSpeed;
    }

    private void RestrictBallVelAngle()
    {
        if (Math.Sign(ballBody.linearVelocityY) == 0) ballBody.linearVelocityY = 1;

        if (Math.Abs(ballBody.linearVelocity.normalized.y) < Mathf.Sin(minVertAngleInRad) )
        {
            ballBody.linearVelocity = new Vector2( Math.Sign(ballBody.linearVelocityX) * Mathf.Cos(minVertAngleInRad), Math.Sign(ballBody.linearVelocityY) * Mathf.Sin(minVertAngleInRad) ).normalized * currentSpeed;
        }
    }



    public void ResetBall()
    {
        ballBody.bodyType = RigidbodyType2D.Static;
        paddleScr.transform.position = new Vector2(0, paddleScr.transform.position.y);
        transform.position = new Vector2(0, defaultYPos);
    }

    public void StopMotion()
    {
        ballBody.bodyType = RigidbodyType2D.Static;
        paddleScr.enabled = false;
    }
}
