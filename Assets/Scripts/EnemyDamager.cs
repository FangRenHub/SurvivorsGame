using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamager : MonoBehaviour
{
    public float damagaAmount;
    public float Weaponstrength;
    public float leftTime;
    public bool isContinuous;

    public float growSpeed = 2f;
    private Vector3 targetSize;
    private Vector3 targetPosition;

    public float attackInterval = 20f;
    /*private bool canToAttck = false;
    private float damageCounter;    */
    
    void Start()
    {
        //damageCounter = attackInterval;
        targetPosition = transform.localPosition;
        targetSize = transform.localScale;
        transform.localScale = Vector3.zero;
        transform.localPosition = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        transform.localScale = Vector3.MoveTowards(transform.localScale, targetSize, growSpeed * Time.deltaTime);
        transform.localPosition = Vector3.MoveTowards(transform.localPosition, targetPosition, growSpeed * Time.deltaTime);
        leftTime -= Time.deltaTime;
        if(leftTime <= 0)
        {
            targetSize = Vector3.zero;
            targetPosition = Vector3.zero;
            if(transform.localScale.x == 0f && transform.localPosition.x == 0f)
            {
                Destroy(transform.parent.gameObject);
            }
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Enemy") && !isContinuous)
        {
            collision.GetComponent<EnemyController>().TakeDamage(damagaAmount, Weaponstrength);  
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy") && isContinuous)
        {
            collision.GetComponent<EnemyController>().TakeDamage(damagaAmount, Weaponstrength, attackInterval);
        }
    }



}
