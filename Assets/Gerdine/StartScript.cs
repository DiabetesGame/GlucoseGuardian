using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartScript : MonoBehaviour
{
    public GameObject UICanvas; // Reference to the first canvas GameObject
    public AudioSource musicPlayer; // Reference to the AudioSource component for playing music
    public GameObject buttonToEnable; // Reference to the button GameObject you want to enable

    void Start()
    {
        // Ensure that the first canvas is initially enabled
        UICanvas.SetActive(true);
    }

    // Method to switch to the second canvas, start playing music, and disable the button
    public void ShowSecondCanvasAndDisableButton(GameObject buttonObject)
    {
        // Disable the first canvas
        UICanvas.SetActive(false);


        // Start playing music
        if (musicPlayer != null)
        {
            musicPlayer.Play();
        }

        // Deactivate the button GameObject
        buttonObject.SetActive(false);

        // Enable the specified button
        if (buttonToEnable != null)
        {
            buttonToEnable.SetActive(true);
        }
    }
}