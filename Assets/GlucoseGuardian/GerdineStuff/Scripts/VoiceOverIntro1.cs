using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoiceOverIntro : MonoBehaviour
{
    public AudioClip[] audioClips; // Array of audio clips to play
    public GameObject[] objectsToEnable; // Objects to enable
    private AudioSource audioSource; // Audio source to play audio clips
    private int currentClipIndex = 0; // Index to track current audio clip

    void Start()
    {
        // Ensure AudioSource component is attached
        audioSource = GetComponent<AudioSource>();

        // Initially disable all objects
        foreach (GameObject obj in objectsToEnable)
        {
            obj.SetActive(false);
        }
    }

    void Update()
    {
        // Check if the current clip has finished playing
        if (!audioSource.isPlaying && currentClipIndex < audioClips.Length)
        {
            // Play the next clip
            PlayNextClip();
        }
    }

    void PlayNextClip()
    {
        if (currentClipIndex < audioClips.Length)
        {
            audioSource.clip = audioClips[currentClipIndex];
            audioSource.Play();
            currentClipIndex++;

            // Enable the corresponding object
            if (currentClipIndex - 1 < objectsToEnable.Length)
            {
                objectsToEnable[currentClipIndex - 1].SetActive(true);
            }
        }
        else
        {
            // If you want the sequence to loop, uncomment the next line
            // currentClipIndex = 0;

            // If you want to stop after the last clip, you can add your logic here
        }
    }
}
