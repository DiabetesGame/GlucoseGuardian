using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectDifficultyLevel : MonoBehaviour
{
    public AudioClip soundEffect; // Sound effect to be played
    public AudioSource audioSource; // Reference to the existing AudioSource component

    void Update()
    {
        // Check if the "H" key is pressed
        if (Input.GetKeyDown(KeyCode.D))
        {
            // Check if the AudioSource component is assigned
            if (audioSource != null)
            {
                // Assign the AudioClip to the AudioSource component
                audioSource.clip = soundEffect;

                // Play the sound effect
                audioSource.Play();
            }

        }
    }
}
