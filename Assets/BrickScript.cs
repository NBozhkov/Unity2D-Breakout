using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickScript : MonoBehaviour
{
    [SerializeField] private SpriteRenderer brickSprite;
    [SerializeField] private Color blue, green, yellow, orange, red, purple;

    private float hitNeed;

    private void Start()
    {
        brickSprite = GetComponent<SpriteRenderer>();
    }

    private void Update()
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

                GameObject.FindGameObjectWithTag("SpawnBricks").GetComponent<BrickSpawnScript>()  .SubtractFromBricks();

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
