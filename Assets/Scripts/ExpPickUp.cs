using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements.Experimental;

public class ExpPickUp : MonoBehaviour
{
    public int expValue;
    public float moveSpeed;

    public bool movingToPlayer = false;
    private PlayerController player;

    /*private float timeBetweenChecks = 0.2f;
    private float checkCounter;*/

    public float RegressInTime = 0.5f;
    public float backwardDistance = 20f;

    // Start is called before the first frame update 
    void Start()
    {
        player = PlayerHealthController.instance.GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player == null) return;
        if (movingToPlayer)
        {
            RegressInTime -= Time.deltaTime;
            Vector3 targetDirection = -(player.transform.position - transform.position).normalized;
            Vector3 targetPosition = transform.position + targetDirection * backwardDistance;
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * 3 * Time.deltaTime * RegressInTime);
            if (RegressInTime < 0)
            {
                transform.position = Vector3.MoveTowards(transform.position, player.transform.position, (moveSpeed + player.moveSpeed) * Time.deltaTime);
            }
        }
        /*else
        {
            checkCounter -= Time.deltaTime;
            if (checkCounter <= 0)
            {
                checkCounter = timeBetweenChecks;
                if (Vector3.Distance(transform.position, player.transform.position) < player.pickupRange)
                {
                    movingToPlayer = true;
                    moveSpeed += player.moveSpeed;
                }
            }
        }*/
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            ExperienceLevelController.Instance.GetExp(expValue);
            Destroy(gameObject);
        }
        else if (collision.gameObject.name == "Pickup Controller")
        {
            movingToPlayer = true;
        }
    }


}
