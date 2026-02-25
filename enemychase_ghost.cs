enemychase_ghost.cs
using UnityEngine;

public class FlyingEnemy : MonoBehaviour
{
    public float moveSpeed = 5f; // Movement speed of the flying enemy
    public float detectionRange = 10f; // Range within which the enemy detects the player
    public float minDistance = 2f; // Minimum distance to maintain from the player
    public LayerMask playerLayer; // Layer mask for the player

    private Rigidbody2D rb;
    private Transform player;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player").transform;

        // Freeze rotation
        rb.freezeRotation = true;
    }

    void Update()
    {
        // Check if the player is within detection range
        if (Vector2.Distance(transform.position, player.position) <= detectionRange)
        {
            MoveTowardsPlayer();
        }
    }

void MoveTowardsPlayer()
{
    // Calculate direction towards the player
    Vector2 direction = (player.position - transform.position).normalized;

    // Move towards the player
    rb.velocity = direction * moveSpeed;

    // Calculate the angle in radians
    float angle = Mathf.Atan2(direction.y, direction.x);

    // Convert the angle to degrees
    float angleDegrees = angle * Mathf.Rad2Deg;

    // Limit rotation to only left or right (180 degrees)
    angleDegrees = Mathf.Clamp(angleDegrees, -90f, 90f);

    // Set the rotation only on the z-axis (horizontal) to face the player
    transform.rotation = Quaternion.Euler(0f, 0f, angleDegrees);

    // Keep the enemy's body vertical
    transform.eulerAngles = new Vector3(0, 0, 0);

    // Keep a minimum distance from the player
    if (Vector2.Distance(transform.position, player.position) < minDistance)
    {
        rb.velocity = Vector2.zero;
    }
}


}
