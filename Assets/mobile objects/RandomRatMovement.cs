using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RandomRatMovement : MonoBehaviour
{
    private NavMeshAgent _agent;
    public GameObject Player;
    [SerializeField] LayerMask groundLayer, playerLayer;
    Vector3 destPoint;
    bool walkpointSet;
    [SerializeField] float range;

    // Start is called before the first frame update
    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        RandomMovement();
    }

    void RandomMovement()
    {
        if (!walkpointSet) SearchForDest();
        if (walkpointSet) _agent.SetDestination(destPoint);
        if (Vector3.Distance(transform.position, destPoint) < 3.0f) walkpointSet = false;
    }

    void SearchForDest()
    {
        float z = Random.Range(-range, range);
        float x = Random.Range(-range, range);

        destPoint = new Vector3(transform.position.x + x, transform.position.y, transform.position.z + z);

        if (Physics.Raycast(destPoint, Vector3.down, groundLayer)) walkpointSet = true;
    }
}
