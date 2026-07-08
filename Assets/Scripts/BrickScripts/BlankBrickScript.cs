using System.Collections;
using UnityEngine;

public class BlankBrickScript : MonoBehaviour
{

    [SerializeField] private Sprite brickTransitionSprite;
    [SerializeField] private SpriteRenderer brickSpriteRenderer;
    [SerializeField] private BoxCollider2D brickCollider;
    [SerializeField] private float transitionTime = 1f;
    private void Start()
    {
        
    }

    private void Update()
    {

    }



    public IEnumerator ChangeState()
    {
        brickSpriteRenderer.color = Color.gray;
        yield return new WaitForSeconds(transitionTime);
        brickCollider.isTrigger = false;
        brickSpriteRenderer.sprite = brickTransitionSprite;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Ball")
        {
            StartCoroutine(ChangeState());
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Ball")
        {
            Destroy(gameObject);

            GameObject.Find("Logic").GetComponent<LogicScript>().SubtractFromBricks();
        }
    }

}
