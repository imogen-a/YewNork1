using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pauseMenu : MonoBehaviour
{
    public GameObject PauseMenu;
    public GameObject PauseButton;
    public GameObject timer;
    public GameObject character;
    

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
        character.SetActive(false);
        //timer.SetActive(false);
        Time.timeScale = 0f;
    }

    public void ResumeGame()
        {
            PauseMenu.SetActive(false);
            PauseButton.SetActive(true);
            character.SetActive(true);
            //timer.SetActive(true);
            Time.timeScale = 1f;
        }


    public void MainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu Page");
        ScoreManager.scoreCount = 0;
        FreeScoreManager.scoreCount = 0;
        ScoreManager2.scoreCount = 0;
        HealthManager.healthCount = 100;
        MyCharacter.healthCoroutineStarted = false;
        MyCharacter.scoreCoroutineStarted = false;
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit");
    }
}
