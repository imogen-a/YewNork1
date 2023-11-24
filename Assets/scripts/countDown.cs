using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class countDown : MonoBehaviour
{
    [SerializedField] GameObject panel;
    [SerializedField] Image timeImage;
    [SerializedField] Text timeText;
    [SerializedField] float duration, currentTime;
   
    // Start is called before the first frame update
    void Start()
    {
        panel.SetActive(false);
        currentTime = duration;
        timeText.text = currentTime.ToString();
        //changes the countdown text to the current time, converting the numbers to a string
        StartCoroutine(TimeIEn());
    }

    IEnumerator TimeIEn()
    {
        while (currentTime >= 0)
        {
            timeImage.fillAmount = Mathf.InversLerp(0, duration, currentTime);
            timeText.text = currentTime.ToString();
            yield r
        }
    }
}
