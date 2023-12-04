using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LogicScript : MonoBehaviour
{
    public float heartNum;

    public GameObject heart5, heart4, heart3, heart2, heart1;

    void Start()
    {

    }


    void Update()
    {

    }


    public float LostHeart()
    {
        heartNum--;

        RemoveHeart();

        return heartNum;
    }

    private void RemoveHeart()
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
        SceneManager.LoadScene("ActionScene");
    }

    public void Quit()
    {
        Application.Quit();
    }

}
