using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField] private GameObject BulletPos;
    [SerializeField] private GameObject prefab_bullet_Player;
    [SerializeField] private int BulletCount = 1;
    [SerializeField] private float fireRate = 0.5f;
    private float nextFireTime = 0f;

    public GameObject Prefab_bullet_player => prefab_bullet_Player;
     
    public float FireRate
    {
        get => fireRate;
        set => fireRate = value;
    }

    public int bulletCount
    {
        get => BulletCount;
        set => BulletCount = value;
    }


    public void Start()
    {
        BulletPooling.Instance.BulletPooled(Prefab_bullet_player, 20);
    }


    private void Update()
    {
        if(GameController.Instance.currentState == GameState.PLAYING)
        {
            TimeShoot();
        }
    }

    public void TimeShoot()
    {

        if (Time.time >= nextFireTime)
        {
            spawnbullet(BulletCount);
            AudioManager.Instance.PlaySFX(AudioManager.Instance.Shoot);
            nextFireTime = Time.time + fireRate;
        }
    }


    public void spawnbullet(int count)
    {
        int dieuKien = count;
 
        for (int i = 0; i < dieuKien; i++)
        {
            
            GameObject bullet = BulletPooling.Instance.BulletPooledObject();
            bullet.transform.position = BulletPos.transform.position;
            
            if (bullet != null)
            {
             
                bullet.SetActive(true);  
 
            }
        }
    }
}
