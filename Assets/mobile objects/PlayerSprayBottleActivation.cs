using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSprayBottleActivation : MonoBehaviour
{
    public GameObject PlayerSprayBottle;

    void OnDisable()
    {
        PlayerSprayBottle.SetActive(true);
    }
}