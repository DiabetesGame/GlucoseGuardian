using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuckedInTrigger : MonoBehaviour
{
    public AudioClip soundEffect; // Sound effect to be played
    private AudioSource audioSource; // Reference to the AudioSource component

    void Start()
    {
        // Get the AudioSource component attached to the same GameObject
        audioSource = GetComponent<AudioSource>();

        // Check if AudioSource component exists, if not, add one
        if (audioSource == null)
        {
            // Add an AudioSource component to this GameObject
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        // Assign the AudioClip to the AudioSource component
        audioSource.clip = soundEffect;
    }

    // OnTriggerEnter is called when the Collider other enters the trigger
    void OnTriggerEnter(Collider other)
    {
        // Log to see if OnTriggerEnter is being called
        Debug.Log("Trigger entered");

        // Play the sound effect when anything enters the trigger zone
        audioSource.Play();
    }
}