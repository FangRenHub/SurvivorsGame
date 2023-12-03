using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamager : MonoBehaviour
{
    public float damagaAmount;

    public float Weaponstrength;

    public float leftTime;

    public float growSpeed = 2f;

    public float attackInterval = -1f;

    public bool isContinuous;

    public bool destroyOnImpact;


    private Vector3 targetSize;
    private Vector3 targetPosition;

    private bool haveAnime;
    /*private bool canToAttck = false;
    private float damageCounter;    */

    void Start()
    {
        
        targetPosition = transform.localPosition;
        targetSize = transform.localScale;
        if (gameObject.CompareTag("SpawnAnimationWeapon"))
        {
            haveAnime = true;
            transform.localScale = Vector3.zero;
            transform.localPosition = Vector3.zero;
        }    
    }

    // Update is called once per frame
    void Update()
    {
        if (haveAnime)
        {
            transform.localScale = Vector3.MoveTowards(transform.localScale, targetSize, growSpeed * Time.deltaTime);
            transform.localPosition = Vector3.MoveTowards(transform.localPosition, targetPosition, growSpeed * Time.deltaTime);
        }
        
        leftTime -= Time.deltaTime;
        if(leftTime <= 0)
        {
            destroyWeapon(haveAnime);  
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Enemy") && !isContinuous)
        {
            collision.GetComponent<EnemyController>().TakeDamage(damagaAmount, Weaponstrength);
            if(destroyOnImpact)
            {
                Destroy(gameObject);
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy") && isContinuous)
        {
            collision.GetComponent<EnemyController>().TakeDamage(damagaAmount, Weaponstrength, attackInterval);
        }
    }

    public void destroyWeapon(bool haveAnime)
    {
        if(haveAnime)
        {
            targetSize = Vector3.zero;
            targetPosition = Vector3.zero;
            if (transform.localScale.x == 0f && transform.localPosition.x == 0f)
            {
                if (transform.parent != null && transform.parent.CompareTag("WeaponHolder"))
                    Destroy(transform.parent.gameObject);
                else
                    Destroy(gameObject);
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }

}
