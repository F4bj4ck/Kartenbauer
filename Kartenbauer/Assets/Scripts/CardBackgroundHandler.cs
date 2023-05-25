using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardBackgroundHandler : MonoBehaviour
{
    [SerializeField]
    private GameObject backgroundToActivate;
    [SerializeField]
    private GameObject[] backgroundsToDeactivate;

    public void SwapBackgrounds()
    {
        backgroundToActivate.SetActive(true);

        foreach (var background in backgroundsToDeactivate)
        {
            background.SetActive(false);
        }
    }
}
