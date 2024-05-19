using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class VoiceOverIntro : MonoBehaviour
{
    public AudioClip[] audioClips; // Array of audio clips to play
    public GameObject[] objectsToEnable; // Objects to enable after all clips are played
    public GameObject[] objectsToDisable; // Objects to disable after all clips are played
    private AudioSource audioSource; // Audio source to play audio clips
    private int currentClipIndex = 0; // Index to track current audio clip

    void Start()
    {
        // Ensure AudioSource component is attached
        audioSource = GetComponent<AudioSource>();

        // Initially disable all objects to be enabled
        foreach (GameObject obj in objectsToEnable)
        {
            obj.SetActive(false);
        }

        // Initially enable all objects to be disabled
        foreach (GameObject obj in objectsToDisable)
        {
            obj.SetActive(true);
        }

        // Start playing the first clip
        if (audioClips.Length > 0)
        {
            PlayNextClip();
        }
    }

    void Update()
    {
        // Check if the current clip has finished playing
        if (!audioSource.isPlaying && currentClipIndex < audioClips.Length)
        {
            PlayNextClip();
        }
        else if (!audioSource.isPlaying && currentClipIndex >= audioClips.Length)
        {
            // All clips have finished playing
            EnableDisableObjects();
        }
    }

    void PlayNextClip()
    {
        if (currentClipIndex < audioClips.Length)
        {
            audioSource.clip = audioClips[currentClipIndex];
            audioSource.Play();
            currentClipIndex++;
        }
    }

    void EnableDisableObjects()
    {
        // Enable the specified objects
        foreach (GameObject obj in objectsToEnable)
        {
            obj.SetActive(true);
        }

        // Disable the specified objects
        foreach (GameObject obj in objectsToDisable)
        {
            obj.SetActive(false);
        }
    }
}