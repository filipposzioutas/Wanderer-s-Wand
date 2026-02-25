PlayerHealth.cs
// PlayerHealth.cs
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public Animator animator; // Reference to the Animator component
    public Text healthText; // Reference to the UI text element for displaying health

    void Start()
    {
        currentHealth = maxHealth;
        UpdateHealthDisplay();
    }

    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;
        UpdateHealthDisplay(); // Update health display when taking damage
        if (currentHealth <= 0)
        {
            Die();
        }
        else
        {
            // Trigger hurt animation
            animator.SetTrigger("hurt");
        }
    }

    public void Heal(int healAmount)
    {
        // Increase player's health by the healAmount
        currentHealth += healAmount;
        
        // Ensure that the player's health does not exceed the maximum health
        currentHealth = Mathf.Min(currentHealth, maxHealth);

        UpdateHealthDisplay(); // Update health display after healing
    }

    public int GetCurrentHealth()
    {
        return currentHealth;
    }

    void UpdateHealthDisplay()
    {
        healthText.text = "Health: " + currentHealth.ToString(); // Update UI text with current health
    }

    void Die()
    {
        // Handle player death (e.g., restart level, game over screen)
        Debug.Log("Player died!");
    }

/*    void OnCollisionEnter(Collision collision)
    {
        // Check if the object colliding with the player has the tag "Healing"
        if (collision.gameObject.CompareTag("Healing"))
        {
            // Get the HealingItem component of the healing object
            Potion potion = collision.gameObject.GetComponent<Potion>();

            // Check if the Potion component is found
            if (potion != null)
            {
                // Heal the player
                Heal(potion.healAmount); // Accessing healAmount from Potion script

                // Destroy the healing object
                Destroy(collision.gameObject);
            }
        }
    }*/
}
