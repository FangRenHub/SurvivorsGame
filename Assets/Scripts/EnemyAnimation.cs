using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimation : MonoBehaviour
{
    public float Rotaspeed;
    public float minRota, maxRota;
    private int activeRota;
    // Start is called before the first frame update
    void Start()
    {
        activeRota = -1;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.forward * Rotaspeed * activeRota * Time.deltaTime * Random.Range(.1f, 1.9f));
        if (transform.rotation.z > maxRota)
            activeRota = -1;
        else if(transform.rotation.z < minRota) 
            activeRota = 1;
    }
}
