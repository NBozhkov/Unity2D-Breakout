using UnityEngine;

public class AdditionalTilesScript : MonoBehaviour
{
    [SerializeField] private GameObject additionalTilesContainer;



    private void Start()
    {
        
    }

    private float timer = 0;
    private void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
        else
        {
            DisableTiles();
        }


    }

    public void AddToTimer(float addDuration)
    {
        timer += addDuration;

        if (additionalTilesContainer.activeSelf == false)
        {
            EnableTiles();
        }
    }


    private void EnableTiles()
    {
        additionalTilesContainer.SetActive(true);
    }
    private void DisableTiles()
    {
        additionalTilesContainer.SetActive(false);
    }




}
