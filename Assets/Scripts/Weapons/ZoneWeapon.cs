using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.WSA;

public class ZoneWeaon : Weapon 
{
    public EnemyDamager damager;
    private float spawnTime, spawnCounter;
    
    void Start()
    {
        SetStats();
    }

    
    void Update()
    {
        transform.Rotate(0f, 0f, -30f * Time.deltaTime);

        spawnCounter -= Time.deltaTime;
        if (spawnCounter <= 0)
        {
            spawnCounter = spawnTime;

            Instantiate(damager, damager.transform.position, Quaternion.identity, transform).gameObject.SetActive(true);
        }

        if (statsUpated)
        {
            statsUpated = false;
            SetStats();
        }
    }

    private void SetStats()
    {
        damager.attackInterval = weaponStats[weaponLevel].speed;

        damager.damagaAmount = weaponStats[weaponLevel].damage;

        damager.transform.localScale = Vector3.one * weaponStats[weaponLevel].range;

        spawnTime = weaponStats[weaponLevel].timeBetweenAAtacks;

        damager.Weaponstrength = weaponStats[weaponLevel].strength;

        damager.leftTime = weaponStats[weaponLevel].duration;


        spawnCounter = 0f;
    }
}
