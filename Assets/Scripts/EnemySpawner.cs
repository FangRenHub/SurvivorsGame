using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyToSpawn;
    public float timeToSpawn;
    public Transform minSpawn, maxSpawn;
    private float spawnCounter;
    private Transform target;
    
    public List<WaveInfo> waves;
    private int currentWave;
    private float waveCounter;

    private List<GameObject> readToSpawn;
    // Start is called before the first frame update
    void Start()
    {
        target = PlayerHealthController.instance.transform;
        spawnCounter = timeToSpawn;
        currentWave = -1;
        GoToNextWave();
    }

    // Update is called once per frame
    void Update()
    {
        if (!PlayerHealthController.instance.isAlive) return;

        transform.position = target.position; //锁定摄像机位置

        //更新敌人
        if (PlayerHealthController.instance.isAlive)
        {
            if(currentWave < waves.Count)
            {
                waveCounter -= Time.deltaTime;
                if(waveCounter <= 0)
                {
                    GoToNextWave();
                    SpawnBoss();
                }

                spawnCounter -= Time.deltaTime;
                if (spawnCounter <= 0)
                {
                    spawnCounter = waves[currentWave].timeBetweenSpawns;
                    Instantiate(readToSpawn[Random.Range(0, readToSpawn.Count)], SelectSpawnPoint(), Quaternion.identity);   
                }
            }
        }

        /*sapwnCounter -= Time.deltaTime;
        if(sapwnCounter <= 0)
        {
            sapwnCounter = timeToSpawn;
            Instantiate(enemyToSpawn, SelectSpawnPoint(), transform.rotation); 
        }*/
        
    }

    public Vector3 SelectSpawnPoint()
    {
        Vector3 SpawnPoint = Vector3.zero;
        bool spawnVerticalEdge = Random.Range(0f, 1f) > .5f;
        if(spawnVerticalEdge)
        {
            SpawnPoint.y = Random.Range(minSpawn.position.y, maxSpawn.position.y);
            if (Random.Range(0f, 1f) > .5f)
                SpawnPoint.x = maxSpawn.position.x; 
            else SpawnPoint.x = minSpawn.position.x;
        }
        else
        {
            SpawnPoint.x = Random.Range(minSpawn.position.x, maxSpawn.position.x);
            if (Random.Range(0f, 1f) > .5f)
                SpawnPoint.y = maxSpawn.position.y;
            else SpawnPoint.y = minSpawn.position.y;
        }

        return SpawnPoint;
    }

    public void GoToNextWave()
    {
        currentWave++;
        if (currentWave >= waves.Count )
        {
            currentWave = waves.Count - 1;
        }
        readToSpawn = waves[currentWave].enemyToSpawn;
        waveCounter = waves[currentWave].waveLength;
        spawnCounter = waves[currentWave].timeBetweenSpawns;
    }

    public void SpawnBoss()
    {
        GameObject boss = Instantiate(readToSpawn[Random.Range(0, readToSpawn.Count)], SelectSpawnPoint(), Quaternion.identity);
        boss.transform.localScale = boss.transform.localScale * 1.5f;
        boss.GetComponent<EnemyController>().health *= waveCounter + 1;
        boss.GetComponent<EnemyController>().damage *= 3;
    }
}

[System.Serializable]
public class WaveInfo
{
    public List<GameObject> enemyToSpawn;
    public float waveLength = 10f;
    public float timeBetweenSpawns = 1f;
}
