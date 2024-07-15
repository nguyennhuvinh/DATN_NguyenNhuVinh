using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pattern;
using DG.Tweening;
using TMPro;
using UnityEngine.UI;

public class UImenu : MonoBehaviour
{
    [SerializeField] public TMP_Text TimeSurive;

    private void Start()
    {
        UpdateTHIghtimesurive();
    }

    public void UpdateTHIghtimesurive()
    {
        int minutes = Pref.HighTime / 60;
        int seconds = Pref.HighTime % 60;

        TimeSurive.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

}
