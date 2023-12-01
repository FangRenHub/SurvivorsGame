using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinWeapon : MonoBehaviour
{
    public float SpinSpeed;
    public Transform holder, fireballToSpawn;
    public float timeBetweenSpawn;
    private float spawnCounter;
    //public float lifeTime;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Destroy(gameObject, lifeTime);
        holder.rotation = Quaternion.Euler(0f, 0f, holder.rotation.eulerAngles.z + (SpinSpeed * Time.deltaTime));

        spawnCounter -= Time.deltaTime;
        if (spawnCounter < 0)
        {
            spawnCounter = timeBetweenSpawn;
            Instantiate(fireballToSpawn, fireballToSpawn.position, fireballToSpawn.rotation, holder).gameObject.SetActive(true);
        }
    }
}
