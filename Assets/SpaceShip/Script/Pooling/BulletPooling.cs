using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pattern;

public class BulletPooling : Singleton<BulletPooling>
{
    private List<GameObject> BulletpooledObjects = new List<GameObject>();

    private void Start()
    {
        
    }

    public void BulletPooled(GameObject Prefab, int amountToPool)
    {
        for (int i = 0; i < amountToPool; i++)
        {
            GameObject obj = Instantiate(Prefab);
            obj.transform.SetParent(gameObject.transform);
            obj.SetActive(false);
            BulletpooledObjects.Add(obj);

        }
    }

    public GameObject BulletPooledObject()
    {
        for (int i = 0; i < BulletpooledObjects.Count; i++)
        {
            if (!BulletpooledObjects[i].activeInHierarchy)
            {
                return BulletpooledObjects[i];
            }
        }
        return null;
    }
}
