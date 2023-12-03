using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements.Experimental;

public class ExpPickUp : MonoBehaviour
{
    public int expValue;
    public float moveSpeed;

    private bool movingToPlayer = false;
    private PlayerController player;

    private float timeBetweenChecks = 0.2f;
    private float checkCounter;

    // Start is called before the first frame update 
    void Start()
    {
        player = PlayerHealthController.instance.GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player.gameObject == null) return;
        if (movingToPlayer)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, moveSpeed * Time.deltaTime);
        }
        else
        {
            checkCounter -= Time.deltaTime;
            if (checkCounter <= 0)
            {
                checkCounter = timeBetweenChecks;
                if(Vector3.Distance(transform.position, player.transform.position) < player.pickupRange)
                {
                    movingToPlayer = true;
                    moveSpeed += player.moveSpeed;
                }   
            } 
        }
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if  (collision.CompareTag("Player"))
        {
            ExperienceLevelController.Instance.GetExp(expValue);
            Destroy(gameObject);
        }
    }


}
