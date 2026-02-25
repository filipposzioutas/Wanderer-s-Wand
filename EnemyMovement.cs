EnemyMovement.cs
using System.Collections;
using UnityEngine;

public class EnemyChase : MonoBehaviour
{
    public float moveSpeed = 5f; // Horizontal movement speed
    public float jumpForce = 10f; // Force applied for jumping
    public float detectionRange = 10f; // Range within which the enemy detects the player
    public LayerMask playerLayer; // Layer mask for the player
    public LayerMask obstacleLayer; // Layer mask for obstacles
    public float stopDuration = 1f; // Duration for which the enemy stops after touching the player

    private Rigidbody2D rb;
    private Transform player;
    private bool isFacingRight = true;
    private bool isStopped = false; // Flag to track if the enemy is stopped

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        // Check if the enemy is stopped, if so, return early
        if (isStopped)
            return;

        // Check if the player is within detection range
        if (Vector2.Distance(transform.position, player.position) <= detectionRange)
        {
            ChasePlayer();
        }
        else
        {
            StopChasing();
        }

        // Check if the enemy is stuck and needs to jump
        if (IsStuck())
        {
            Jump();
        }
    }

    void ChasePlayer()
    {
        // Determine direction to move
        float horizontalInput = player.position.x > transform.position.x ? 1f : -1f;

        // Move horizontally
        rb.velocity = new Vector2(horizontalInput * moveSpeed, rb.velocity.y);

        // Flip the enemy if necessary
        if ((horizontalInput < 0 && !isFacingRight) || (horizontalInput > 0 && isFacingRight))
        {
            Flip();
        }
    }

    void StopChasing()
    {
        rb.velocity = new Vector2(0f, rb.velocity.y);
    }

    bool IsStuck()
    {
        // Raycast downwards to detect obstacles below
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 1f, obstacleLayer);

        // Raycast forward to detect obstacles ahead
        RaycastHit2D hitForward = Physics2D.Raycast(transform.position, isFacingRight ? Vector2.right : Vector2.left, 0.5f, obstacleLayer);

        // If both raycasts hit obstacles, the enemy is stuck
        return hit.collider != null && hitForward.collider != null;
    }

    void Jump()
    {
        if (rb.velocity.x == 0){
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
    }
    }

    void Flip()
    {
        isFacingRight = !isFacingRight;
        transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Stop the enemy for the specified duration
            StartCoroutine(StopForDuration(stopDuration));
        }
    }

    IEnumerator StopForDuration(float duration)
    {
        isStopped = true;
        yield return new WaitForSeconds(duration);
        isStopped = false;
    }
}
