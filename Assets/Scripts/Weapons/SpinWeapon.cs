using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinWeapon : Weapon
{
    public Transform holder, Controller;
    public float timeBetweenSpawn;
    public float rotateSpeed;

    private float spawnCounter;

    public EnemyDamager damager; 

    void Start()
    {
        SetStats();

        //UiController.instance.LvUpSelectionButtons[0].updataButtonDisplay(this); //useTest
    }

    void Update()
    {
        Controller.rotation = Quaternion.Euler(0f, 0f, Controller.rotation.eulerAngles.z + rotateSpeed * Time.deltaTime);


        spawnCounter -= Time.deltaTime;
        if (spawnCounter <= 0)
        {
            spawnCounter = timeBetweenSpawn;
            //Instantiate(holder, transform.position, transform.rotation , Controller).gameObject.SetActive(true);
            for(int i = 0; i < weaponStats[weaponLevel].amount; i++)
            {
                float rot = (360f / weaponStats[weaponLevel].amount * i);
                Instantiate(holder, transform.position, Quaternion.Euler(0f, 0f, rot), Controller).gameObject.SetActive(true);
                //Instantiate(damager.gameObject, damager.transform.position, Quaternion.Euler(0f, 0f, rot), holder).SetActive(true);
            }
        }

        if (statsUpated)
        {
            statsUpated = false;
            SetStats();
        }
    }

    public void SetStats()
    {
        rotateSpeed = weaponStats[weaponLevel].speed;

        damager.damagaAmount = weaponStats[weaponLevel].damage;

        damager.Weaponstrength = weaponStats[weaponLevel].strength;

        Controller.transform.localScale = Vector3.one * weaponStats[weaponLevel].range;
            
        timeBetweenSpawn = weaponStats[weaponLevel].timeBetweenAAtacks;

        damager.leftTime = weaponStats[weaponLevel].duration;
        
        spawnCounter = 0f;
    }
}
