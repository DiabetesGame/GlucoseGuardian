using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TubeCellTrigger : MonoBehaviour
{
    public Animator tubeCellAnimator;

    private void Start()
    {
        // Find the Animator component in the GameObject
        tubeCellAnimator = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if the entering GameObject has the tag "Player"
        if (other.CompareTag("Player"))
        {
            // Trigger the "TubeAnimationBrainCell" animation
            tubeCellAnimator.SetTrigger("TubeAnimationBrainCell");
        }
    }
}
