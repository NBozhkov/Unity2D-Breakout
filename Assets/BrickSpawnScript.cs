using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BrickSpawnScript : MonoBehaviour
{
    public GameObject brick;
    public int rowNum, colNum;
    public float xDist, yDist, yStart;

    private int brickNum;

    public BallScript ballScr;


    void Start()
    {
        ballScr = GameObject.FindGameObjectWithTag("Ball").GetComponent<BallScript>();


        brickNum = rowNum * colNum;
        float xStart = - (colNum - 1) * xDist / 2;
        
        for(int i = 0; i < colNum; i++)
        {

            for(int j = 0; j < rowNum; j++)
            {
                GameObject brickCopy = GameObject.Instantiate(brick);

                brickCopy.GetComponent<BrickScript>().SetHits(j + 1);

                brickCopy.transform.position = new Vector2(xDist * i + xStart, yDist * j + yStart);
            }

        }

    }

    public void SubstractFromBricks()
    {
        brickNum--;
        
        if(brickNum <= 0)
        {
            ballScr.GameEnded("You Won!");
        }
    }
}
