using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOffMusic : MonoBehaviour
{
    [SerializeField] GameObject pauseScreen;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (pauseScreen.activeInHierarchy)
        {
            gameObject.GetComponent<AudioListener>().enabled = false;
        }
        else
        {
            gameObject.GetComponent<AudioListener>().enabled = true;
        }
    }
}
