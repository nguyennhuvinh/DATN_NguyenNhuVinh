using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pattern;

public class EnemyPooling : Singleton<EnemyPooling>
{
    private List<GameObject> EnemypooledObjects = new List<GameObject>();

    private void Start()
    {
        foreach(var obj in GameController.instance.Enemy_Prefabs)
        {
            EnemyPooled(obj, 3);
        }
            
        
        
    }

    public void EnemyPooled(GameObject Prefab, int amountToPool)
    {
        for (int i = 0; i < amountToPool; i++)
        {
            GameObject obj = Instantiate(Prefab);
            obj.transform.SetParent(gameObject.transform);
            obj.SetActive(false);
            EnemypooledObjects.Add(obj);

        }
    }

    public GameObject EnemyPooledObject()
    {
        for (int i = 0; i < EnemypooledObjects.Count; i++)
        {
            if (!EnemypooledObjects[i].activeInHierarchy)
            {
                return EnemypooledObjects[i];
            }
        }
        return null;
    }
}
