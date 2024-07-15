using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCtrl : MonoBehaviour
{
    public float damage;
    public float maxHp;

    [Header("----Link----")]
    public EnemyDamReceiver enemyDamReceiver;
    public EnemyDamSender enemyDamSender;

    private void Start()
    {
        enemyDamSender = GetComponentInChildren<EnemyDamSender>();
        enemyDamReceiver = GetComponentInChildren<EnemyDamReceiver>();
        InvokeRepeating(nameof(UpInforEnemy), 0, 10f);
    }

    public void UpInforEnemy()
    {

    }
}
