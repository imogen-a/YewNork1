using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSprayBottleActivation : MonoBehaviour
{
    public GameObject PlayerSprayBottle;
    public AnimationCurve movementCurve;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0.0f, 0.0f, 90.0f * Time.deltaTime, Space.Self);
        transform.position = new Vector3(transform.position.x, movementCurve.Evaluate((Time.time % movementCurve.length)), transform.position.z);
    }
    void OnDisable()
    {
        PlayerSprayBottle.SetActive(true);
    }
}