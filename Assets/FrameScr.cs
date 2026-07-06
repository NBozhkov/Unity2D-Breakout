using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class FrameScr : MonoBehaviour
{
    [SerializeField] private EdgeCollider2D frame;
    [SerializeField] private BoxCollider2D outOfBoundsDetectorCollider;
    [SerializeField] private GameObject frameSpriteL;
    [SerializeField] private GameObject frameSpriteR;

    private void Start()
    {
        float h = Camera.main.orthographicSize;

        //Frame setup
        Vector2[] tempPoints = frame.points;
        tempPoints[0] = new Vector2( -h, -h - 1 );
        tempPoints[1] = new Vector2( -h,  h );
        tempPoints[2] = new Vector2(  h,  h );
        tempPoints[3] = new Vector2(  h, -h - 1 );
        frame.points = tempPoints;

        //OutOfBoundsDetector setup
        outOfBoundsDetectorCollider.size = new Vector2(2 * h, 1);
        outOfBoundsDetectorCollider.offset = new Vector2(0, - h - 1);

        //Left and Right Frame Border Sprites setup
        frameSpriteL.transform.localScale = new Vector3( (Camera.main.aspect - 1) * 2 * h , 2 * h + 1, 1);
        frameSpriteL.transform.position = new Vector3(-h * Camera.main.aspect, 0, frameSpriteL.transform.position.z);

        frameSpriteR.transform.localScale = frameSpriteL.transform.localScale;
        frameSpriteR.transform.position = new Vector3(h * Camera.main.aspect, 0, frameSpriteL.transform.position.z);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("detected");

        if (collision.gameObject.CompareTag("Ball"))
        {
            GameObject.Find("Logic").GetComponent<LogicScript>().BallOut();
        }
    }
}


