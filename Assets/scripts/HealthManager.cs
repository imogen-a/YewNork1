using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    public Text healthText;
    public static int healthCount;
    public Slider slider;
    // Start is called before the first frame update
    void Start()
    {
        slider.maxValue = 100f;
        healthCount = (int)100f;
        slider.value = healthCount;
    }

    // Update is called once per frame
    void Update()
    {
        healthText.text = Mathf.Round(healthCount) + "/100";
        slider.value = healthCount;
    }
}
