using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class WaveTrigger : MonoBehaviour


{
    public Animator avatarAnimator;
    private bool actionPerformed = false;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Glucose") && !actionPerformed)
        {
            // Trigger the animation
            avatarAnimator.SetTrigger("Wave");

            // Set the flag to true to indicate the action has been performed
            actionPerformed = true;
        }
    }

    // Animation event called at the end of the push button animation
    public void ResetActionPerformed()
    {
        // Reset the flag
        actionPerformed = false;

        // Trigger the idle animation
        avatarAnimator.SetTrigger("Idle");
    }
}
