using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndVoiceOver : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip[] audioClips;

    void Start()
    {
        if (audioSource == null)
        {
            audioSource = GetComponent<AudioSource>();
        }
    }

    public void PlayClip(int clipIndex)
    {
        if (clipIndex >= 0 && clipIndex < audioClips.Length)
        {
            audioSource.clip = audioClips[clipIndex];
            audioSource.Play();
        }
        else
        {
            Debug.LogWarning("Clip index out of range");
        }
    }
}
