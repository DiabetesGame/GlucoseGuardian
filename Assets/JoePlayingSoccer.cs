using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoePlayingSoccer : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip[] audioClips;
    // Start is called before the first frame update
    void Start()
    {
        if (audioSource == null)
        {
            audioSource = GetComponent<AudioSource>();
        }
        if (!MyOptions.instance.quitGame)
        {
            StartCoroutine(RandomCheer());
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator RandomCheer()
    {
        int clipIndex = 0;
        while (true)
        {
            yield return new WaitForSeconds(10);
            audioSource.clip = audioClips[clipIndex];
            audioSource.Play();
            clipIndex++;
            if (clipIndex >= audioClips.Length) 
            { 
                clipIndex = 0; 
            }
        }
    }
}
