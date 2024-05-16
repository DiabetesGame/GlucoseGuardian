using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoiceOverIntro : MonoBehaviour
{
    public AudioClip[] audioClips;
    private AudioSource audioSource;
    private int currentClipIndex = 0;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        // Start playing the first audio clip
        PlayNextClip();
    }

    void PlayNextClip()
    {
        if (currentClipIndex < audioClips.Length)
        {
            audioSource.clip = audioClips[currentClipIndex];
            audioSource.Play();
            currentClipIndex++;
        }
        else
        {
            // If you want the sequence to loop, uncomment the next line
            // currentClipIndex = 0;

            // If you want to stop after the last clip, you can add your logic here
        }
    }

    void Update()
    {
        // Check if the current clip has finished playing
        if (!audioSource.isPlaying)
        {
            // Play the next clip
            PlayNextClip();
        }
    }
}
