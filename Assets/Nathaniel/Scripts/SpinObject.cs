using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinObject : MonoBehaviour
{
    Animator animator;
    Rigidbody rigidBody;
    int speed = 2;

    // Start is called before the first frame update
    void Start()
    {
        try
        {
            animator = GetComponentInChildren<Animator>();
            rigidBody = GetComponentInChildren<Rigidbody>();
        }
        catch(NullReferenceException)
        {
            Debug.LogWarning("You forgot to set something!");
        }

    }

    public void SpinThing()
    {
        animator.Play("Base Layer.RaiseAndSpin");
        if (rigidBody.angularVelocity.y <= 5)
        {
            rigidBody.AddTorque(Vector3.up * speed);
        }
    }
}
