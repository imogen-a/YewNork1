using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RatMovement : MonoBehaviour
{

    private NavMeshAgent _agent;
    public GameObject Player;
    private float RunDistanceRange = 3.0f;

    // Start is called before the first frame update
    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
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
    }
}