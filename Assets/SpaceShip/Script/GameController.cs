using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pattern;

public enum GameState
{
    STARTING,
    PLAYING,
    PAUSED,
    GAMEOVER,
    Exit,
}

public class GameController : Singleton<GameController>
{
    [Header("----Player----")]
    [SerializeField] public GameObject Player_Prefab;
    public GameObject I_Player;

    [Header("----Enemy----")]
    [SerializeField] public GameObject[] Enemy_Prefabs;
    [SerializeField] private int spawnDelay = 2; // Example delay in seconds
    [SerializeField] public int countEnemiesToSpawn = 3; // Example count

    [Header("----Level-----")]
    [SerializeField] public int TimeSurive = 1;

    public GameState currentState;

    protected override void Awake()
    {
        Time.timeScale = 1;
    }

    private void Start()
    {
        Init();
        
    }

    private void Init()
    {
        currentState = GameState.STARTING;
        //Spawn_Player();

    }

    private void Spawn_Player()
    {
        if (Player_Prefab == null) return;

        I_Player = Instantiate(Player_Prefab, MapController.instance.playerSpawnPoint.position, Quaternion.identity);
    }

    public IEnumerator Spawn_Enemy(int count)
    {
        if (Enemy_Prefabs == null || Enemy_Prefabs.Length == 0) yield break;

        while (currentState == GameState.PLAYING)
        {
            for (int i = 0; i < count; i++)
            {
                int randomEnemyIndex = Random.Range(0, Enemy_Prefabs.Length);
                Transform spawnPoint = MapController.instance.RamdomAISpawnPoint;

                if (spawnPoint != null)
                {
                   GameObject I_Enemy = Instantiate(Enemy_Prefabs[randomEnemyIndex], spawnPoint.position, Quaternion.identity);
                   I_Enemy.transform.SetParent(transform); 
                }
            }
            yield return new WaitForSeconds(spawnDelay);
        }
    }

    public IEnumerator DistanceIncreaseCoroutine()
    {
        while (currentState == GameState.PLAYING)
        {
            yield return new WaitForSeconds(1f);

            TimeSurive++;
            if (TimeSurive > Pref.HighTime)
            {
                 Pref.HighTime = TimeSurive;
                
            }
            if (TimeSurive % 120 == 0)
            {
                LevelOfDifficult();
            }
        }
    }

    private void LevelOfDifficult()
    {
        CollectableManager.instance.DecreaseSpawnRate(0.001f);
        countEnemiesToSpawn++;
        MapController.instance.bGScroll.speed += 0.01f;
       

    }

    public void DestroyPlayer()
    {
        if (I_Player != null)
        {
            Destroy(I_Player);
        }
    }
}
