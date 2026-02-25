PlayerMovement.cs
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f; // Adjust this value to control movement speed
    public float jumpForce = 10f; // Adjust this value to control jump force

    public Animator animator; // Reference to the Animator component

    private Rigidbody2D rb;
    private bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Handle movement
        HandleMovement();

        // Handle jumping
        HandleJump();

        // Handle animations
        HandleAnimations();
    }

    void HandleMovement()
    {
        // Horizontal movement
        float moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);
    }

    void HandleAnimations()
    {
        // Update animator based on speed
        float speed = Mathf.Abs(rb.velocity.x);
        animator.SetFloat("Speed", speed);

        // Set jump animation parameter
        if (Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetBool("Jumpsan", true);
            animator.SetBool("Fallsan", false);
        }
        else
        {
            // Set fall animation parameter
            animator.SetBool("Fallsan", !isGrounded);
            animator.SetBool("Jumpsan", false);
        }
    }

    void HandleJump()
    {
        // Jumping
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            isGrounded = false;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if player is grounded
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
        // Check if player collides with enemies
        else if (collision.gameObject.CompareTag("Enemy"))
        {
            // Calculate knockback direction
            Vector2 knockbackDirection = transform.position - collision.transform.position;
            knockbackDirection = knockbackDirection.normalized;

            // Apply knockback to the player
            rb.velocity = knockbackDirection * 10f; // Adjust knockback force as needed
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        // Check if player leaves the ground
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}
