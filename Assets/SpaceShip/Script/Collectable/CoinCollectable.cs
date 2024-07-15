using UnityEngine;
public class CoinCollectable : Collectable
{
    public override void Trigger()
    {
        AudioManager.Instance.PlaySFX(AudioManager.Instance.addCoin);
        int bonus = Random.Range(10, 50);
        Pref.coins += bonus;
        
    }

}
