using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIinGame : MonoBehaviour
{
    [SerializeField] public TMP_Text HpPlayer;
    [SerializeField] public TMP_Text BulletUpPlayer;
    [SerializeField] public TMP_Text TimeSurive;

    
    private void Update()
    {
       
            UpdateShipInfo();
            UpdateTimesurive();
        
       
    }

    public void UpdateTimesurive()
    {
        int minutes = GameController.Instance.TimeSurive / 60;
        int seconds = GameController.Instance.TimeSurive % 60;

        TimeSurive.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    public void UpdateShipInfo()
    {
        float hpMx = PlayerCtrl.Instance.playerDameReceiver.MaxHp;
        float hp = PlayerCtrl.Instance.playerDameReceiver.Hp;
        if (PlayerCtrl.Instance == null)
        {
            HpPlayer.text = $"0 /{hpMx}";
        };
        
            
            int bulletCount = PlayerCtrl.Instance.playerShooting.bulletCount;

            HpPlayer.text = $"{hp}/{hpMx}";
            BulletUpPlayer.text = bulletCount == 5 ? "Max" : bulletCount.ToString();
        
       
    }
}
