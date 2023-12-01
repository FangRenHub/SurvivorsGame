using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float moveSpeed;

    public float attackInterval = 0.5f; 
    private float attackTimer = 0.0f;

    private GameObject player;
    private Rigidbody2D rb;
    private Vector3 direct;

    public float health = 5f;
    

    public float damage;
    // Start is called before the first frame update
    void Start()
    {
        player = PlayerHealthController.instance.gameObject;
        //player = GameObject.FindGameObjectWithTag("Player");
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        attackTimer += Time.deltaTime;
        if (player != null && player.activeSelf) 
        {
            direct = (player.transform.position - transform.position).normalized;
            direct.y -= 0.2f;
            rb.velocity = direct * moveSpeed;

            if (direct.y > 0.1f || direct.y < -0.1f)
            {
                if (direct.x < 0)
                    transform.GetComponent<SpriteRenderer>().flipX = true;
                else
                    transform.GetComponent<SpriteRenderer>().flipX = false;
            }

            if (player.transform.position.y > transform.position.y && direct.y > 0.2f)
                transform.GetComponent<SpriteRenderer>().sortingLayerName = "TopEnemy";
            else
                transform.GetComponent<SpriteRenderer>().sortingLayerName = "Enemy";
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("DisppearRect")){
            Destroy(this);
        }
    }



    private void OnTriggerStay2D(Collider2D collision)
    {
        if (attackTimer >= attackInterval && collision.gameObject.CompareTag("Player"))
        {
            PlayerHealthController.instance.TakeDamge(damage);
            attackTimer = 0.0f;
        }
        
    }

    public void TakeDamage(float damageToTake)
    {
        health -= damageToTake;
        if (health < 0.0f)
        {
            Destroy(gameObject);
        }
    }
 
}
