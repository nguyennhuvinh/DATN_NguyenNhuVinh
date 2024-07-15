using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Collectable : MonoBehaviour
{
    
    [SerializeField] private int m_lifeTime;
    [SerializeField] private int m_spawnForce;

    private int m_lifeTimeCounting;
    private Rigidbody2D m_rb;

    

    private void Awake()
    {
        m_rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        m_lifeTimeCounting = m_lifeTime;
       

        Init();
        StartCoroutine(CountDown());
        Explode();
    }

    private void Explode()
    {
        if (m_rb == null) return;

        float randomForceX = Random.Range(-m_spawnForce, m_spawnForce);
        float randomForceY = Random.Range(-m_spawnForce, m_spawnForce);
        m_rb.velocity = new Vector2(randomForceX, randomForceY) * Time.deltaTime;
        StartCoroutine(Moving());
    }

    private IEnumerator Moving()
    {
        yield return new WaitForSeconds(0.8f);
        if(m_rb != null)
        {
            m_rb.velocity = Vector2.down;
        }
    }

 

    private IEnumerator CountDown()
    {
        yield return null;
        float timeLifeRate = Mathf.Round((float)m_lifeTimeCounting / m_lifeTime);
        while(m_lifeTimeCounting > 0)
        {
            yield return new WaitForSeconds(1f);
            m_lifeTimeCounting--;
            if(m_lifeTimeCounting <= 0f)
            {
          
                OnDestroyCollectable();
            }
           
        }
    }

 

    private void OnDestroyCollectable()
    {
        Destroy(gameObject);
    }

    public virtual void Init()
    {
        
    }

    public virtual void Trigger()
    {

    }
    
}
