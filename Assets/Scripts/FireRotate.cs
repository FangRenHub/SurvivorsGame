using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireRoate : MonoBehaviour
{
    public float rotationSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 currentRotation = transform.rotation.eulerAngles;
        float newZRotation = currentRotation.z + rotationSpeed * Time.deltaTime;
        transform.rotation = Quaternion.Euler(currentRotation.x, currentRotation.y, newZRotation);
    }
}

