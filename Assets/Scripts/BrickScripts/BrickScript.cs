using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class BrickScript : MonoBehaviour
{
    private void Start()
    {

    }
    private void Update()
    {
        
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Ball")
        {

            Destroy(gameObject);

        }
    }

    private void OnDestroy()
    {

        GameObject.Find("Logic").GetComponent<LogicScript>().SubtractFromBricks();

    }


}
