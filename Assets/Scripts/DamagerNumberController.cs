using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using static UnityEditor.FilePathAttribute;

public class DamagerNumberController : MonoBehaviour
{
    public static DamagerNumberController instance;
    private void Awake()
    {
        instance = this;
    }

    public DamagerNumber numberToSpawn;
    public Transform numberCanvas;

    private List<DamagerNumber> numberList = new List<DamagerNumber>();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /*if(Input.GetKeyDown(KeyCode.D)) 
        {
            SpawnDamage(51f, new Vector3(3,2,0));
        }*/
    }
    public void SpawnDamage(float damageAmount, Vector3 location)
    {
        int rounded = Mathf.RoundToInt(damageAmount);

        //DamagerNumber newDamage = Instantiate(numberToSpawn, location, Quaternion.identity, numberCanvas);
        DamagerNumber newDamage = GetFromPool();
        
        newDamage.transform.position = location;
        newDamage.gameObject.SetActive(true);
        newDamage.Setup(rounded);
    }

    public DamagerNumber GetFromPool() 
    {
        DamagerNumber numberToOutPut = null;
        if(numberList.Count == 0) 
        {
            numberToOutPut = Instantiate(numberToSpawn, numberCanvas);
        }
        else
        {
            numberToOutPut = numberList[numberList.Count - 1];
            numberList.RemoveAt(numberList.Count - 1);
        }
        return numberToOutPut;
    }

    public void PlaceInPool(DamagerNumber numberInPlace)
    {
        numberInPlace.gameObject.SetActive(false);
        numberList.Add(numberInPlace);
    }
}
