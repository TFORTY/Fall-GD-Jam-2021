using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerText : MonoBehaviour
{
    public Text timerText;

    public float timer = 30.0f;

    public static bool isTimeOut = false;

    // Start is called before the first frame update
    void Start()
    {
        timerText = GetComponent<Text>();
        timerText.text = timer.ToString("0.0");
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        timerText.text = timer.ToString("0.0");

        if (timer <= 0)
        {
            isTimeOut = true;
            timer = 30.0f;
        }
        else
        {
            isTimeOut = false;
        }
    }

    public static bool IsTimeOut()
    {
        return isTimeOut;
    }

    public void LowerTime(float seconds)
    {
        timer -= seconds;
    }

    public void IncreaseTime(float seconds)
    {
        timer += seconds;
    }
}