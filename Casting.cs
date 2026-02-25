using System.Collections;
using UnityEngine;

public class Casting : MonoBehaviour
{
    public Transform Magic;
    public GameObject SpellPrefab;
    public Animator animator;
    public int spellDamage = 20; // Damage amount of the spell

    private bool canShoot = true; // Flag to control shooting cooldown

    void Update()
    {
        if (canShoot && Input.GetButtonDown("Fire1"))
        {
            animator.SetTrigger("shoot");
            Shoot();
            canShoot = false; // Disable shooting temporarily
            StartCoroutine(ShootCooldown());
        }
    }

    void Shoot()
    {
        GameObject spellObject = Instantiate(SpellPrefab, Magic.position, Magic.rotation);
        SpellDamage spell = spellObject.GetComponent<SpellDamage>();
        if (spell != null)
        {
            spell.SetDamage(spellDamage); // Set the damage of the spell
        }
    }

    IEnumerator ShootCooldown()
    {
        yield return new WaitForSeconds(0.6f); // Adjust the cooldown time here
        canShoot = true; // Enable shooting after cooldown
    }
}
