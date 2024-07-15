using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pattern;
using System;

public class PlayerCtrl : Singleton<PlayerCtrl>
{
    [Header("----Link----")]
    public PlayerShoot playerShooting;
    public PlayerDameReceiver playerDameReceiver;
    public GameObject Model;
    

    [Header("----Collectable Attraction----")]
    public float attractionForce = 5f; 
    public float attractionRadius = 1f; 

    private void Start()
    {
        playerShooting = GetComponentInChildren<PlayerShoot>();
        playerDameReceiver = GetComponentInChildren<PlayerDameReceiver>();

    }

    private void Update()
    {
        AttractCollectables();
    }

    private void AttractCollectables()
    {
        Collider2D[] collectables = Physics2D.OverlapCircleAll(transform.position, attractionRadius, LayerMask.GetMask("Collectable"));
        foreach (Collider2D collectableCollider in collectables)
        {
            GameObject collectable = collectableCollider.gameObject;
            if (collectable.CompareTag(TagConsts.COLLECTABLE_TAG))
            {
                Vector2 direction = (transform.position - collectable.transform.position).normalized;
                collectable.transform.position += (Vector3)(direction * attractionForce * Time.deltaTime);
            }
        }
    }

    public void ActivateShield(float duration)
    {
        playerDameReceiver.ISshield = true;
        StartCoroutine(DisableShieldAfterDelay(duration));
    }

    private IEnumerator DisableShieldAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        playerDameReceiver.ISshield = false;
        Debug.Log("Shield disabled");
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(TagConsts.COLLECTABLE_TAG))
        {
            Collectable collectable = collision.gameObject.GetComponent<Collectable>();
            collectable?.Trigger();
            Destroy(collectable.gameObject);
        }
    }
}
