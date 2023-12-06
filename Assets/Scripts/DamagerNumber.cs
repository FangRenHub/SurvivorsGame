using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DamagerNumber : MonoBehaviour
{
    public TMP_Text damageText;

    public float lifeTime;
    public float dispSpeed;
    private float lifeCounter;
    private Vector3 tempScale;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        lifeCounter -= Time.deltaTime;
        
        if (lifeCounter < 0)
        {
            transform.localScale = Vector3.MoveTowards(transform.localScale, Vector3.zero, dispSpeed * Time.deltaTime);
            if (transform.localScale.x == 0)
            {
                DamagerNumberController.instance.PlaceInPool(this);
                transform.localScale = tempScale;
            }
        }
        
    }

    public void Setup(int DamageNum)
    {
        tempScale = transform.localScale;
        lifeCounter = lifeTime;
        damageText.text = DamageNum.ToString();
    }
}
