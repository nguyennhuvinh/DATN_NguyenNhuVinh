using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamSender : DamageSender
{
    [SerializeField]
    protected float timeDelay;
    private float timer;
    [SerializeField]
    protected GameObject effect;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag(TagConsts.PLAYER_TAG))
        {
            AudioManager.Instance.PlaySFX(AudioManager.Instance.EnemyHit);
            this.timer -= Time.deltaTime;
            if (this.timer > 0) return;
            this.timer = this.timeDelay;
            this.Send(collision.transform);
            this.AtkPlayer(collision.transform.position);
        }
    }

    protected virtual void AtkPlayer(Vector3 collisionPosition)
    {
        Instantiate(effect, collisionPosition, Quaternion.identity);
        //AudioController.Instance.PlaySound(AudioController.Instance.playerHit);
    }

    
}