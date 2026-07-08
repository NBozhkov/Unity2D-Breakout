using UnityEngine;

public class AddditionalTilesBrickScript : MonoBehaviour
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
        GameObject.Find("AdditionalTiles").GetComponent<AdditionalTilesScript>().AddToTimer(duration);
    }


}
