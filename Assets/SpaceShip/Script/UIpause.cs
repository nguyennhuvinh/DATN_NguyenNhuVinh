 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIpause : MonoBehaviour
{
    [SerializeField] TMP_Text HightTime;
    [SerializeField] GameObject btnRePlay;
    [SerializeField] GameObject btnRestart;

    private void Start()
    {
        if (GameController.Instance.currentState == GameState.PAUSED)
        {
            DisPlayTime();
            
        }
       
    }

    public void DisPlayTime()
    {
        
        int minutes1 = Pref.HighTime / 60;
        int seconds1 = Pref.HighTime % 60;

        HightTime.text = string.Format("{0:00}:{1:00}", minutes1, seconds1);
  
    }

    public void ReplayGame()
    {
        Time.timeScale = 1;
        AudioManager.Instance.PlaySFX(AudioManager.Instance.Button);
        GameController.Instance.currentState = GameState.PLAYING;
        
        UIManager.Instance.Pause.SetActive(false);
    }
}
