using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class RandomColour : MonoBehaviour
{
    public List<Color> NumberOfColours;

    void Start()
    {
        if (NumberOfColours.Count > 0)
        {
            Color c = NumberOfColours[Random.Range(0, NumberOfColours.Count)];
            GetComponent<Renderer>().material.color = c;
        }
    }
}
