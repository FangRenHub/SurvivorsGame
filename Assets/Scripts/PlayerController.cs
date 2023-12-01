using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    private Animator animator;
    private Vector3 moveInput;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        moveInput = new Vector3();
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        moveInput.Set(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0f);
        /*rb.velocity = moveInput.normalized * moveSpeed * Time.deltaTime;*/
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
}
