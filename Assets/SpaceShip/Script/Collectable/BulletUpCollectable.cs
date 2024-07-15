
using UnityEngine;

public class BulletUpCollectable : Collectable
{
  
    public int triggerNeed = 5;

    public override void Init()
    {
        triggerNeed = 5;
    }

    public override void Trigger()
    {
        Pref.trigger++;
        AudioManager.Instance.PlaySFX(AudioManager.Instance.GetItem);
        if (Pref.trigger > triggerNeed && PlayerCtrl.Instance.playerShooting.bulletCount <5)
        {
            PlayerCtrl.Instance.playerShooting.bulletCount += 1;
            triggerNeed ++;
            Debug.Log(Pref.trigger);
            Pref.ClearTrigger();
            
        }
        

    }
}
