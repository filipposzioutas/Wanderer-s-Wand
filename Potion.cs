Potion.cs
using UnityEngine;

public class Potion : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<PolygonCollider2D>() != null)
        {
            Destroy(gameObject); // Destroy the object when it collides with an object with PolygonCollider2D
        }
    }
}
