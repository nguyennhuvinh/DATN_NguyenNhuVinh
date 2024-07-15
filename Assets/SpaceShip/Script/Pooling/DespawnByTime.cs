using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DespawnByTime : MonoBehaviour
{
    [SerializeField] private float delay;

    void OnEnable()
    {
        
        Destroy(gameObject, delay);
    }

    



}
