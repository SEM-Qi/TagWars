using UnityEngine;
using UnityEngine.UI;
using System.Collections;

/* Countdown Animation */

public class CountDown : MonoBehaviour
{
    public Text timerLabel;
    public GameObject scripts;

    private Controller con;

    private string timerText;
    private int countdown;

    void Start()
    {
        con = scripts.GetComponent<Controller>();
    }

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
            timerText = "#FIGHT";
            countdown -= 1;
        }
        else if (countdown < 0)
        {
            timerText = "";
            con.SetTimerOver(true);
            CancelInvoke();
        }
        else
        {
            timerText = countdown.ToString();
            countdown -= 1;
        }
        timerLabel.text = timerText;
    }
}
