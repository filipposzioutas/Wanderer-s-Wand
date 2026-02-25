using UnityEngine;

public class PlayerSortingLayer : MonoBehaviour
{
    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        // Check player velocity
        float velocityX = rb.velocity.x;

        // Change sorting layer based on velocity
        if (velocityX < 0)
        {
            spriteRenderer.sortingLayerName = "Default";
        }
        else if (velocityX > 0)
        {
            spriteRenderer.sortingLayerName = "Player";
        }
    }
}
