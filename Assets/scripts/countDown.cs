using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class countDown : MonoBehaviour
{
    [SerializeField] GameObject panel;
    [SerializeField] Image timeImage;
    [SerializeField] TMP_Text timeText;
    [SerializeField] float duration, currentTime;
   
    // Start is called before the first frame update
    void Start()
    {
        panel.SetActive(false);
        currentTime = duration;
        timeText.TMP_Text = currentTime.ToString();
        //changes the countdown text to the current time, converting the numbers to a string
        StartCoroutine(TimeIEn());
    }

    IEnumerator TimeIEn()
    {
        while (currentTime >= 0)
        //while the time left is more than 0,
        {
            timeImage.fillAmount = Mathf.InverseLerp(0, duration, currentTime);
            timeText.TMP_Text = currentTime.ToString();
            //change the time text to reflect the current time
            yield return new WaitForSeconds(1f);
            currentTime --;
            //subtract 1 from current time
        }
        OpenPanel();
    }

    void OpenPanel()
    {
        timeText.TMP_Text = "";
        panel.SetActive(true);
    }
}


