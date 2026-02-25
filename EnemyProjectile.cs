EnemyProjectile.cs
using UnityEngine;
using System.Collections;

public class EnemyShooter : MonoBehaviour
{
    public GameObject projectilePrefab; // Prefab of the projectile to be thrown
    public Transform throwPoint; // Point from where the projectile will be thrown
    public float throwForce = 10f; // Force applied to the projectile when thrown
    public float throwInterval = 2f; // Time interval between each throw
    public Animator animator; // Reference to the Animator component for playing the animation

    private Transform player; // Reference to the player's transform

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform; // Find the player's transform
        StartCoroutine(ShootAndAnimate());
    }

    IEnumerator ShootAndAnimate()
    {
        while (true)
        {
            ShootProjectile(); // Shoot projectile

            // Play animation
            if (animator != null)
            {
                animator.SetTrigger("shoot");
            }

            yield return new WaitForSeconds(throwInterval); // Wait for the specified interval before shooting again
        }
    }

    void ShootProjectile()
    {
        // Instantiate projectile at the throw point
        GameObject projectile = Instantiate(projectilePrefab, throwPoint.position, Quaternion.identity);

        // Calculate the direction towards the player
        Vector3 direction = (player.position - transform.position).normalized;

        // Apply force to the projectile in the calculated direction
        Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>(); // Changed to Rigidbody2D
        rb.AddForce(direction * throwForce, ForceMode2D.Impulse); // Changed to ForceMode2D
    }
}
