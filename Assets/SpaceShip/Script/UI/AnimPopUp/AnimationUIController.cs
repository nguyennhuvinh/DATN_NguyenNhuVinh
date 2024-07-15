using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AnimationUIController : MonoBehaviour
{
    [SerializeField] private Transform content;
    [SerializeField] private float durationClose;
    [SerializeField] private float durationOpen;
    [SerializeField] private AnimBase animUI;

    private void OnEnable()
    {
        animUI.Open(content, durationOpen);
        /*GameManager.Instance.audioManager.PlaySoundPopUp();*/
    }
    public void ClosePopUp() // call in funcion exit popup
    {
        animUI.Close(content, durationClose);
    }
}
public enum StateAnimOpen
{
    TOP_TO_DOWN,
    DOWN_TO_TOP,
    SCALE,
    LEFT_TO_RIGHT,
    RIGHT_TO_LEFT,
    FADE_IN
}
public enum StateAnimClose
{
    TOP_TO_DOWN,
    DOWN_TO_TOP,
    SCALE,
    LEFT_TO_RIGHT,
    RIGHT_TO_LEFT,
    FADE_OUT
}

