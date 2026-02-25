ProjDMG.cs
using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour
{
    public int damageAmount = 10; // Amount of damage the projectile deals to the player
    public float destroyDelay = 2f; // Delay before destroying the projectile if it doesn't hit anything

    private bool hasHit = false; // Flag to track if the projectile has hit something

    void Start()
    {
        // Start a coroutine to destroy the projectile after the specified delay
        StartCoroutine(DestroyAfterDelay());
    }

    void OnCollisionEnter(Collision collision)
    {
        if (!hasHit && collision.gameObject.CompareTag("Player"))
        {
            // Reduce the player's health by the damage amount
            PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.currentHealth -= damageAmount;
            }

            // Set the hasHit flag to true to prevent multiple damage calculations
            hasHit = true;

            // Destroy the projectile after hitting the player
            Destroy(gameObject);
        }
    }

    IEnumerator DestroyAfterDelay()
    {
        yield return new WaitForSeconds(destroyDelay);

        // Destroy the projectile if it hasn't hit anything after the delay
        if (!hasHit)
        {
            Destroy(gameObject);
        }
    }
}
