using System.Collections;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
using UnityEngine;

public class PaddleScript : MonoBehaviour
{
    [SerializeField] private BoxCollider2D paddleCollider;
    [SerializeField] [Range(5, 50)] private float paddleSpeed;

    private float xAxisBorderSize;
    private void Start()
    {
        xAxisBorderSize = Camera.main.orthographicSize * Camera.main.aspect;

    }

    private void Update()
    {



        if (Input.GetKey(KeyCode.LeftArrow))
        {
            if( paddleCollider.bounds.min.x - paddleSpeed*Time.deltaTime  >  -xAxisBorderSize )
                transform.position = new Vector2(transform.position.x - paddleSpeed*Time.deltaTime, transform.position.y);

            else
                transform.position = new Vector2(-xAxisBorderSize + paddleCollider.bounds.extents.x, transform.position.y);

        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            if ( paddleCollider.bounds.max.x + paddleSpeed*Time.deltaTime  <  xAxisBorderSize )
                transform.position = new Vector2(transform.position.x + paddleSpeed*Time.deltaTime, transform.position.y);

            else
                transform.position = new Vector2(xAxisBorderSize - paddleCollider.bounds.extents.x, transform.position.y);
        }
    }
}
