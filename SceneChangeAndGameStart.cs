SceneChangeAndGameStart.cs
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneChangeAndGameStart : MonoBehaviour
{
    public Button startButton; // Reference to the button that starts the game
    public string gameSceneName; // Name of the scene to load for the game

    void Start()
    {
        // Check if the startButton reference is assigned
        if (startButton != null)
        {
            // Add a listener to the button to call the StartGame function when clicked
            startButton.onClick.AddListener(StartGame);
        }
    }

    void StartGame()
    {
        // Load the game scene
        SceneManager.LoadScene(gameSceneName);
    }
}
