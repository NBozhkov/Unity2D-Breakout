using System.Collections;
using UnityEngine;

public class SlowdownFieldScript : MonoBehaviour
{
    [SerializeField] private float slowdownStartY = -3;
    [SerializeField] [Range(0,1)] private float slowdownMagnitude = 0.5f;
    private float slowdownTimer = 0;

    [SerializeField] private SpriteRenderer slowdownFieldRenderer;
    [SerializeField] private BoxCollider2D slowdownFieldCollider;

    private BallScript ballScr;
    private Rigidbody2D ballBody;


    private void Start()
    {
        ballScr = GameObject.Find("Ball").GetComponent<BallScript>();
        ballBody = GameObject.Find("Ball").GetComponent<Rigidbody2D>();

        transform.position = new Vector2(0, - Camera.main.orthographicSize);
        transform.localScale = new Vector2(2 * Camera.main.orthographicSize, 2 * (Camera.main.orthographicSize + slowdownStartY) );


    }

    private void Update()
    {
        if(slowdownTimer > 0)
        {
            slowdownTimer -= Time.deltaTime;
        }
        else
        {
            DisableField();
        }




    }



    private void EnableField()
    {
        this.enabled = true;
        slowdownFieldRenderer.enabled = true;
        slowdownFieldCollider.enabled = true;

    }
    private void DisableField()
    {
        this.enabled = false;
        slowdownFieldRenderer.enabled = false;
        slowdownFieldCollider.enabled = false;

    }


    public void AddToTimer(float addDuration)
    {
        slowdownTimer += addDuration;

        if(this.enabled == false)
        {
            EnableField();
        }
    }




    private void StartSlowDown()
    {
        ballScr.baseSpeed = ballScr.GetDefaultBaseSpeed() * slowdownMagnitude;
        ballScr.speedChangeCap = ballScr.GetDefaultSpeedChangeCap() * slowdownMagnitude;

        ballScr.currentSpeed *= slowdownMagnitude;
        ballBody.linearVelocity = ballBody.linearVelocity.normalized * ballScr.currentSpeed;

    }
    private void StopSlowDown()
    {
        ballScr.baseSpeed = ballScr.GetDefaultBaseSpeed();
        ballScr.speedChangeCap = ballScr.GetDefaultSpeedChangeCap();

        ballScr.currentSpeed /= slowdownMagnitude;
        ballBody.linearVelocity = ballBody.linearVelocity.normalized * ballScr.currentSpeed;

    }



    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("slowing");

        if(ballBody.bodyType == RigidbodyType2D.Dynamic)
        {
            StartSlowDown();
        }

    }
    private void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log("unslowing");

        if (ballBody.bodyType == RigidbodyType2D.Dynamic)
        {
            StopSlowDown();
        }
    }
}
