using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LogicScript : MonoBehaviour
{
    [SerializeField] private int brickNum;
    [SerializeField] private int heartNum = 5;
    private const int maxHeartNum = 5;

    [SerializeField] private GameObject[] hearts;

    [SerializeField] private GameObject gameOverScreen;
    [SerializeField] private Text gameOverText;

    private BallScript ballScr;

    private void Start()
    {
        ballScr = GameObject.Find("Ball").GetComponent<BallScript>();



        if (heartNum > maxHeartNum) heartNum = maxHeartNum;
        else if (heartNum <= 0) heartNum = 1;

        for (int i = heartNum; i < maxHeartNum; i++)
            hearts[i].SetActive(false);        
    }


    private void Update()
    {

    }

    public void SubtractFromBricks()
    {
        brickNum--;

        if (brickNum <= 0)
        {
            GameEnded("You Won!");
        }
    }



    public void BallOut()
    {
        heartNum--;
        hearts[heartNum].SetActive(false);

        if (heartNum <= 0) GameEnded("Game Over!");

        else ballScr.ResetBall();
    }

    public void GameEnded(string gameOverMessage)
    {
        ballScr.StopMotion();

        gameOverText.text = gameOverMessage;
        gameOverScreen.SetActive(true);
    }


    public void NewGame()
    {
        SceneManager.LoadScene("ActionScene"); //it simultaneously unloads the copy
    }

    public void Quit()
    {
        Application.Quit();
    }

}
