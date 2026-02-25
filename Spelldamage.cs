Spelldamage.cs
using UnityEngine;

public class SpellDamage : MonoBehaviour
{
    private int damage = 20; // Default damage amount

    public void SetDamage(int amount)
    {
        damage = amount;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            // Apply damage to the enemy
            EnemyDamage enemy = other.GetComponent<EnemyDamage>();
            if (enemy != null)
            {
                enemy.TakeDamage(damage);
                Destroy(gameObject); // Destroy the spell after hitting the enemy
            }
        }
    }
}
