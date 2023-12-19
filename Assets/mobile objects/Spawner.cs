using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Spawner : MonoBehaviour
{
    public GameObject prefab;
    public int maximumSpawnAmount;
    private int spawned = 0;
    private NavMeshTriangulation Triangulation;

    // Start is called before the first frame update
    private void Start()
    {
        Triangulation = NavMesh.CalculateTriangulation();
    }

    // Update is called once per frame
    void Update()
    {
        if (maximumSpawnAmount > spawned)
        {
            int VertexIndex = Random.Range(0, Triangulation.vertices.Length);

            NavMeshHit Hit;

            if (NavMesh.SamplePosition(Triangulation.vertices[VertexIndex], out Hit, 3.0f, -1))
            {
                Instantiate(prefab, Hit.position, Quaternion.identity);
                spawned++;
            }
        }

        else
        {
            gameObject.SetActive(false);
        }
    }
}