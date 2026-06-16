using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BrickSpawnScript : MonoBehaviour
{
    [SerializeField] private GameObject brick;
    [SerializeField] private int rowNum, colNum;
    [SerializeField] private float xDist, yDist, yStart;

    private int brickNum;

    private BallScript ballScr;


    private void Start()
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

    public void SubtractFromBricks()
    {
        brickNum--;
        
        if(brickNum <= 0)
        {
            ballScr.GameEnded("You Won!");
        }
    }
}
