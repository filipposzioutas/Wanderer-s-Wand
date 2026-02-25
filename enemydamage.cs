enemydamage.cs
using UnityEngine;
using System.Collections;

public class EnemyDamage : MonoBehaviour
{
    public int maxHealth = 100; // Maximum health of the enemy
    private int enemyHealth; // Current health of the enemy
    public int damageAmount = 20; // Damage amount
    public Animator animator; // Reference to the Animator component
    public float delayBeforeDestroy = 2f; // Delay before destroying the enemy object

    void Start()
    {
        enemyHealth = maxHealth; // Set current health to maximum health at the start
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Apply damage to the player
            PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damageAmount);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Spell"))
        {
            // Apply damage to the enemy when hit by a spell
            Spell spell = other.GetComponent<Spell>();
            if (spell != null)
            {
                TakeDamage(spell.damage);
                Destroy(other.gameObject); // Destroy the spell after hitting the enemy
            }
        }
    }

    public void TakeDamage(int amount)
    {
        enemyHealth -= amount; // Decrease current health by the specified amount

        if (enemyHealth <= 0)
        {
            Die(); // Enemy dies if health reaches zero or below
        }
    }

    IEnumerator DestroyAfterDelay()
    {
        yield return new WaitForSeconds(delayBeforeDestroy); // Wait for the specified delay
        Destroy(gameObject); // Destroy the enemy object
    }

    void Die()
    {
        Debug.Log("Enemy died"); // Display "Enemy died" message     
        animator.SetTrigger("dead");
        
        // Start coroutine to destroy the object after a delay
        StartCoroutine(DestroyAfterDelay());
    }
}
