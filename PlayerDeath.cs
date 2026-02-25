PlayerDeath.cs
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections; // Add this line to import IEnumerator

public class HealthAndSceneChange : MonoBehaviour
{
    public Animator animator; // Reference to the animator component for the death animation
    public float transitionTime = 1f; // Time to wait before transitioning to the next scene
    public string nextSceneName; // Name of the scene to load after the animation plays

    private bool isTransitioning = false; // Flag to prevent multiple scene transitions

    void Update()
    {
        // Get reference to the GameObject with PlayerHealth script attached
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            PlayerHealth playerHealth = player.GetComponent<PlayerHealth>();

            // Check if the player's health is 0 or lower
            if (playerHealth.GetCurrentHealth() <= 0 && !isTransitioning)
            {
                // Start the death animation
                animator.SetTrigger("dead");

                // Start coroutine to transition to the next scene after the animation plays
                StartCoroutine(TransitionToNextScene());
            }
        }
    }

    IEnumerator TransitionToNextScene()
    {
        // Set flag to prevent multiple scene transitions
        isTransitioning = true;

        // Wait for the animation to play
        yield return new WaitForSeconds(transitionTime);

        // Load the next scene
        SceneManager.LoadScene(nextSceneName);
    }
}
