using UnityEngine;

public class LargePaddleBrickScript : MonoBehaviour
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
        GameObject.Find("LargePaddle").GetComponent<LargePaddleScript>().AddToTimer(duration);
    }
}
