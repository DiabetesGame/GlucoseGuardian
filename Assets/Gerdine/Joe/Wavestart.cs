using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wavestart : MonoBehaviour

{
    public Animator avatarAnimator;

    void Start()
    {
        // Trigger the animation when the object starts
        avatarAnimator.SetTrigger("Wave");
    }

    // Animation event called at the end of the wave animation
    public void WaveAnimationEnd()
    {
        // Trigger the idle animation when the wave animation ends
        avatarAnimator.SetTrigger("Idle");
    }
}
