using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pattern;

public class AudioManager : Singleton<AudioManager>
{
    [Header("------ Audio Source ------")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;

    public float sfxVol = 1;
    public float SndVol = 1;

    [Header("------ Audio Clip ------")]
    public AudioClip background;
    public AudioClip Shoot;
    public AudioClip YouLose;
    public AudioClip addCoin;
    public AudioClip GetItem;
    public AudioClip PlayerDead;
    public AudioClip Button;
    public AudioClip EnemyHit;

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


    private void Start()
    {
        initSound();
        LoadSFXSettings();
        LoadAudioSettings();
        if (PlayerPrefs.GetInt("MuteMusic", 0) == 0)
        {
            musicBackgroundOn();
        }

    }

    public void musicBackgroundOn()
    {
        musicSource.clip = background;
        musicSource.Play();
    }

    public void musicBackgroundOff()
    {
        musicSource.clip = background;
        musicSource.Pause();
    }

    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }


    public void initSound()
    {
        SFXSource.volume = sfxVol;
    }

    public void ToggleSFX()
    {
        if (UIManager.instance.uiMuteSFX.activeSelf)
        {
            sfxVol = 0; 
            PlayerPrefs.SetInt("MuteSFX", 1); 
        }
        else
        {
            sfxVol = 1;
            PlayerPrefs.SetInt("MuteSFX", 0);
        }
        PlayerPrefs.Save(); 
        initSound(); 
    }

    public void LoadSFXSettings()
    {
        if (PlayerPrefs.HasKey("MuteSFX"))
        {
            
            int muteState = PlayerPrefs.GetInt("MuteSFX");
            sfxVol = (muteState == 1) ? 0 : 1;
            instance.SFXSource.volume = sfxVol;
            UIManager.instance.uiMuteSFX.SetActive(muteState == 1);
        }
    }

    public void ToggleMusic()
    {
        if (PlayerPrefs.GetInt("MuteMusic", 0) == 1)
        {
            musicBackgroundOn(); 
            PlayerPrefs.SetInt("MuteMusic", 0); 
        }
        else
        {
            musicBackgroundOff(); 
            PlayerPrefs.SetInt("MuteMusic", 1); 
        }
        PlayerPrefs.Save(); 
    }

    public void LoadAudioSettings()
    {
        if (PlayerPrefs.HasKey("MuteMusic"))
        {
            if (PlayerPrefs.GetInt("MuteMusic") == 1)
            {
                musicBackgroundOff();
            }
            else
            {
                musicBackgroundOn();
            }
        }
    }
}
