using UnityEngine;

public class SlowdownBrickScript : MonoBehaviour
{
    [SerializeField] private float duration = 10;
    private void Start()
    {

    }
    private void Update()
    {

    }

    private void OnDestroy()
    {
        GameObject.Find("SlowdownField").GetComponent<SlowdownFieldScript>().AddToTimer(duration);
    }
}
