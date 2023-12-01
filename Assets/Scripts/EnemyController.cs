using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float moveSpeed;
    private GameObject player;
    private Rigidbody2D rb;
    private Vector3 direct;

    public float damage;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        direct = (player.transform.position - transform.position).normalized;
        rb.velocity = direct * moveSpeed;

        if(direct.y > 0.1f || direct.y < -0.1f)
        {
            if(direct.x < 0)
                transform.GetComponent<SpriteRenderer>().flipX = true;
            else
                transform.GetComponent<SpriteRenderer>().flipX = false;
        }

        if(player.transform.position.y > transform.position.y && direct.y > 0.2f)
            transform.GetComponent<SpriteRenderer>().sortingLayerName = "TopEnemy";
        else
            transform.GetComponent<SpriteRenderer>().sortingLayerName = "Enemy";
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerHealthController.instance.TakeDamge(damage);
        }
    }
 
}
