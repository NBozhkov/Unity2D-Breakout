using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickScript : MonoBehaviour
{
    [SerializeField] private SpriteRenderer brickSprite;
    [SerializeField] [Range(1,6)] private int toughness;
    [SerializeField] private Color blue, green, yellow, orange, red, purple;

    private const int maxToughness = 6;


    private void Start()
    {

    }
    private void Update()
    {
        
    }


    public void SetToughnessLevel(int toughnessLevel = -1)
    {
        if (toughnessLevel > maxToughness)
            toughness = maxToughness;
        else if (toughnessLevel <= 0)
            toughness = 1;
        else
            toughness = toughnessLevel;


        SetStage();
    }

    private void SetStage()
    {
        switch (toughness)
        {

            case 6:
                brickSprite.color = purple;
                break;

            case 5:
                brickSprite.color = red;
                break;

            case 4:
                brickSprite.color = orange;
                break;

            case 3:
                brickSprite.color = yellow;
                break;

            case 2:
                brickSprite.color = green;
                break;

            case 1:
                brickSprite.color = blue;
                break;

            default:
                Destroy(gameObject);

                GameObject.Find("Logic").GetComponent<LogicScript>().SubtractFromBricks();

                break;

        }

    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Ball")
        {
            toughness--;
            SetStage();
        }
    }

}
