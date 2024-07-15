using UnityEngine;
public class HealingCollectable : Collectable
{
    public GameObject Healing;
    public override void Trigger()
    {
        AudioManager.Instance.PlaySFX(AudioManager.Instance.GetItem);
        int bonus = Random.Range(1, 3);
        Instantiate(Healing, PlayerCtrl.Instance.transform.position, Healing.transform.rotation);
        PlayerCtrl.Instance.playerDameReceiver.Add(bonus);
    }
}
