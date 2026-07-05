using System.Collections;
using UnityEngine;

public class SlowdownFieldScript : MonoBehaviour
{
    [SerializeField] private float slowdownStartY = -2, slowdownMagnitude = 2;
    private float slowdownTimer = 0;

    [SerializeField] private SpriteRenderer slowdownFieldRenderer;

    private BallScript ballScr;
    private Rigidbody2D ballBody;


    private void Start()
    {
        ballScr = GameObject.Find("Ball").GetComponent<BallScript>();
        ballBody = GameObject.Find("Ball").GetComponent<Rigidbody2D>();

        transform.position = new Vector2(0, - Camera.main.orthographicSize);
        transform.localScale = new Vector2(2 * Camera.main.orthographicSize, Camera.main.orthographicSize + slowdownStartY);


    }

    private void Update()
    {
        if(slowdownTimer > 0)
        {
            slowdownTimer -= Time.deltaTime;
        }
        else
        {
            Debug.Log("unshowing");

            DisableField();
        }




    }



    private void EnableField()
    {
        this.enabled = true;
        slowdownFieldRenderer.enabled = true;

    }
    private void DisableField()
    {
        this.enabled = false;
        slowdownFieldRenderer.enabled = false;

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
        ballBody.linearVelocityY /= slowdownMagnitude;
        
    }
    private void StopSlowDown()
    {

    }

    //private IEnumerator SlowdownDurationTimer()
    //{
    //    yield return new WaitForSeconds(slowdownDuration);
    //    StopSlowDown();
    //}



    private void OnTriggerEnter()
    {
        Debug.Log("slowing");

        // TODO: the visual effect


        StartSlowDown();

        //StartCoroutine(SlowdownDurationTimer());

    }
}
