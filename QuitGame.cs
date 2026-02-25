QuitGame.cs
using UnityEngine;

public class QuitGame : MonoBehaviour
{


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
