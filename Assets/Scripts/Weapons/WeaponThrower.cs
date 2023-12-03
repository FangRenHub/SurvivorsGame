using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponThrower : Weapon
{
    public EnemyDamager damager;

    private float throwCounter;
    
    void Start()
    {
        SetStats();
    }

    
    void Update()
    {
        throwCounter -= Time.deltaTime;
        if (throwCounter <= 0)
        {
            throwCounter = weaponStats[weaponLevel].timeBetweenAAtacks;
            for (int i = 0; i < weaponStats[weaponLevel].amount; i++)
            {
                Instantiate(damager, damager.transform.position, Quaternion.identity).gameObject.SetActive(true);
            }
        }

        if (statsUpated)
        {
            statsUpated = false;
            SetStats();
        }
    }

    private void SetStats()
    {
        damager.damagaAmount = weaponStats[weaponLevel].damage;

        //damager.leftTime = weaponStats[weaponLevel].duration;

        damager.transform.localScale = Vector3.one * weaponStats[weaponLevel].range;

        throwCounter = 0;
    }
}
