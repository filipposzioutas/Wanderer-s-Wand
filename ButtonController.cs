using UnityEngine;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
    public Button switchButton; // Reference to the button that switches display
    public GameObject display1; // Reference to the first display
    public GameObject display2; // Reference to the second display

    void Start()
    {
        // Check if the switchButton reference is assigned
        if (switchButton != null)
        {
            // Add a listener to the button to call the SwitchDisplayAndRestartGame function when clicked
            switchButton.onClick.AddListener(SwitchDisplayAndRestartGame);
        }

        // Ensure one display is active at start
        if (display1 != null && display2 != null)
        {
            display1.SetActive(true);
            display2.SetActive(false);
        }
    }

    public void SwitchDisplayAndRestartGame()
    {
        // Toggle the active state of the displays
        if (display1 != null && display2 != null)
        {
            display1.SetActive(!display1.activeSelf);
            display2.SetActive(!display2.activeSelf);

            // Restart the game
            RestartGame();
        }
    }

    void RestartGame()
    {
        // Add your game reset logic here
        // For example, you can reset player position, score, etc.

        // For demonstration purposes, let's just log a message
        Debug.Log("Game restarted!");
    }
}
