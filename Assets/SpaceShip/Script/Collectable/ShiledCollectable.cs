using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldCollectable : Collectable
{
    [SerializeField] private GameObject VFXShield;
    private const float ShieldDuration = 5f;

    public override void Trigger()
    {
        AudioManager.Instance.PlaySFX(AudioManager.Instance.GetItem);
        PlayerCtrl.Instance.ActivateShield(5f);
        GameObject vfx = Instantiate(VFXShield, PlayerCtrl.Instance.transform.position, VFXShield.transform.rotation);
        vfx.transform.parent = PlayerCtrl.Instance.transform;
       
    }
}