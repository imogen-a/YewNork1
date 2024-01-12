using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RatChasing : MonoBehaviour
{
    private NavMeshAgent _agent;
    private GameObject Player;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        _agent.SetDestination(Player.transform.position);
    }
}
