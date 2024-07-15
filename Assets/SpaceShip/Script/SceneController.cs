using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pattern;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class SceneController : Singleton<SceneController>
{
    [SerializeField] private CanvasGroup TransitionBG;


    protected override void Awake()
    {
        if (instance == null)
        {

            DontDestroyOnLoad(gameObject);
        }
        else
        {
            instance = this;
            Destroy(gameObject);
        }
    }

    public void LoadNextScene(string sceneName)
    {
        AudioManager.Instance.PlaySFX(AudioManager.Instance.Button);
        GameController.instance.currentState = GameState.Exit;
        Time.timeScale = 1;
        TransitionBG.gameObject.SetActive(true);
        
        TransitionBG.DOFade(1, 0.5f).OnComplete(() =>
        {
            SceneManager.LoadScene(sceneName);
            TransitionBG.DOFade(0, 0.5f).OnComplete(() =>
            {
                Time.timeScale = 1;
                TransitionBG.gameObject.SetActive(false);
            });

        });
    }

    public void Quit()
    {
        AudioManager.Instance.PlaySFX(AudioManager.Instance.Button);
        Application.Quit();
    }
}
