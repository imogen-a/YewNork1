using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class VideoScene : MonoBehaviour
{
    [SerializeField]

    //public GameObject Continue;
    VideoPlayer myVideoPlayer;
    // Start is called before the first frame update
    //public static bool isContinueActive = false;

    void Start()
    {
        //isContinueActive = false;
        myVideoPlayer.loopPointReached += DoSomethingWhenVideoDone;
        //Continue.SetActive(false);
    }

    // Update is called once per frame
    void DoSomethingWhenVideoDone(VideoPlayer vp)
    {
        //Continue.SetActive(true);
        Debug.Log("Yeahhh the cutscene is done");//isContinueActive = true;
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    
        
        

    }
}
