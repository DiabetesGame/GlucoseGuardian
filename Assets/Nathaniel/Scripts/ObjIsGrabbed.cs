using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ObjIsGrabbed : MonoBehaviour
{
    public bool grabbed = false;
    Rigidbody rb;
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    public void Grabbed(SelectEnterEventArgs args)
    {
        grabbed = true;
        animator.enabled = false;
    }

    public void Released(SelectExitEventArgs args)
    {
        grabbed = false;
        rb.isKinematic = false;
        rb.useGravity = true;
    }
}
