using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
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

    private Animator animator;

    public GameObject beHitEffect;

    public GameObject deathEffect;

    public bool isAlive;
    
    void Start()
    {
        isAlive = true;
        maxHealth = PlayerStatController.instance.health[0].value;
        currentHealth = maxHealth;
        healthSlider.maxValue = maxHealth;
        healthSlider.value = maxHealth;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamge(float damageToTake)
    {
        currentHealth -= damageToTake;
        healthSlider.value = currentHealth;

        if (currentHealth <= 0 && isAlive)
        {
            isAlive = false;
            animator.Play("Death");
            foreach (Transform child in transform)
            {
                child.gameObject.SetActive(false);
            }
            //gameObject.SetActive(false);
            LevelManager.instance.EndLevel();
            Instantiate(deathEffect, transform.position, quaternion.identity).SetActive(true);
        }
        else
        {
            Instantiate(beHitEffect, transform.position, quaternion.identity).SetActive(true);
        }
    }

}
