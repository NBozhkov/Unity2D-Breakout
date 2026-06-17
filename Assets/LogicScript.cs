using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LogicScript : MonoBehaviour
{
    [SerializeField] private int heartNum = 5;
    private const int maxHeartNum = 5;

    [SerializeField] private GameObject[] hearts;

    private void Start()
    {
        if (heartNum > maxHeartNum) heartNum = maxHeartNum;
        else if (heartNum <= 0) heartNum = 1;

        for (int i = heartNum; i < maxHeartNum; i++)
            hearts[i].SetActive(false);        
    }


    private void Update()
    {

    }


    public float RemoveHeart()
    {
        heartNum--;
        hearts[heartNum].SetActive(false);

        return heartNum;
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
