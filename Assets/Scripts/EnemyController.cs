using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements.Experimental;

public class EnemyController : MonoBehaviour
{
    public float moveSpeed;

    public float attackInterval = 0.5f; 
    private float attackTimer = 0.0f;

    private GameObject player;
    private Rigidbody2D rb;
    private Vector3 direct;

    public float health = 5f;

    private float knockBack;
    private float knockBackCounter;
    private float takeDamageInterval;

    public float damage;

    public int expLevelToGive = 1;
    public int coinToGive = 1;
    public float coinDropRate = .3f;

    public GameObject hitEffect;
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
        if (!PlayerHealthController.instance.isAlive) return;
        if (knockBackCounter > 0)
        {
            knockBackCounter -= Time.deltaTime; 
            if (moveSpeed > 0)
                moveSpeed = moveSpeed * -knockBack;
            if (knockBackCounter < 0)
                moveSpeed = Mathf.Abs(moveSpeed / knockBack);
        }

        takeDamageInterval -= Time.deltaTime;
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
            ExperienceLevelController.Instance.SpawnExp(transform.position, expLevelToGive);
            if(Random.value <= coinDropRate)
            {
                CoinController.instance.DropCoin(transform.position, coinToGive);
            }
            SFXManager.instance.PlaySFXPitched(3);
        }
        else
        {
            SFXManager.instance.PlaySFXPitched(1);
        }
        Instantiate(hitEffect, transform.position, Quaternion.identity);
        DamagerNumberController.instance.SpawnDamage(damageToTake, transform.position);
    }

    public void TakeDamage(float damageToTake, float strenth)
    {
        
        TakeDamage(damageToTake);

        if(strenth > 0.0f)
        {
            knockBackCounter = 0.1f;
            knockBack = strenth;
        }
    }

    public void TakeDamage(float damageToTake, float strenth, float attackInterval)
    {
        if (takeDamageInterval <= 0)
        {
            TakeDamage(damageToTake);
        }
        else
        {
            return;
        }
        takeDamageInterval = attackInterval;

        if (strenth > 0.0f)
        {
            knockBackCounter = 0.1f;
            knockBack = strenth;
        }
    }

}

