using UnityEngine;

public class InstantUpgradesBrickScript : MonoBehaviour
{

    private enum TypeOfUpgrade
    {

        Random,
        SlowDownBall,
        AdditionalPaddleTiles,
        LargePaddle
        //ExtraBall,
        //ExtraLife,
        //SuperchargedBall,
        //MultiplyAllBalls

    }

    [SerializeField] private TypeOfUpgrade typeOfUpgrade;
    [SerializeField] private float duration = 10;



    private void Start()
    {

    }

    private void Update()
    {

    }

    private void OnDestroy()
    {
        if(typeOfUpgrade == TypeOfUpgrade.Random)
        {
            typeOfUpgrade = (TypeOfUpgrade) Random.Range( 1, System.Enum.GetValues(typeof(TypeOfUpgrade)).Length );
        }



        switch (typeOfUpgrade)
        {
            case TypeOfUpgrade.SlowDownBall:

                GameObject.Find("SlowdownField").GetComponent<SlowdownFieldScript>().AddToTimer(duration);
                break;

            case TypeOfUpgrade.AdditionalPaddleTiles:

                GameObject.Find("AdditionalTiles").GetComponent<AdditionalTilesScript>().AddToTimer(duration);
                break;

            case TypeOfUpgrade.LargePaddle:
                // Implement large paddle logic here
                break;
            default:
                Debug.LogWarning("Unknown upgrade type.");
                break;
        }
    }



}
