using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickSpawnScript : MonoBehaviour
{
    public GameObject brick;
    public float xDist, yDist, rowNum, colNum, yStart;

    void Start()
    {
        float xStart = - (colNum - 1) * xDist / 2;

        for(int i = 0; i < colNum; i++)
        {

            for(int j = 0; j < rowNum; j++)
            {
                GameObject brickCopy = GameObject.Instantiate(brick);

                brickCopy.GetComponent<BrickScript>().SetStage(j + 1);

                brickCopy.transform.position = new Vector2(xDist * i + xStart, yDist * j + yStart);
            }

        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
