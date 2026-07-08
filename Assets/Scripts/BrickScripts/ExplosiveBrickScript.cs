using UnityEngine;

public class ExplosiveBrickScript : MonoBehaviour
{

    [SerializeField] private float destructionRadius = 1;


    private void Start()
    {

    }

    private void Update()
    {
        
    }


    private void DestroySurroundings()
    {
        Collider2D[] collidersInRadius = Physics2D.OverlapCircleAll(transform.position, destructionRadius);

        foreach (Collider2D collider in collidersInRadius)
        {
            if (collider.gameObject.CompareTag("Brick"))
            {
                Destroy(collider.gameObject);
            }
        }

    }

    private void OnDestroy()
    {
        DestroySurroundings();
    }
}
