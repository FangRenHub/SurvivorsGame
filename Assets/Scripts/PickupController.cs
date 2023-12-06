using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupController : MonoBehaviour
{
    public static PickupController instance;
    private void Awake()
    {
        instance = this;
    }

    private CircleCollider2D Collider;

    private void Start()
    {
        Collider = GetComponent<CircleCollider2D>();
        setRange(PlayerStatController.instance.pickupRange[0].value);
    }

    public void setRange(float newRadius)
    {
        Collider.radius = newRadius;
    }

    /*private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Pickup"))
        {
            collision.gameObject.GetComponent<Pickup>().movingToPlayer = true;
        }
    }*/




}
