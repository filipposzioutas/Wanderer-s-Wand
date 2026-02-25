LeaveGame.cs
using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{
    // Define an AudioClip variable to hold the background music
    public AudioClip backgroundMusic;

    // Define an AudioSource variable to play the background music
    private AudioSource audioSource;

    // Use this for initialization
    void Start()
    {
        // Create a new AudioSource component and attach it to the GameObject
        audioSource = gameObject.AddComponent<AudioSource>();

        // Assign the background music clip to the AudioSource
        audioSource.clip = backgroundMusic;

        // Set the audio to loop
        audioSource.loop = true;

        // Play the background music
        audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        // Check if the Escape key is pressed
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // Quit the game
            Application.Quit();
        }
    }
}
