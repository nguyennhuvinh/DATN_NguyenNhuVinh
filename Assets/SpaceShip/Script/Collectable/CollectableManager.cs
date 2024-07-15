using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pattern;

[System.Serializable]
public class CollectableItem
{
    [Range(0f, 1f)]
    public float spawnRate;
    public int amount;
    public Collectable collectablePrefab;
}

public class CollectableManager : Singleton<CollectableManager>
{
    [SerializeField] private CollectableItem[] m_items;

    public void Spawn(Vector3 position)
    {
        if (m_items == null || m_items.Length <= 0) return;

        float spawnRateChecking = Random.value;

        for(int i =0; i < m_items.Length; i++)
        {
            var item = m_items[i];
            if (item == null || item.spawnRate < spawnRateChecking) continue;

            CreateColletable(position, item);
        }
    }
    
    private void CreateColletable( Vector3 spawnPos, CollectableItem collectableItem)
    {
        for(int i =0; i< collectableItem.amount; i++)
        {
            Instantiate(collectableItem.collectablePrefab, spawnPos, Quaternion.identity);
        }
    }

    public void DecreaseSpawnRate(float amount)
    {
        if (m_items == null) return;

        foreach (var item in m_items)
        {
            if (item != null)
            {
                item.spawnRate = Mathf.Max(0, item.spawnRate - amount); 
                if(item.spawnRate == 0.001)
                {
                    amount = 0;
                }
            }

        }
    }

}
