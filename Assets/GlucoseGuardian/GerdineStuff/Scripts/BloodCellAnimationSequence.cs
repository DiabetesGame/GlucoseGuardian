using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BloodCellAnimationSequence : MonoBehaviour
{
    public Animator cell1Animator;
    public Animator cell2Animator;
    public SkinnedMeshRenderer cell3MeshRenderer;
    public GameObject objectToEnable;

    private bool blendShapeAnimationStarted = false;

    void Start()
    {
        cell1Animator = objectToEnable.GetComponent<Animator>();
        cell2Animator = objectToEnable.GetComponent<Animator>();

        // Start the animation sequence
        StartAnimationSequence();
    }

    void StartAnimationSequence()
    {
        // Set the blend shape weight to 0 (blend shape closed)
        cell3MeshRenderer.SetBlendShapeWeight(0, 0);

        // Play the first two animations
        cell1Animator.SetTrigger("StartAnimation");
        cell2Animator.SetTrigger("StartAnimation");
    }

    void Update()
    {
        // Check if the first two animations have finished
        if (!blendShapeAnimationStarted &&
            cell1Animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1f &&
            cell2Animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1f)
        {
            // Start the blendshape animation
            cell3MeshRenderer.SetBlendShapeWeight(0, 100); // Open the blend shape
            blendShapeAnimationStarted = true;

            // Enable the objectToEnable after 4 seconds
            Invoke("EnableObject", 4f);
        }
    }

    void EnableObject()
    {
        // Enable the objectToEnable
        objectToEnable.SetActive(true);
    }
}


/*{
    public Animator object1Animator;
    public Animator object2Animator;
    public SkinnedMeshRenderer object3MeshRenderer;

    public GameObject object1;
    public GameObject object2;
    public GameObject object3;

    private bool animationStarted = false;
    private bool secondAnimationStarted = false;

    void Start()
    {
        object1Animator = object1.GetComponent<Animator>();
        object2Animator = object2.GetComponent<Animator>();
    }

    void Update()
    {
        if (animationStarted)
        {
            // Check if the first animation on object1 has finished
            if (object1Animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1f)
            {
                // Play the second animation on object2
                if (!secondAnimationStarted)
                {
                    object2Animator.SetTrigger("StartAnimation");
                    secondAnimationStarted = true;
                }
            }

            // Check if the second animation on object2 has finished
            if (secondAnimationStarted && object2Animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1f)
            {
                // Play the third animation on object3 (blendshapes)
                object3MeshRenderer.SetBlendShapeWeight(0, 100); // Adjust the blend shape weight as necessary
            }
        }
    }

    public void StartAnimationSequence()
    {
        // Reset all animations
        object1Animator.Rebind();
        object2Animator.Rebind();
        object3MeshRenderer.SetBlendShapeWeight(0, 0); // Reset blend shape weight

        animationStarted = true;
        secondAnimationStarted = false;
        // Play the first animation on object1
        object1Animator.SetTrigger("StartAnimation");
    }
}
*/

