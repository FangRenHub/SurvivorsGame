using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowWeapon : MonoBehaviour
{
    public float throwPower;
    public float spinSpeed;

    private Rigidbody2D theRB;
    void Start()
    {
        theRB = GetComponent<Rigidbody2D>();
        theRB.velocity = new Vector2(Random.Range(-throwPower, throwPower), throwPower * 2);
    }

    
    void Update()
    {
        transform.rotation = Quaternion.Euler(0f, 0f, transform.rotation.eulerAngles.z + (spinSpeed * 360f * Time.deltaTime * Mathf.Sign(theRB.velocity.x)));
    }
}
