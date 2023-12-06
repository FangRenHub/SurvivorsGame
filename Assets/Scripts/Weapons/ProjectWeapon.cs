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
                    //先计算原点与目标点的向量差，得出用Atan2转成相对X轴的弧度再的转为度数
                    //接着因为是以Z轴旋转且发射方向是transform.up，所以把相对Z轴的度数减去-90度得到相对与Z轴的旋转角度
                    Vector3 direction = targetPosition - transform.position;
                    float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                    //print(direction.y + "," + direction.x);
                    //print(angle);
                    angle -= 90;
                    //print("angle+90:" + angle);
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
