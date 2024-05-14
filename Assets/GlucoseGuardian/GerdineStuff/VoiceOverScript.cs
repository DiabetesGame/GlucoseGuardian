using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AudioManager : MonoBehaviour
{
    public AudioClip[] clips;
    public GameObject[] objectsToAppearClip1;
    public GameObject[] objectsToAppearClip3;
    public GameObject[] objectsToAppearClip4;
    public Renderer[] objectsToChangeMaterialClip2;
    public Renderer[] objectsToChangeMaterialClip4;
    public Material[] materialsClip2;
    public Material[] materialsClip4;
    public Animation[] animations;
    private AudioSource audioSource;
    private int currentIndex = 0;
    private bool clip3ObjectsActivated = false;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        StartCoroutine(PlayAudioSequence());
    }

    IEnumerator PlayAudioSequence()
    {
        while (currentIndex < clips.Length)
        {
            audioSource.clip = clips[currentIndex];
            audioSource.Play();

            // Clip specific actions
            switch (currentIndex)
            {
                case 0: // Clip 1: Object 0 appears
                    foreach (GameObject obj in objectsToAppearClip1)
                    {
                        obj.SetActive(true);
                    }
                    break;
                case 2: // Clip 3: Objects 1, 2, 3 appear
                    StartCoroutine(DelayedClip3ObjectAppearance());
                    break;
                case 3: // Clip 4: Object 4 appears
                    foreach (GameObject obj in objectsToAppearClip4)
                    {
                        obj.SetActive(true);
                    }
                    break;
                case 1: // Clip 2: Change material on specific objects
                    if (materialsClip2.Length > 0 && objectsToChangeMaterialClip2.Length > 0)
                    {
                        for (int i = 0; i < objectsToChangeMaterialClip2.Length; i++)
                        {
                            if (i < materialsClip2.Length)
                            {
                                objectsToChangeMaterialClip2[i].material = materialsClip2[i];
                            }
                        }
                    }
                    break;
                case 4: // Clip 5: Change material on specific objects
                    if (materialsClip4.Length > 0 && objectsToChangeMaterialClip4.Length > 0)
                    {
                        for (int i = 0; i < objectsToChangeMaterialClip4.Length; i++)
                        {
                            if (i < materialsClip4.Length)
                            {
                                objectsToChangeMaterialClip4[i].material = materialsClip4[i];
                            }
                        }
                    }
                    break;
                case 5: // Clip 6: Play animation sequence
                    foreach (Animation anim in animations)
                    {
                        anim.Play();
                    }
                    break;
            }

            yield return new WaitForSeconds(audioSource.clip.length);
            currentIndex++;
        }

        // All clips played, do something
    }

    IEnumerator DelayedClip3ObjectAppearance()
    {
        yield return new WaitForSeconds(audioSource.clip.length / 2f); // Delay appearance halfway through the clip
        if (!clip3ObjectsActivated)
        {
            clip3ObjectsActivated = true;
            foreach (GameObject obj in objectsToAppearClip3)
            {
                obj.SetActive(true);
            }
        }
    }
}






















/*{
    public AudioClip[] clips;
    private AudioSource audioSource;
    private int currentIndex = 0;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        StartCoroutine(PlayAudioSequence());
    }

    IEnumerator PlayAudioSequence()
    {
        while (currentIndex < clips.Length)
        {
            audioSource.clip = clips[currentIndex];
            audioSource.Play();
            yield return new WaitForSeconds(audioSource.clip.length);
            currentIndex++;
        }

        // All clips played, do something
    }
}
*/