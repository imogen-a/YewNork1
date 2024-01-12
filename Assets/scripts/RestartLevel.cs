using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartLevel : MonoBehaviour
{

    // Start is called before the first frame update
    public void RestartButton()
    {
      ScoreManager.scoreCount = 0;
      Time.timeScale = 1f;
      SceneManager.LoadScene(2);
    }

    public void RestartButton2()
    {
      ScoreManager.scoreCount = 0;
      Time.timeScale = 1f;
      SceneManager.LoadScene(4);
    }

    public void RestartButton3()
    {
      ScoreManager.scoreCount = 0;
      Time.timeScale = 1f;
      SceneManager.LoadScene(6);
    }
    


    public void BackToHome()
    {
      SceneManager.LoadScene(0);
    }

}

