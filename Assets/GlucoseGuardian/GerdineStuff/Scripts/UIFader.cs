using UnityEngine;
using System.Collections;

public class UIFader : MonoBehaviour
{
    public CanvasGroup canvasGroup;
    public float fadeDuration = 1.0f;
    public GameObject[] objectsToEnable; // Objects to enable after fade out
    public AudioSource audioSource; // Audio source to play after fade out

    void Start()
    {
        // Ensure CanvasGroup is attached
        if (canvasGroup == null)
        {
            canvasGroup = GetComponent<CanvasGroup>();
        }

        // Start the fade out process after 5 seconds
        StartCoroutine(StartFadeOutAfterDelay(5f));
    }

    private IEnumerator StartFadeOutAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        FadeOut();
    }

    public void FadeOut()
    {
        StartCoroutine(FadeCanvasGroup(canvasGroup, canvasGroup.alpha, 0, fadeDuration));
    }

    private IEnumerator FadeCanvasGroup(CanvasGroup cg, float start, float end, float duration)
    {
        float counter = 0f;

        while (counter < duration)
        {
            counter += Time.deltaTime;
            cg.alpha = Mathf.Lerp(start, end, counter / duration);
            yield return null;
        }

        // Ensure the final alpha is set
        cg.alpha = end;

        // Enable the objects and play the audio source after fade out is complete
        EnableObjectsAndPlayAudio();
    }

    private void EnableObjectsAndPlayAudio()
    {
        // Enable each object in the array
        foreach (GameObject obj in objectsToEnable)
        {
            obj.SetActive(true);
        }

        // Play the audio source if it is assigned
        if (audioSource != null)
        {
            audioSource.Play();
        }
    }
}
