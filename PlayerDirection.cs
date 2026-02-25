PlayerDirection.cs
using UnityEngine;

public class PlayerDirection : MonoBehaviour
{
    private Transform playerTransform;

    void Start()
    {
        playerTransform = GetComponent<Transform>();
    }

    void Update()
    {
        // Horizontal movement
        float moveInput = Input.GetAxis("Horizontal");

        // Rotate character when moving left
        if (moveInput < 0)
        {
            playerTransform.rotation = Quaternion.Euler(0f, 180f, 0f); // Rotate 180 degrees around the Y-axis
        }
        // Rotate character back when moving right
        else if (moveInput > 0)
        {
            playerTransform.rotation = Quaternion.Euler(0f, 0f, 0f); // No rotation (original rotation)
        }
    }
}
