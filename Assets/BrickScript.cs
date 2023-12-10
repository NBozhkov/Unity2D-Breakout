using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickScript : MonoBehaviour
{
    public SpriteRenderer brickSprite;
    public Color blue, green, yellow, orange, red, purple;

    public BrickSpawnScript brickSpawnScr;

    private float hitNeed;

    void Start()
    {
        brickSprite = GetComponent<SpriteRenderer>();

        brickSpawnScr = GameObject.FindGameObjectWithTag("SpawnBricks").GetComponent<BrickSpawnScript>();
    }

    void Update()
    {
        
    }


    public void SetHits(float stage)
    {
        hitNeed = stage;

        SetStage();
    }

    private void SetStage()
    {
        switch (hitNeed)
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

                brickSpawnScr.SubstractFromBricks();

                break;

        }

    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Ball")
        {
            hitNeed--;
            SetStage();
        }
    }

}
