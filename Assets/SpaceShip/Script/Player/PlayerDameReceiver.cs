using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDameReceiver : DamageReceiver
{
    [SerializeField]
    protected GameObject bloodObj;

    private void Start()
    {

    }

    protected override void OnEnable()
    {
        base.OnEnable();
    }

    
    protected override void OnDead()
    {
        PlayerCtrl.Instance.Model.SetActive(false);
        AudioManager.Instance.PlaySFX(AudioManager.Instance.PlayerDead);
        Instantiate(bloodObj, transform.position, Quaternion.identity);
        StartCoroutine(UIManager.Instance.LoseUI_On());
    }
}
