using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class ScoreBar2 : MonoBehaviour
{
    public Slider slider; 

    public void SetMaxScore(int score)
    {
        slider.maxValue = score;
        slider.value = 0f;

    }
    
    public void SetScore(int score)
    {
        slider.value = score;
    }
}
