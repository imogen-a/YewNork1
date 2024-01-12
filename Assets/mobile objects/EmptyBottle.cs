using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class EmptyBottle : MonoBehaviour
{
    public static bool sprayBottleEmpty = false;

    // Start is called before the first frame update
    void Start()
    {
        sprayBottleEmpty = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (sprayBottleEmpty == false)
        {
            if (ScoreManager.scoreCount == 5 || ScoreManager.scoreCount == 10)
            {
                gameObject.SetActive(false);
                sprayBottleEmpty = true;
            }
        }
    }
}
