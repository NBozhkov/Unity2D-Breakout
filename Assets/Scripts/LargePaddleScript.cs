using System.Runtime.CompilerServices;
using UnityEngine;

public class LargePaddleScript : MonoBehaviour
{
    [SerializeField] private GameObject paddle;
    [SerializeField] private float enlargeFactor = 2;

    private void Start()
    {

    }


    private float largePaddleTimer = 0;
    private void Update()
    {

        if (largePaddleTimer > 0)
        {
            largePaddleTimer -= Time.deltaTime;
        }
        else
        {
            ResetPaddle();
            this.enabled = false;
        }
    }

    public void AddToTimer(float addDuration)
    {
        largePaddleTimer += addDuration;

        if (this.enabled == false)
        {
            EnlargePaddle();
        }
    }



    private void EnlargePaddle()
    {
        paddle.transform.localScale *= enlargeFactor;
    }

    private void ResetPaddle()
    {
        paddle.transform.localScale = paddle.GetComponent<PaddleScript>().defaultPaddleScale;
    }


}
