using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AudioManager : MonoBehaviour
{
    public AudioClip[] clips;
    public GameObject[] objectsToAppearClip1;
    public GameObject[] objectsToAppearClip2;
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
                    ActivateObjects(objectsToAppearClip1);
                    break;
                case 1: // Clip 2: Object 1 appears
                    StartCoroutine(DelayedObjectAppearance(objectsToAppearClip2, 5f));
                    ChangeMaterial(objectsToChangeMaterialClip2, materialsClip2);
                    break;
                case 2: // Clip 3: Objects 2, 3 appear
                    StartCoroutine(DelayedClip3ObjectAppearance());
                    break;
                case 3: // Clip 4: Object 4 appears
                    ActivateObjects(objectsToAppearClip4);
                    ChangeMaterial(objectsToChangeMaterialClip4, materialsClip4);
                    break;
                case 4: // Clip 5: Change material on specific objects
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
            ActivateObjects(objectsToAppearClip3);
        }
    }

    IEnumerator DelayedObjectAppearance(GameObject[] objects, float delay)
    {
        yield return new WaitForSeconds(delay);
        ActivateObjects(objects);
    }

    void ActivateObjects(GameObject[] objects)
    {
        foreach (GameObject obj in objects)
        {
            obj.SetActive(true);
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