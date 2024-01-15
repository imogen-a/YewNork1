using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadingScene3 : MonoBehaviour
{
    public GameObject LoadingScreen;
    public GameObject VideoBackground;
    public Scrollbar LoadingBarFill;

    public void LoadScene(int sceneId)
    {
        StartCoroutine(LoadSceneAsync(sceneId));

    }

    IEnumerator LoadSceneAsync(int sceneId)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneId);

        LoadingScreen.SetActive(true);
        VideoBackground.SetActive(true);
        

        while (!operation.isDone)
        {
            float progressValue = Mathf.Clamp01(operation.progress / 0.9f);
            LoadingBarFill.size = progressValue;


           yield return null; 
        }
        if (operation.isDone)
        {
            Time.timeScale = 1f;
        }

    }
}
