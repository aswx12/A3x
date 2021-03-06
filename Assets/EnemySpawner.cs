using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public static EnemySpawner Instance;

    public static bool currentlyInWave = false;

    public GameObject[] spawnPoints;
    GameObject currentSpawnPoint;

    public List<GameObject> enemies;

    private bool spawnAnEnemy;
    public GameObject player;
    public GameObject[] enemyTypes;
    public float minSpawnTime, maxSpawnTime, spawnRateIncreaseInterval;
    public float spawnTimer;
    public bool canSpawn;

    public int spawnDistanceToPlayer, spawnDistanceToEnemy;
    public int enemyPerSpawn;

    Vector3 randomSpawn;
    int randomSpawnRangeMin, randomSpawnRangeMax;
    Vector3 trueSpawnPoint;

    // Start is called before the first frame update
    void Start()
    {
        randomSpawnRangeMin = -35;
        randomSpawnRangeMax = 35;
        enemyPerSpawn = 1;
        TriggerWave();

    }

    private void Awake()
    {
        Instance = this;

    }

    public void TriggerWave()
    {
        canSpawn = true;
        spawnTimer = 0;
        Invoke("SpawnEnemy", 0.5f);
    }

    void SpawnEnemy()
    {
        spawnAnEnemy = true;
        currentSpawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
        float timeBetweenSpawns = Random.Range(minSpawnTime, maxSpawnTime);
        randomSpawn = new Vector3(Random.Range(randomSpawnRangeMin, randomSpawnRangeMax), 0, Random.Range(randomSpawnRangeMin, randomSpawnRangeMax));
        trueSpawnPoint = currentSpawnPoint.transform.position - randomSpawn;
        if (enemies.Count <= 3000)
            if (canSpawn)
            {
                if (Vector3.Distance(player.transform.position, trueSpawnPoint) < spawnDistanceToPlayer)
                {
                    spawnAnEnemy = false;
                }

                if (spawnAnEnemy)
                {
                    for (int i = 0; i < enemyPerSpawn; i++)
                    {
                        GameObject newEnemy = Instantiate(enemyTypes[Random.Range(0, enemyTypes.Length)], trueSpawnPoint, Quaternion.identity);
                        enemies.Add(newEnemy);
                    }
                }
                else
                {
                    timeBetweenSpawns = minSpawnTime / 2;
                }

                Invoke("SpawnEnemy", timeBetweenSpawns);

            }
    }

    // Update is called once per frame
    void Update()
    {
        if (canSpawn)
        {
            spawnTimer += Time.deltaTime;
            if (spawnTimer >= spawnRateIncreaseInterval)
            {
                enemyPerSpawn++;
                spawnTimer = 0;
            }

        }

        for (int i = 0; i < enemies.Count; i++)
        {
            Enemy es = enemies[i].GetComponent<Enemy>();

            if (es.health <= 0)
            {

                enemies.RemoveAt(i);
                i--;
            }
        }

    }
}

