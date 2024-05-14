using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class startTutorial : MonoBehaviour
{
    public AudioClip audioClip;
    public GameObject[] objectsToDisableOnClick;
    public GameObject[] objectsToEnableOnClick;

    private AudioSource audioSource;
    private bool audioClipPlayed = false;
    private float elapsedTime = 0f;
    private bool buttonEnabled = false;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
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
        if (buttonEnabled && elapsedTime < 20f)
        {
            elapsedTime += Time.deltaTime;
            if (elapsedTime >= 20f)
            {
                // Enable the button
                GetComponent<Button>().interactable = true;
            }
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

        // Disable the button
        GetComponent<Button>().interactable = false;
    }
}
