using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyToSpawn;
    public float sapwnCounter;
    public float timeToSpawn;
    // Start is called before the first frame update
    void Start()
    {
        sapwnCounter = timeToSpawn;
    }

    // Update is called once per frame
    void Update()
    {
        sapwnCounter -= Time.deltaTime;
        if(sapwnCounter <= 0)
        {
            sapwnCounter = timeToSpawn;

            Instantiate(enemyToSpawn, transform.position, transform.rotation); 
        }
    }
}
