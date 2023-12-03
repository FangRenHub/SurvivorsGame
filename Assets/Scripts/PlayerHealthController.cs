using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthController : MonoBehaviour
{
    public static PlayerHealthController instance;
    private void Awake()
    {
        instance = this;
    }
    
    public Slider healthSlider;
    public float currentHealth, maxHealth;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthSlider.maxValue = maxHealth;
        healthSlider.value = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        /*if(Input.GetKeyDown(KeyCode.T))
        {
            TakeDamge(10f);
        }*/
    }

    public void TakeDamge(float damageToTake)
    {
        currentHealth -= damageToTake;
        healthSlider.value = currentHealth;
        if (currentHealth <= 0)
        {
            gameObject.SetActive(false);
        }
    }
}
