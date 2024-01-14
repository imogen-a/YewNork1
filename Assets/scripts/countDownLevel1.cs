using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class countDownLevel1 : MonoBehaviour
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
        while (currentTime >= 0 && ScoreManager.scoreCount < 10f)
        //while the time left is more than 0,
        {
            timeImage.fillAmount = Mathf.InverseLerp(0, duration, currentTime);
            timeText.text = currentTime.ToString();
            //change the time text to reflect the current time
            yield return new WaitForSeconds(1f);
            currentTime --;
            //subtract 1 from current time
        }
        if (currentTime >= 0 && ScoreManager.scoreCount >= 10f)
        {
            OpenPanelWin();
            ScoreManager.scoreCount = 10;
        }
        else
        {
            OpenPanelLose();
        }
    }
    /*

    void OpenPanel()
    {
        timeText.text = "";
        if (ScoreManager.scoreCount >= 10f)
        {
            panel_win.SetActive(true);
            Time.timeScale = 0f;
        }

        else
        {
            panel_lose.SetActive(true);
            Time.timeScale = 0f;
        }
        //panel.SetActive(true);
    }
*/
    void OpenPanelWin()
    {
        panel_win.SetActive(true);
    }

    void OpenPanelLose()
    {
        panel_lose.SetActive(true);
    }
}





