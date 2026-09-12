using System.Runtime.ConstrainedExecution;
using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Movimiento")]
    public float moveSpeed = 5f;

    [Header("Salto")]
    public float jumpForce = 10f;

    [Header("Detección del suelo")]
    public Transform groundCheck;
    public float groundCheckRadius = 0.2f;
    public LayerMask groundLayer;

    [Header("Efectos")]
    public ParticleSystem dust;

    private Rigidbody2D rb;
    private Animator animator;

    private float horizontalInput;
    private bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        
        horizontalInput = Input.GetAxisRaw("Horizontal");

        
        isGrounded = Physics2D.OverlapCircle(
            groundCheck.position,
            groundCheckRadius,
            groundLayer
        );


        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.linearVelocity = new Vector2(
                rb.linearVelocity.x,
                jumpForce
            );

            if (dust != null)
                dust.Play();

           
            animator.SetTrigger("Jump");
        }

      
        animator.SetBool(
            "IsRunning",
            Mathf.Abs(horizontalInput) > 0.01f
        );

        // Animator: caída
        animator.SetBool(
            "IsFalling",
            rb.linearVelocity.y < -0.1f && !isGrounded
        );
    }

    void FixedUpdate()
    {
        
        rb.linearVelocity = new Vector2(
            horizontalInput * moveSpeed,
            rb.linearVelocity.y
        );

        
        animator.SetFloat(
            "xVelocity",
            Mathf.Abs(rb.linearVelocity.x)
        );

        animator.SetFloat(
            "yVelocity",
            rb.linearVelocity.y
        );
    }

    private void OnDrawGizmosSelected()
    {
        if (groundCheck == null)
            return;

        Gizmos.color = Color.green;

        Gizmos.DrawWireSphere(
            groundCheck.position,
            groundCheckRadius
        );
    }
}
