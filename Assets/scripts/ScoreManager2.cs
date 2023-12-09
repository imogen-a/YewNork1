using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager2 : MonoBehaviour
{
    public Text scoreText;
    public static int scoreCount;
    public Slider slider;
    // Start is called before the first frame update
    void Start()
    {
        slider.maxValue = 15f;
        slider.value = scoreCount;
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = Mathf.Round(scoreCount) + "/15";
        slider.value = scoreCount;
    }
}
