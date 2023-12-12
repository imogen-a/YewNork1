using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartLevel : MonoBehaviour
{
    // Start is called before the first frame update
    public void RestartButton()
    {
      SceneManager.LoadScene(1);  
    }

    public void RestartButton2()
    {
        SceneManager.LoadScene(2);
    }

    public void BackToHome()
    {
      SceneManager.LoadScene(0);
    }
}

