using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextScript : MonoBehaviour
{
    public GameObject secondCanvas; // Reference to the second canvas GameObject
    public GameObject thirdCanvas; // Reference to the third canvas GameObject

    // Method to switch to the third canvas and disable the second canvas
    public void ShowThirdCanvasAndDisableSecond(GameObject buttonObject)
    {
        // Disable the second canvas
        secondCanvas.SetActive(false);

        // Enable the third canvas
        thirdCanvas.SetActive(true);

        // Deactivate the button GameObject
        buttonObject.SetActive(false);
    }
}
