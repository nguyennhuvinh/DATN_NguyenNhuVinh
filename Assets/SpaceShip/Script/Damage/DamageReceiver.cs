using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DamageReceiver : MonoBehaviour
{

    [SerializeField]
    protected BoxCollider2D Collider2D;
    [SerializeField]
    protected bool isDead = false;
    [SerializeField]
    protected bool isShield = false;
    [SerializeField]
    private float hp = 1;
    [SerializeField]
    protected float maxHp = 1;

    public float MaxHp { get => maxHp; set => maxHp = value; }
    public float Hp { get => hp; set => hp = value; }

    public bool ISshield { get => isShield; set => isShield = value; }
    protected virtual void OnEnable()
    {
        this.Rebord();
        
    }

    private void Start()
    {
        LoadComponents();

    }
    protected void LoadComponents()
    {
        this.LoadCollider();
    }

    protected virtual void Rebord()
    {
        this.hp = this.maxHp;
        this.isDead = false;
    }

    public virtual void Add(float add)
    {
        if (this.isDead) return;
        this.hp += add;

        if (this.hp > this.maxHp) this.hp = this.maxHp;
        
    }

    public virtual void Deduct(float deduct)
    {
        if (this.isDead || this.isShield) return;

        this.hp -= deduct;
        

        if (this.hp < 0) this.hp = 0;
        this.CheckIsDead();
    }

    protected virtual bool IsDead()
    {
        return this.hp <= 0;
    }

    protected virtual void CheckIsDead()
    {
        if (!this.IsDead()) return;
        this.isDead = true;
        this.OnDead();
    }

    protected virtual void LoadCollider()
    {
        if (Collider2D != null) return;
        this.Collider2D = GetComponent<BoxCollider2D>();
        this.Collider2D.isTrigger = true;
    }

    protected abstract void OnDead();
}
