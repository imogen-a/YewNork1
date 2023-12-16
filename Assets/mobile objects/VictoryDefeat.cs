using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VictoryDefeat : MonoBehaviour
{
    public GameObject PlayerSprayBottle;
    [SerializeField] GameObject winScreen;
    [SerializeField] GameObject loseScreen;
    public static bool winLoseScreenActive = false;

    // Update is called once per frame
    void Update()
    {
        if (winScreen.activeInHierarchy)
        {
            if (winLoseScreenActive == false)
            {
                PlayerSprayBottle.SetActive(false);
                GetComponent<Animator>().CrossFadeInFixedTime("Victory", 0.25f);
                winLoseScreenActive = true;
            }
        }

        if (loseScreen.activeInHierarchy)
        {
            if (winLoseScreenActive == false)
            {
                PlayerSprayBottle.SetActive(false);
                GetComponent<Animator>().CrossFadeInFixedTime("Defeat", 0.25f);
                winLoseScreenActive = true;
            }
        }
    }
}
