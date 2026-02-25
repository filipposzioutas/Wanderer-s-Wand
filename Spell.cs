Spell.cs
using System.Collections;
using UnityEngine;

public class Spell : MonoBehaviour
{
    public float speed = 20f;
    public Rigidbody2D rb;
    public int damage = 40;
    public float destroyDelay = 2f; // Delay before destroying the spell

    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * speed;
        StartCoroutine(DestroyAfterDelay());
    }

    IEnumerator DestroyAfterDelay()
    {
        yield return new WaitForSeconds(destroyDelay);
        Destroy(gameObject);
    }
}
