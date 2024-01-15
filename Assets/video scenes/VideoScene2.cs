using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class VideoScene2 : MonoBehaviour
{
    [SerializeField]
    VideoPlayer myVideoPlayer;
    // Start is called before the first frame update
    void Start()
    {
        myVideoPlayer.loopPointReached += DoSomethingWhenVideoDone;
    }

    // Update is called once per frame
    void DoSomethingWhenVideoDone(VideoPlayer vp)
    {
        Debug.Log("Yeahhh the cutscene is done");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
