using UnityEngine;

public class ToughBrickScript : MonoBehaviour
{

    [SerializeField] private SpriteRenderer brickSprite;
    [SerializeField] private Sprite[] brickStageSprites;
    private int toughness;



    private void Start()
    {
        toughness = brickStageSprites.Length;

        brickSprite.sprite = brickStageSprites[toughness - 1];
    }


    private void Update()
    {
        
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Ball")
        {

            toughness--;

            if(toughness <= 0)
            {
                Destroy(gameObject);
            }
            else
            {
                brickSprite.sprite = brickStageSprites[toughness - 1];
            }

        }


    }

    private void OnDestroy()
    {
        GameObject.Find("Logic").GetComponent<LogicScript>().SubtractFromBricks();
    }

}
