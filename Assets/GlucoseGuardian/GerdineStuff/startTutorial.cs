using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class startTutorial : MonoBehaviour
{
    public AudioClip audioClip;
    public GameObject[] objectsToDisableOnClick;
    public GameObject[] objectsToEnableOnClick;
    public AudioSource audioSource;

    private bool audioClipPlayed = false;
    private bool buttonEnabled = false;

    void Awake()
    {
        audioSource.clip = audioClip;
        audioSource.Play();
    }

    void Update()
    {
        // Check if the audio clip has finished playing
        if (!audioClipPlayed && !audioSource.isPlaying)
        {
            audioClipPlayed = true;
            buttonEnabled = true;
        }

        // Enable the button after 20 seconds
        if (buttonEnabled)
        {
            // Enable the button
            GetComponent<Button>().interactable = true;
        }
    }

    public void ButtonClickHandler()
    {
        // Disable objectsToDisableOnClick and enable objectsToEnableOnClick
        foreach (GameObject obj in objectsToDisableOnClick)
        {
            obj.SetActive(false);
        }
        foreach (GameObject obj in objectsToEnableOnClick)
        {
            obj.SetActive(true);
        }

        // Enable the audio source
        audioSource.enabled = true;

        // Disable the button
        GetComponent<Button>().interactable = false;
    }
}