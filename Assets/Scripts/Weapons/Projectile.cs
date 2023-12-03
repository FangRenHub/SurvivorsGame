using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float moveSpeed;
    void Start()
    {
        
    }

    
    void Update()
    {
        transform.position += transform.up * moveSpeed * Time.deltaTime;
    }
}
