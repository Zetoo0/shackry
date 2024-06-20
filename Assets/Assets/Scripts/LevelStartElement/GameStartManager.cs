using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;using Random = UnityEngine.Random;
using Unity.Jobs;
using Unity.Burst;
using Unity.Collections;
using UnityEngine.Jobs;


public class GameStartManager : MonoBehaviour {
    //Terrain, map stuffs, later i dont really want to use terrain
    TerrainData terrainDat;
    int randomI;
    [SerializeField] private GameObject[] Positions;
    [SerializeField] Terrain terrain;
    float TerrainWidth;
    float TerrainLength;
    float TerrainXPos;
    float TerrainZPos;

    //Spawning enemies primitives, object pooling
    [SerializeField] GameObject Enemy;
    [SerializeField] int numOfSpawnObjects;
    [SerializeField] private GameObject[] spawnables;
    [SerializeField] public List<Dictionary<GameObject,int>>  toSpawnObstaclesForMap;
    [SerializeField] public GameObject[]  toSpawnObstaclesForMap2;
    [SerializeField] private int spawnObstaclesNum;
    [SerializeField]private List<GameObject> EnemyObjectPool;
   // [SerializeField] private int levelPartNum;
    public static Action PartCompleted;
    public static Action gameWon;
    public int enemyNum;
    private int currentLiveZombieKills;
    public int totalZombieKills;
    private int currentHaveToSpawn;
    [SerializeField][Range(1,5)] int spawnEnemiesMultiplier;
    
    void Start()
    {
        toSpawnObstaclesForMap = new List<Dictionary<GameObject, int>>();
        EnemyObjectPool = new List<GameObject>();
        currentLiveZombieKills = 0;
        totalZombieKills = 0;
        currentHaveToSpawn = enemyNum / 3;
        enemyStateMachine.enemyDying += ZombieKilled;
        SpawnObstacles();
        SpawnThingsStart();
        SpawnEnemies();
    }

    private void OnDestroy()
    {
        enemyStateMachine.enemyDying -= ZombieKilled;
    }

    private void ZombieKilled()
    {
        currentLiveZombieKills++;
        totalZombieKills++;
        Debug.Log("Total killed: " + totalZombieKills );
        Debug.Log("Current Zombie Killed: " + currentLiveZombieKills);
        Debug.Log("Ennyi a spawnolási zombik: " + currentHaveToSpawn);
        if (totalZombieKills.Equals(enemyNum))
        {
            gameWon?.Invoke();
        }
        if(currentLiveZombieKills.Equals(currentHaveToSpawn))
        {
            Debug.Log("Part completed");
            currentLiveZombieKills = 0;
            PartCompleted?.Invoke();
            if(totalZombieKills < enemyNum)
            {
                Debug.Log("Game not completed Just a Part");
                NewWave();
            }
        }
    }

    private void SpawnObstacles()
    {
        foreach (GameObject go in toSpawnObstaclesForMap2)
        {
            for (int i = 0; i < spawnObstaclesNum;i++)
            {
                GameObject obstacle = Instantiate(go, CreateRandomPositionForEnemies(0.17f), Quaternion.identity);
                obstacle.SetActive(true);
            }
        }
    }
    
    [BurstCompile]
    private void SpawnThingsStart() {
        for (int i = 0; i < spawnables.Length; i++)
        {
            for (int j = 0; j < enemyNum; j++)
            {
                GameObject enemy = Instantiate(spawnables[i], CreateRandomPositionForEnemies(2.6f), Quaternion.identity);
                enemy.SetActive(false);
                EnemyObjectPool.Add(enemy);
            }
        }
    }

    private void NewWave()
    {
        EnemyObjectPool.Clear();
       // SetRandomPositionForEnemies();
        SpawnThingsStart(); 
        SpawnEnemies();
        Debug.Log("Enemies spawned again");
    }

    private void SpawnEnemies()
    {
       // int currentSpawn = enemyNum / 3;
        Debug.Log("Ennyit kell spawnolnom a Wavehez: " + currentHaveToSpawn);
        int i = 0;
        foreach (GameObject enemy in EnemyObjectPool)
        {
            if (i <= currentHaveToSpawn)
            {
                enemy.SetActive(true);
                i++;
            }
            else
            {
                break;
            }
        }
    }

   /* private void SetRandomPositionForEnemies()
    {
        foreach (GameObject nemy in EnemyObjectPool)
        {
            nemy.transform.position = CreateRandomPositionForEnemies();
        }
    }*/
    
    private void SpawObjects(GameObject obj) {
        float RandomizedX = Random.Range(TerrainData.TerrainXPos, TerrainData.TerrainWidth + TerrainData.TerrainXPos);
        float RandomizedZ = Random.Range(TerrainData.TerrainZPos, TerrainData.TerrainLength + TerrainData.TerrainZPos);
        float YValue = Terrain.activeTerrain.SampleHeight(new Vector3(RandomizedX, 0.0f, RandomizedZ));
        obj.SetActive(false);
        Instantiate(obj, new Vector3(RandomizedX, 2.6f, RandomizedZ), Quaternion.identity);
    }
    
    private Vector3 CreateRandomPositionForEnemies(float spawnY) {
        float RandomizedX = UnityEngine.Random.Range(TerrainData.TerrainXPos, TerrainData.TerrainWidth + TerrainData.TerrainXPos);
        float RandomizedZ = UnityEngine.Random.Range(TerrainData.TerrainZPos, TerrainData.TerrainLength + TerrainData.TerrainZPos);
        Vector3 retVec = new Vector3(RandomizedX, spawnY, RandomizedZ);
        return retVec;
    }

    public void StopGame()
    {
        Time.timeScale = 0;
    }
  
}
