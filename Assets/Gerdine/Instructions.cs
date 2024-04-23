using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Instructions : MonoBehaviour
{
    public GameObject firstCanvas; // Reference to the first canvas GameObject
    public GameObject secondCanvas; // Reference to the second canvas GameObject
   
    public GameObject buttonToEnable; // Reference to the button GameObject you want to enable

    void Start()
    {
        // Ensure that the first canvas is initially enabled
        firstCanvas.SetActive(true);
    }

    // Method to switch to the second canvas, start playing music, and disable the button
    public void ShowSecondCanvasAndDisableButton(GameObject buttonObject)
    {
        // Disable the first canvas
        firstCanvas.SetActive(false);

        // Enable the second canvas
        secondCanvas.SetActive(true);

        // Deactivate the button GameObject
        buttonObject.SetActive(false);

        // Enable the specified button
        if (buttonToEnable != null)
        {
            buttonToEnable.SetActive(true);
        }
    }
}

