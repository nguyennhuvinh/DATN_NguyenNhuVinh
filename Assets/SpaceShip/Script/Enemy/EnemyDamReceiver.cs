using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EnemyDamReceiver : DamageReceiver
{
    [SerializeField]
    protected GameObject bloodObj;

    private void Start()
    {
      
    }

    protected override void OnEnable()
    {
        base.OnEnable();
    }

    protected override void OnDead()
    {
        Instantiate(bloodObj, transform.position, Quaternion.identity);
        Destroy(transform.parent.gameObject);
        DropItem();


    }

    protected virtual void DropItem()
    {
        CollectableManager.Instance.Spawn(transform.position);
    }
}