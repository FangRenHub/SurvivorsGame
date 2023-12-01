using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyToSpawn;
    public float timeToSpawn;
    public Transform minSpawn, maxSpawn;
    private float sapwnCounter;
    private Transform target;

    // Start is called before the first frame update
    void Start()
    {
        target = PlayerHealthController.instance.transform;
        sapwnCounter = timeToSpawn;
    }

    // Update is called once per frame
    void Update()
    {
        sapwnCounter -= Time.deltaTime;
        if(sapwnCounter <= 0)
        {
            sapwnCounter = timeToSpawn;
            Instantiate(enemyToSpawn, SelectSpawnPoint(), transform.rotation); 
        }
        transform.position = target.position;
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
}
