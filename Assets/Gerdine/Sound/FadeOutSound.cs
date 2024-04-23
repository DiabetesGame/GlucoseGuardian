using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeOutSound : MonoBehaviour
{
    public AudioClip soundEffect; // Sound effect to be played
    public AudioSource audioSource; // Reference to the existing AudioSource component
    private float fadeDuration = 10f; // Duration over which to fade out the sound
    public float minVolume = 0.05f; // Minimum volume to fade down to

    void Start()
    {
        // Assign the AudioClip to the existing AudioSource component
        audioSource.clip = soundEffect;

        // Play the sound effect
        audioSource.Play();

        // Start fading out the sound effect after 10 seconds
        StartCoroutine(FadeOut());
    }

    IEnumerator FadeOut()
    {
        // Wait for 10 seconds before starting the fade out
        yield return new WaitForSeconds(10f);

        // Get the initial volume
        float startVolume = audioSource.volume;

        // Calculate the rate at which the volume should decrease per second
        float fadeSpeed = (startVolume - minVolume) / fadeDuration;

        // Gradually decrease the volume over the fade duration
        while (audioSource.volume > minVolume)
        {
            audioSource.volume -= fadeSpeed * Time.deltaTime;
            yield return null;
        }

        // Ensure the volume is set to the minimum volume
        audioSource.volume = minVolume;
    }
}