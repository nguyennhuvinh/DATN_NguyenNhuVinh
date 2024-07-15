using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDameSender : DamageSender
{
    [SerializeField]
    protected GameObject effect;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(TagConsts.ENEMY_TAG))
        {
            
            this.Send(collision.transform);
            this.DestroyBullet();
        }
    }

    protected virtual void DestroyBullet()
    {
        InstantiateRandomEffectsInCircle(transform.position, 0.3f, 1); 
        transform.parent.gameObject.SetActive(false);
    }

    private void InstantiateRandomEffectsInCircle(Vector3 center, float diameter, int count)
    {
        float radius = diameter / 2f;

        for (int i = 0; i < count; i++)
        {
  
            float angle = Random.Range(0f, 2f * Mathf.PI);
            Vector3 position = new Vector3(
                center.x + Mathf.Cos(angle) * radius,
                center.y + Mathf.Sin(angle) * radius,
                center.z
            );

            Instantiate(effect, position, Quaternion.identity);
        }
    }
}
