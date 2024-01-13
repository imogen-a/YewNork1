using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RatChasing : MonoBehaviour
{
    private NavMeshAgent _agent;
    private GameObject Player;
    private float runDistanceRange = 3.0f;

    // Start is called before the first frame update
    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        Player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {

        if (VictoryDefeat.winLoseScreenActive)
        {
            float distance = Vector3.Distance(transform.position, Player.transform.position);

            // Run away from player
            if (distance < runDistanceRange)
            {
                // Vector player to me
                Vector3 dirToPlayer = transform.position - Player.transform.position;
                Vector3 newPos = transform.position + dirToPlayer;
                _agent.SetDestination(newPos);
            }
        }

        else
        {
            _agent.SetDestination(Player.transform.position);
        }
    }
}
