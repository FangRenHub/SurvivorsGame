using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamager : MonoBehaviour
{
    public float damagaAmount;
    public float leftTime, growSpeed = 5f;
    private Vector3 targetSize;
    private Vector3 targetPosition;
    /*public float attackInterval = 0.1f;
    private float attackTimer = 0.0f;*/
    // Start is called before the first frame update
    void Start()
    {
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
                Destroy(gameObject);
            }
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Enemy"))
        {
            collision.GetComponent<EnemyController>().TakeDamage(damagaAmount);  
        }
    }

}
