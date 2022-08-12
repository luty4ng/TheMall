using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UITimer : MonoBehaviour
{
    public TMP_Text text_Timer;

    private float timer = 0.0f;
    void Start()
    {

    }

    void Update()
    {
        timer += Time.deltaTime;
        DisplayTime();
    }

    void DisplayTime()
    {
        int hours = Mathf.FloorToInt(timer / 3600.0f);
        int minutes = Mathf.FloorToInt((timer - hours * 60)/60);
        int seconds = Mathf.FloorToInt(timer - minutes * 60);
        text_Timer.text = string.Format("{0:00}:{1:00}:{2:00}", hours, minutes, seconds);
    }
}
