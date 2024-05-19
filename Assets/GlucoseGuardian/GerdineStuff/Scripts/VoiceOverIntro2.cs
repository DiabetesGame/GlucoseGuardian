using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoiceOverIntro2 : MonoBehaviour
{
    public AudioClip[] clips;
    public GameObject[] objectsToAppearClip1;
    public GameObject[] objectsToAppearClip2;
    public GameObject[] objectsToAppearClip3;
    public GameObject[] objectsToAppearClip4;
    public GameObject[] objectsToAppearClip5;
    public Renderer[] objectsToChangeMaterialClip2;
    public Renderer[] objectsToChangeMaterialClip4;
    public Material[] materialsClip2;
    public Material[] materialsClip4;
    public Animator[] animatorsClip4;
    public Animator[] animatorsClip5;
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

            Debug.Log("Playing clip: " + audioSource.clip.name);

            switch (currentIndex)
            {
                case 0: // Clip 1: Object 0 appears
                    ActivateObjects(objectsToAppearClip1);
                    break;
                case 1: // Clip 2: Objects 1 appear
                    StartCoroutine(DelayedObjectsAppearance(objectsToAppearClip2, 5f));
                    ChangeMaterial(objectsToChangeMaterialClip2, materialsClip2);
                    break;
                case 2: // Clip 3: Objects 2, 3 appear
                    StartCoroutine(DelayedObjectsAppearance(objectsToAppearClip3, 2f));
                    break;
                case 3: // Clip 4: Objects 4 appear
                    StartCoroutine(DelayedObjectAppearance(objectsToAppearClip4[0], 5f)); // Add a delay of 5 seconds
                    StartCoroutine(DelayedObjectAppearance(objectsToAppearClip4[1], 15f)); // Add a delay of 15 seconds for the second object
                    StartCoroutine(DelayedMaterialChange(objectsToChangeMaterialClip4, materialsClip4, 15f)); // Add a delay of 20 seconds for material change
                    ActivateAnimators(animatorsClip4);
                    break;
                case 4: // Clip 5: Objects 5 appear and enable animators
                    StartCoroutine(DelayedObjectsAppearance(objectsToAppearClip5, 6f)); // Delay objects appearance by 6 seconds
                    StartCoroutine(DelayedAnimatorsActivation(animatorsClip5, 0f, 5f)); // Delay animators activation by 5 seconds after initial delay of 0 seconds
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

    IEnumerator DelayedObjectsAppearance(GameObject[] objects, float delay)
    {
        foreach (GameObject obj in objects)
        {
            yield return new WaitForSeconds(delay);
            obj.SetActive(true);
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

    IEnumerator DelayedAnimatorsActivation(Animator[] animators, float initialDelay, float subsequentDelay)
    {
        yield return new WaitForSeconds(initialDelay);
        foreach (Animator animator in animators)
        {
            animator.enabled = true;
            yield return new WaitForSeconds(subsequentDelay);
        }
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

    void ActivateAnimators(Animator[] animators)
    {
        foreach (Animator animator in animators)
        {
            animator.enabled = true;
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