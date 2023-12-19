using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    private float initialDistance = -3.0f;
    private float currentDistance;
    private float x = 0.0f;
    private float y = 30.0f;
    private bool endCameraPositionSet;

    // Start is called before the first frame update
    void Start()
    {
        currentDistance = initialDistance;
    }

    // Update is called once per frame
    void Update()
    {
        if (endCameraPositionSet == false)
        {
            if (VictoryDefeat.winLoseScreenActive)
            {
                currentDistance = -3.0f;

                Quaternion endCameraRotation = Quaternion.LookRotation(player.forward, player.up);
                endCameraRotation *= Quaternion.Euler(0.0f, 180.0f, 0.0f);

                Vector3 endCameraPosition = (player.position + new Vector3(0.0f, 2.0f)) + endCameraRotation * Vector3.forward * currentDistance;

                transform.rotation = endCameraRotation;
                transform.position = endCameraPosition;
                endCameraPositionSet = true;
            }

            else
            {
                if (Input.GetMouseButton(1))
                {
                    x += Input.GetAxis("Mouse X") * 3.0f;
                    y -= Input.GetAxis("Mouse Y") * 3.0f;
                    y = Mathf.Clamp(y, -90.0f, 90.0f);
                }

                currentDistance += Input.GetAxis("Mouse ScrollWheel") * 3.0f;
                currentDistance = Mathf.Clamp(currentDistance, -4.5f, -1.5f);

                Quaternion cameraRotation = Quaternion.Euler(y, x, 0);
                Vector3 cameraPosition = (player.position + new Vector3(0.0f, 2.0f)) + cameraRotation * Vector3.forward * currentDistance;

                transform.rotation = cameraRotation;
                transform.position = cameraPosition;
            }
        }
    }

}