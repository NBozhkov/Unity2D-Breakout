using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LogicScript : MonoBehaviour
{
    [SerializeField] private float heartNum;

    [SerializeField] private GameObject heart5, heart4, heart3, heart2, heart1;

    private void Start()
    {

    }


    private void Update()
    {

    }


    public float RemoveHeart()
    {
        heartNum--;

        RemoveHeartOnScreen();

        return heartNum;
    }

    private void RemoveHeartOnScreen()
    {
        switch (heartNum)
        {
            case 4:
                heart5.SetActive(false);
                break;

            case 3:
                heart4.SetActive(false);
                break;

            case 2:
                heart3.SetActive(false);
                break;

            case 1:
                heart2.SetActive(false);
                break;

            case 0:
                heart1.SetActive(false);
                break;

        }
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
