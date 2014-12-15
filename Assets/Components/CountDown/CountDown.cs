using UnityEngine;
using UnityEngine.UI;
using System.Collections;

/* Countdown Animation */

public class CountDown : MonoBehaviour
{
    public Text timerLabel;

    private bool timerOver = false;
    private string timerText;
    private int countdown;

    public void StartCountDown()
    {
        timerText = "";
        countdown = 4;
        InvokeRepeating("UpdateCountDown", 0, 1);
    }

    public void UpdateCountDown()
    {
        if (countdown == 0)
        {
            timerText = "FIGHT";
            countdown -= 1;
        }
        else if (countdown < 0)
        {
            timerText = "";
            timerOver = true;
            CancelInvoke();
        }
        else
        {
            timerText = countdown.ToString();
            countdown -= 1;
        }
        timerLabel.text = timerText;
    }

    public bool TimerOver() { return timerOver; }
}
