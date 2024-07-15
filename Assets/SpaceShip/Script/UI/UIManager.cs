using System.Collections;
using UnityEngine;
using Pattern;
using DG.Tweening;
using TMPro;
using UnityEngine.SceneManagement;

public class UIManager : Singleton<UIManager>
{
    [Header("----Canvas----")]
    [SerializeField] public GameObject Menu;
    [SerializeField] public GameObject InGame;
    [SerializeField] public GameObject Lose;

    [Header("----Other----")]
    [SerializeField] public TMP_Text coinText;
    

    [Header("-------------Setting_UI-------------")]
    [SerializeField] GameObject panelSettingUI;
    [SerializeField] public GameObject uiMuteAudio;
    [SerializeField] public GameObject uiMuteSFX;

    [Header("-------------Pause_UI-------------")]
    [SerializeField] public GameObject btnPause;
    [SerializeField] public GameObject Pause;

    [Header("-----Shop_UI-----")]
    [SerializeField] public GameObject Shop;





    private void Start()
    {
        CheckSFXMuteState();
        CheckMusicMuteState();
    }

    private void FixedUpdate()
    {
        DisplayCoinText();
    }

    public void DisplayCoinText()
    {
        if (Pref.coins >= 10000)
        {
            coinText.text = (Pref.coins / 1000f).ToString("0") + "K";
        }
        coinText.text = Pref.coins.ToString();
    }
    
    public void PlayingGame()
    {
        AudioManager.Instance.PlaySFX(AudioManager.Instance.Button);
        MenuUI_Off();

        if (GameController.Instance.Player_Prefab != null)
        {
            GameObject playerInstance = GameObject.FindGameObjectWithTag(TagConsts.PLAYER_TAG); 
            if (playerInstance != null)
            {
               
                playerInstance.transform.DOMoveY(playerInstance.transform.position.y - 4f, 1f).OnComplete(() =>
                {
                    GameController.Instance.currentState = GameState.PLAYING;
                    StartCoroutine(GameController.Instance.Spawn_Enemy(GameController.instance.countEnemiesToSpawn));
                    InGame.SetActive(true);
                    StartCoroutine(GameController.Instance.DistanceIncreaseCoroutine());
                });
            }
        }

    }

    public void MenuUI_Off()
    {
        Menu.SetActive(false);
    }

    public void MenuUI_On()
    {
        Menu.SetActive(true);
    }

    public void SettingUI()
    {
        AudioManager.Instance.PlaySFX(AudioManager.Instance.Button);
        panelSettingUI.gameObject.SetActive(!panelSettingUI.activeSelf);
    }

    private void CheckMusicMuteState()
    {
        if (PlayerPrefs.HasKey("MuteMusic"))
        {
            bool isMuted = PlayerPrefs.GetInt("MuteMusic") == 1;
            uiMuteAudio.SetActive(isMuted);
            if (isMuted)
            {
                AudioManager.Instance.musicBackgroundOff();
            }
            else
            {
                AudioManager.Instance.musicBackgroundOn();
            }
        }
    }
    private void CheckSFXMuteState()
    {
        if (PlayerPrefs.HasKey("MuteSFX"))
        {
            bool isMuted = PlayerPrefs.GetInt("MuteSFX") == 1;
            uiMuteSFX.SetActive(isMuted);
            AudioManager.Instance.sfxVol = isMuted ? 0 : 1;
            AudioManager.Instance.initSound();
        }
    }

    public void MuteSFXON()
    {
        AudioManager.Instance.PlaySFX(AudioManager.Instance.Button);
        uiMuteSFX.gameObject.SetActive(!uiMuteSFX.activeSelf);
        AudioManager.Instance.ToggleSFX(); 
    }


    public void MuteAudioON()
    {
        AudioManager.Instance.PlaySFX(AudioManager.Instance.Button);
        uiMuteAudio.gameObject.SetActive(!uiMuteAudio.activeSelf);
        AudioManager.Instance.ToggleMusic();
    }


    public IEnumerator LoseUI_On()
    {
        AudioManager.Instance.PlaySFX(AudioManager.Instance.YouLose);
        GameController.instance.currentState = GameState.GAMEOVER;
        yield return new WaitForSeconds(1f);
        Lose.SetActive(true);
    }

    public void PauseGame()
    {
        AudioManager.Instance.PlaySFX(AudioManager.Instance.Button);
        Pause.SetActive(true);
        Time.timeScale = 0;
    }
    
    public void ShopUI_On()
    {
        AudioManager.Instance.PlaySFX(AudioManager.Instance.Button);
        Shop.SetActive(true);
        MenuUI_Off();
    }

    public void ShopUI_Off()
    {
        AudioManager.Instance.PlaySFX(AudioManager.Instance.Button);
        Shop.SetActive(false);
        MenuUI_On();
    }
}
