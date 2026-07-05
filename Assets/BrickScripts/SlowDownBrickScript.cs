using UnityEngine;

public class SlowDownBrickScript : MonoBehaviour
{
    [SerializeField] private float slowdownDuration = 10;

    private void Start()
    {
        
    }

    private void Update()
    {
        
    }

    private void OnDestroy()
    {
        Debug.Log("slowing");

        GameObject.Find("SlowdownField").GetComponent<SlowdownFieldScript>().AddToTimer(slowdownDuration);

    }
}
