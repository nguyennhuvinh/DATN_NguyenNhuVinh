using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pattern;

public class MapController : Singleton<MapController>
{
    [Header("----Player-----")]
    [SerializeField] public Transform playerSpawnPoint;

    [Header("----Enemy----")]
    [SerializeField] private Transform[] EmemySpawnPoints;

    [Header("---Other----")]
    public BGScroll bGScroll;

    private void Start()
    {
        bGScroll = GetComponentInChildren<BGScroll>();
    }

    public Transform RamdomAISpawnPoint
    {
        get
        {
            if (EmemySpawnPoints == null || EmemySpawnPoints.Length <=0) return null;
            int randomIdx = Random.Range(0, EmemySpawnPoints.Length);

            return EmemySpawnPoints[randomIdx];
        }
    }
}
