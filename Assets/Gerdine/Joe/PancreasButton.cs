using System.Collections;
using System.Collections.Generic;
using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.UI;

public class PancreasButton : MonoBehaviour
{
    public Animator avatarAnimator;
    //public AudioSource soundEffect;
    //public GameObject particleSystemObject; // Changed from ParticleSystem to GameObject
    [SerializeField] GameObject pancreasParent;
    [SerializeField] GameObject insulinPool;
    private bool buttonPressed = false;

    public void OnButtonPress()
    {
        // Check if the button has not been pressed before
        if (!buttonPressed)
        {
            // Trigger the button pressed animation
            avatarAnimator.SetTrigger("ButtonPressed");

            // Set the flag to indicate that the button has been pressed
            buttonPressed = true;

/*            // Invoke a method to play the sound effect after a delay (e.g., 3 seconds)
            Invoke("PlaySoundEffect", 3f);

            // Invoke a method to enable the particle system after a delay (e.g., 3 seconds)
            Invoke("EnableParticleSystem", 3f);
*/
            // Invoke a method to reset the button press after a delay (e.g., 4 seconds)
            Invoke("ResetButtonPressed", 4f);

            //StartCoroutine(DisablePancreasButton());

            insulinPool.GetComponent<ObjPool>().insulinButtonPressed = true;
        }
    }

/*    // Method to play the sound effect
    private void PlaySoundEffect()
    {
        // Play the sound effect
        soundEffect.Play();
    }

    // Method to enable the particle system
    private void EnableParticleSystem()
    {
        // Enable the particle system GameObject
        particleSystemObject.SetActive(true);
    }*/

    // Method to reset the button press after a delay
    private void ResetButtonPressed()
    {
        // Reset the flag
        buttonPressed = false;

        // Trigger the idle animation
        avatarAnimator.SetTrigger("Idle");
    }

    IEnumerator DisablePancreasButton()
    {
        yield return new WaitForSeconds(5);

        pancreasParent.SetActive(false);
    }
}

