using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class VoiceOverIntro2 : MonoBehaviour
{
    public AudioClip[] clips;
    public GameObject[] objectsToAppearClip1;
    public GameObject[] objectsToAppearClip2;
    public GameObject[] objectsToAppearClip3;
    public GameObject[] objectsToAppearClip4;
    public GameObject[] objectsToAppearClip5;
    public GameObject[] objectsToDisableAtEnd; // New array for objects to disable
    public GameObject[] objectsToEnableAtEnd;  // New array for objects to enable
    public Renderer[] objectsToChangeMaterialClip2;
    public Renderer[] objectsToChangeMaterialClip4;
    public Material[] materialsClip2;
    public Material[] materialsClip4;
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

            switch (currentIndex)
            {
                case 0: // Clip 1: Object 0 appears
                    ActivateObjects(objectsToAppearClip1);
                    break;
                case 1: // Clip 2: Objects 1 appear with a 10-second delay
                    StartCoroutine(DelayedObjectsAppearance(objectsToAppearClip2, 10f, 5f)); // Initial delay of 10 seconds, interval of 5 seconds
                    ChangeMaterial(objectsToChangeMaterialClip2, materialsClip2);
                    break;
                case 2: // Clip 3: Objects 2, 3 appear
                    StartCoroutine(DelayedObjectsAppearance(objectsToAppearClip3, 0f, 2f)); // Initial delay of 0 seconds, interval of 2 seconds
                    break;
                case 3: // Clip 4: Objects 4 appear
                    StartCoroutine(DelayedObjectAppearance(objectsToAppearClip4[0], 5f)); // Add a delay of 5 seconds
                    StartCoroutine(DelayedObjectAppearance(objectsToAppearClip4[1], 15f)); // Add a delay of 15 seconds for the second object
                    StartCoroutine(DelayedMaterialChange(objectsToChangeMaterialClip4, materialsClip4, 15f)); // Add a delay of 15 seconds for material change
                    break;
                case 4: // Clip 5: Objects 5 appear
                    StartCoroutine(DelayedObjectsAppearance(objectsToAppearClip5, 5f, 5f)); // Initial delay of 5 seconds, interval of 5 seconds
                    break;
            }

            yield return new WaitForSeconds(audioSource.clip.length);
            currentIndex++;
        }
    }

    void Update()
    {
        // Check if all clips have been played and perform actions accordingly
        if (currentIndex >= clips.Length)
        {
            DisableObjects(objectsToDisableAtEnd);
            ActivateObjects(objectsToEnableAtEnd);
        }
    }

    IEnumerator DelayedObjectsAppearance(GameObject[] objects, float initialDelay, float interval)
    {
        yield return new WaitForSeconds(initialDelay);
        foreach (GameObject obj in objects)
        {
            obj.SetActive(true);
            yield return new WaitForSeconds(interval);
        }
    }

    IEnumerator DelayedObjectAppearance(GameObject obj, float delay)
    {
        yield return new WaitForSeconds(delay);
        obj.SetActive(true);
    }

    IEnumerator DelayedMaterialChange(Renderer[] objects, Material[] materials, float delay)
    {
        yield return new WaitForSeconds(delay);
        ChangeMaterial(objects, materials);
    }

    void ActivateObjects(GameObject[] objects)
    {
        foreach (GameObject obj in objects)
        {
            obj.SetActive(true);
        }
    }

    void DisableObjects(GameObject[] objects)
    {
        foreach (GameObject obj in objects)
        {
            obj.SetActive(false);
        }
    }

    void ChangeMaterial(Renderer[] objects, Material[] materials)
    {
        if (materials.Length > 0 && objects.Length > 0)
        {
            for (int i = 0; i < objects.Length; i++)
            {
                if (i < materials.Length)
                {
                    objects[i].material = materials[i];
                }
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