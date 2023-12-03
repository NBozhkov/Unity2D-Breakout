using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickScript : MonoBehaviour
{
    public SpriteRenderer brickSprite;
    public Color blue, green, yellow, orange, red, purple;

    private float hitNeed;
    void Start()
    {
        brickSprite = GetComponent<SpriteRenderer>();


    }

    void Update()
    {
        
    }

    public void SetStage(float stage)
    {
        hitNeed = stage;

        switch (hitNeed)
        {
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

            case 0:
                Destroy(gameObject);
                break;

            default:
                brickSprite.color = purple;
                break;

        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Ball")
        {
            hitNeed--;
            SetStage(hitNeed);
        }
    }

}
