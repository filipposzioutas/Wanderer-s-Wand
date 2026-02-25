using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    // Define the name of the scene to load
    public string sceneToLoad;

    // Define a method to detect collisions with triggers
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the colliding object is the player
        if (other.CompareTag("Player"))
        {
            // Call a method to perform any necessary actions before changing the scene
            // For example, saving game progress, displaying messages, etc.
            PreSceneChangeActions();

            // Load the new scene
            SceneManager.LoadScene(sceneToLoad);
        }
    }

    // Method to perform any necessary actions before changing the scene
    private void PreSceneChangeActions()
    {
        // Perform actions such as saving game progress, displaying messages, etc.
        Debug.Log("Preparing to change scene...");
    }
}
