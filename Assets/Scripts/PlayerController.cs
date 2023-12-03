using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UIElements.Experimental;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;
    private void Awake()
    {
        instance = this;
    }

    public float moveSpeed;

    public float pickupRange = 1.5f;

    public int maxWeapons = 3;

    private Animator animator;
    private Vector3 moveInput;

    //public Weapon activeWeapon;
    public List<Weapon> unassignedWeapons, assignedWeapons;

    [HideInInspector]
    public List<Weapon> fullyLeveledWeapons = new List<Weapon>();

    void Start()
    {
        moveInput = new Vector3();
        animator = GetComponent<Animator>();

        if(assignedWeapons.Count == 0)
            AddWeapon(Random.Range(0, unassignedWeapons.Count));
    }

    
    void Update()
    {
        moveInput.Set(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0f);
        //rb.velocity = moveInput.normalized * moveSpeed * Time.deltaTime;
        transform.position +=
            moveInput.normalized
            * moveSpeed * Time.deltaTime;
        if (moveInput != Vector3.zero)
        {
            animator.SetFloat("Moving", moveInput.x);
            animator.SetBool("IsMoving", true);
        }
        else
        {
            animator.SetBool("IsMoving", false);
        }
    }

    public void AddWeapon(int weaponNumber)
    {
        if(weaponNumber < unassignedWeapons.Count)
        {
            assignedWeapons.Add(unassignedWeapons[weaponNumber]);
            unassignedWeapons[weaponNumber].gameObject.SetActive(true);
            unassignedWeapons.RemoveAt(weaponNumber);
        }
    }

    public void AddWeapon(Weapon weaponToAdd)
    {
        weaponToAdd.gameObject.SetActive(true);
        assignedWeapons.Add(weaponToAdd);
        unassignedWeapons.Remove(weaponToAdd);  
    }
}
