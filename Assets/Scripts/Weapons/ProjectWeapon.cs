using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements.Experimental;

public class ProjectWeapon : Weapon
{
    public EnemyDamager damager;
    public Projectile projectile;

    public float weaponRange;

    public LayerMask whatIsEnemy;

    private float shotCounter;
    void Start()
    {
        SetStats();
    }

    
    void Update()
    {
        shotCounter -= Time.deltaTime;
        if (shotCounter <= 0)
        {
            shotCounter = weaponStats[weaponLevel].timeBetweenAAtacks;
            Collider2D[] enemies = Physics2D.OverlapCircleAll(transform.position, weaponRange, whatIsEnemy);
            if(enemies.Length > 0)
            {
                for (int i = 0; i < weaponStats[weaponLevel].amount; i++)
                {
                    Vector3 targetPosition = enemies[Random.Range(0, enemies.Length)].transform.position;
                    Vector3 direction = targetPosition - transform.position;
                    float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                    angle -= 90;
                    projectile.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
                    Instantiate(projectile, projectile.transform.position, projectile.transform.rotation).gameObject.SetActive(true);
                }
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
        projectile.moveSpeed = weaponStats[weaponLevel].speed;

        damager.damagaAmount = weaponStats[weaponLevel].damage;

        weaponRange = weaponStats[weaponLevel].range;

        shotCounter = weaponStats[weaponLevel].timeBetweenAAtacks;

        damager.Weaponstrength = weaponStats[weaponLevel].strength;

        damager.leftTime = weaponStats[weaponLevel].duration;

        shotCounter = 0f;
    }
}
