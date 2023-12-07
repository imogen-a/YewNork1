using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RatExtermination : MonoBehaviour
{
    void OnTriggerEnter(Collider colliding)
    {
        if (colliding.gameObject.name == "Player")
        {
            Destroy(gameObject);
        }
    }
}