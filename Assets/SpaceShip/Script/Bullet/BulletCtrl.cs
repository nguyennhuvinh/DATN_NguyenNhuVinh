using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCtrl : MonoBehaviour
{
    [SerializeField] public float Speed;
    [SerializeField] private Rigidbody2D rb;

    private void FixedUpdate()
    {
        BulletFly();
    }

    public void BulletFly()
    {
        rb.velocity = Vector2.up * Speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(TagConsts.ENEMY_TAG) || collision.gameObject.CompareTag(TagConsts.WALL_TAG))
        {
            gameObject.SetActive(false);
        }
    }
}
