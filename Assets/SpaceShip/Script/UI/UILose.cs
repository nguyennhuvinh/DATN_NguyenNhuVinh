using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UILose : MonoBehaviour
{
    [SerializeField] TMP_Text HightTime;
    [SerializeField] TMP_Text Time;

    private void Start()
    {
        if (GameController.Instance.currentState == GameState.GAMEOVER)
        {
            DisPlayTime();
        }
        
    }

    public void DisPlayTime()
    {
        int minutes = GameController.Instance.TimeSurive / 60;
        int seconds = GameController.Instance.TimeSurive % 60;

        int minutes1 = Pref.HighTime / 60;
        int seconds1 = Pref.HighTime % 60;


        HightTime.text = string.Format("{0:00}:{1:00}", minutes1, seconds1);
        Time.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
