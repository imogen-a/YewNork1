using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pauseMenu : MonoBehaviour
{
    public GameObject PauseMenu;
    public GameObject PauseButton;
    public GameObject timer;
    

    // Start is called before the first frame update
    void Start()
    {
        PauseMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PauseGame()
    {
        PauseMenu.SetActive(true);
        PauseButton.SetActive(false);
        //timer.SetActive(false);
        Time.timeScale = 0f;
    }

    public void ResumeGame()
        {
            PauseMenu.SetActive(false);
            PauseButton.SetActive(true);
            //timer.SetActive(true);
            Time.timeScale = 1f;
        }


    public void MainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu Page");
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit");
    }
}
