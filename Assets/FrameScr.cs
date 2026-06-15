using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class FrameScr : MonoBehaviour
{
    public EdgeCollider2D frame;

    void Start()
    {
        Camera cam = Camera.main;
        float h = cam.orthographicSize;
        float w = h * cam.aspect;

        Vector2[] tempPoints = frame.points;
        tempPoints[0] = new Vector2(- w,   h);
        tempPoints[1] = new Vector2(- w, - h);
        tempPoints[2] = new Vector2(  w, - h);
        tempPoints[3] = new Vector2(  w,   h);
        tempPoints[4] = new Vector2(- w,   h);
        frame.points = tempPoints;
    }
}
