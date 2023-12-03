using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.WSA;

public class CloseAttackWeapon : Weapon
{
    public EnemyDamager damager;

    private SpriteRenderer playerFace;
    private float attackCounter;

    void Start()
    {
        SetStats();
        playerFace = PlayerController.instance.GetComponent<SpriteRenderer>();
    }

    
    void Update()
    {
        attackCounter -= Time.deltaTime;
        if (attackCounter <= 0)
        {
            attackCounter = weaponStats[weaponLevel].timeBetweenAAtacks;

            if (!playerFace.flipX)
                damager.transform.rotation = Quaternion.identity;
            else
                damager.transform.rotation = Quaternion.Euler(0f, 0f, 180f);
            float rotaZ = damager.transform.rotation.eulerAngles.z;
            Instantiate(damager, transform.position, Quaternion.Euler(0f, 0f, rotaZ), transform).gameObject.SetActive(true);

            for (int i = 1; i < weaponStats[weaponLevel].amount; i++)
            {
                float rot = (360f / weaponStats[weaponLevel].amount * i);
                if (weaponStats[weaponLevel].amount == 3)
                {
                    rot += 180f;
                }
                Instantiate(damager, transform.position, Quaternion.Euler(0f, 0f, rot + rotaZ), transform).gameObject.SetActive(true);
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

        damager.transform.localScale = Vector3.one * weaponStats[weaponLevel].range;

        attackCounter = weaponStats[weaponLevel].timeBetweenAAtacks;

        damager.Weaponstrength = weaponStats[weaponLevel].strength;


        attackCounter = 0f;
    }
}
