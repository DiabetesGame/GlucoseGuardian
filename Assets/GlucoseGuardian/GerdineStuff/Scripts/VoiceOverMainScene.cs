using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoiceOverMainScene : MonoBehaviour
{
    public AudioClip[] audioClips; // Array of audio clips
    public float interval = 30.0f; // Interval in seconds
    public ScoreBoard scoreBoard; // Reference to the ScoreBoard script

    private AudioSource audioSource;
    private float nextPlayTime;

    void Start()
    {
        // Add an AudioSource component to the GameObject this script is attached to
        audioSource = gameObject.AddComponent<AudioSource>();

        // Set the initial next play time
        nextPlayTime = Time.time + interval;

        // Start the coroutine to play random audio clips
        StartCoroutine(PlayRandomAudio());
    }

    IEnumerator PlayRandomAudio()
    {
        // Continue as long as the timer is running
        while (scoreBoard != null && scoreBoard.IsTimerRunning())
        {
            // Check if it's time to play the next audio clip
            if (Time.time >= nextPlayTime)
            {
                // Select a random audio clip from the array
                int index = Random.Range(0, audioClips.Length);
                audioSource.clip = audioClips[index];

                // Play the selected audio clip
                audioSource.Play();

                // Update the next play time
                nextPlayTime = Time.time + interval;
            }

            // Wait until the next frame before checking again
            yield return null;
        }
    }
}
