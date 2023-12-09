using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class countDown : MonoBehaviour
{
    [SerializeField] GameObject panel_win;
    [SerializeField] GameObject panel_lose;
    [SerializeField] Image timeImage;
    [SerializeField] Text timeText;
    [SerializeField] float duration, currentTime;
   
    // Start is called before the first frame update
    void Start()
    {
        panel_win.SetActive(false);
        panel_lose.SetActive(false);
        currentTime = duration;
        timeText.text = currentTime.ToString();
        //changes the countdown text to the current time, converting the numbers to a string
        StartCoroutine(TimeIEn());
    }

    IEnumerator TimeIEn()
    {
        while (currentTime >= 0)
        //while the time left is more than 0,
        {
            timeImage.fillAmount = Mathf.InverseLerp(0, duration, currentTime);
            timeText.text = currentTime.ToString();
            //change the time text to reflect the current time
            yield return new WaitForSeconds(1f);
            currentTime --;
            //subtract 1 from current time
        }
        OpenPanel();
    }

    void OpenPanel()
    {
        timeText.text = "";
        if (ScoreManager.scoreCount == 5f)
        {
            panel_win.SetActive(true);
        }

        else
        {
            panel_lose.SetActive(true);
        }
        //panel.SetActive(true);
    }
}


