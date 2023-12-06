using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableSprayBottle : MonoBehaviour
{
    public GameObject SprayBottle;
    void OnTriggerEnter(Collider colliding)
    {
        if (colliding.gameObject.name == "Player")
        {
            gameObject.SetActive(false);
            SprayBottle.SetActive(true);
        }
    }
}