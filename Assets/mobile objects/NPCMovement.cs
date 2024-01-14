using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.AI;

public class NPCMovement : MonoBehaviour
{
    private NavMeshAgent _agent;
    private GameObject Player;
    private float runDistanceRange = 3.0f;
    public static Collider _Collider;

    public float movementRange;

    public static bool yewNorkCoroutineStarted = false;
    public YewNorkController yewNorkController;

    // Start is called before the first frame update
    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        Player = GameObject.Find("Player");
        _Collider = gameObject.GetComponent<Collider>();
        yewNorkController = GetComponent<YewNorkController>();
    }

    // Update is called once per frame
    void Update()
    {

        Collider[] coliders = Physics.OverlapBox(this.transform.position, _Collider.bounds.extents);
        for (int i = 0; i < coliders.Length; i++)
        {
            if (coliders[i].gameObject == Player)
            {
                if (yewNorkCoroutineStarted == false)
                {
                    yewNorkController.StartYewNorking();
                    StartCoroutine(YewNorkCoroutine());
                    yewNorkCoroutineStarted = true;
                }
            }
        }

        if (_agent.remainingDistance <= _agent.stoppingDistance)
        {
            Vector3 point;
            if (RandomPoint(transform.position, movementRange, out point))
            {
                _agent.SetDestination(point);
            }
        }

        bool RandomPoint(Vector3 center, float range, out Vector3 result)
        {
            Vector3 randomPoint = center + new Vector3(UnityEngine.Random.Range(-3.0f, 3.0f), 0, UnityEngine.Random.Range(-3.0f, 3.0f));
            NavMeshHit hit;
            if (NavMesh.SamplePosition(randomPoint, out hit, 3.0f, NavMesh.AllAreas))
            {
                result = hit.position;
                return true;
            }
            result = Vector3.zero;
            return false;
        }

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
    }

    IEnumerator YewNorkCoroutine()
    {
        yield return new WaitForSeconds(0.0f);
        yewNorkCoroutineStarted = false;
        yewNorkController.StopYewNorking();
    }
}