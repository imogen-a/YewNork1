using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.AI;

public class RatMovement : MonoBehaviour
{
    private NavMeshAgent _agent;
    public GameObject Player;
    private float RunDistanceRange = 3.0f;

    public float range;

    // Start is called before the first frame update
    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject == null)
        {

        }

        else
        {
            float distance = Vector3.Distance(transform.position, Player.transform.position);

            // Run away from player
            if (distance < RunDistanceRange)
            {
                // Vector player to me
                Vector3 dirToPlayer = transform.position - Player.transform.position;
                Vector3 newPos = transform.position + dirToPlayer;
                _agent.SetDestination(newPos);
            }
            else
            {
                if (_agent.remainingDistance <= _agent.stoppingDistance) //done with path
                {
                    Vector3 point;
                    if (RandomPoint(transform.position, range, out point)) //pass in our centre point and radius of area
                    {
                        _agent.SetDestination(point);
                    }
                }

            }
            bool RandomPoint(Vector3 center, float range, out Vector3 result)
            {

                Vector3 randomPoint = center + new Vector3(UnityEngine.Random.Range(-3.0f, 3.0f), 0, UnityEngine.Random.Range(-3.0f, 3.0f)); //random point in a sphere 
                NavMeshHit hit;
                if (NavMesh.SamplePosition(randomPoint, out hit, 3.0f, NavMesh.AllAreas)) //documentation: https://docs.unity3d.com/ScriptReference/AI.NavMesh.SamplePosition.html
                {
                    //the 1.0f is the max distance from the random point to a point on the navmesh, might want to increase if range is big
                    result = hit.position;
                    return true;
                }

                result = Vector3.zero;
                return false;
            }
        }
    }
}