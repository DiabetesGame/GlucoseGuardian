using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinHologram : MonoBehaviour
{
    Rigidbody rigidBody;
    int speed = 30;

    // Start is called before the first frame update
    void Start()
    {
        try
        {
            rigidBody = GetComponentInChildren<Rigidbody>();
        }
        catch (NullReferenceException)
        {
            Debug.LogWarning("You forgot to set something!");
        }
        if (rigidBody.angularVelocity.y <= 1.25)
        {
            rigidBody.AddTorque(Vector3.up * speed);
            rigidBody.angularDrag = 0;
        }
    }

    public void OnEnable()
    {
        if (rigidBody.angularVelocity.y <= 1.25)
        {
            rigidBody.AddTorque(Vector3.up * speed);
            rigidBody.angularDrag = 0;
        }
    }
    public void OnDisable()
    {
        rigidBody.angularDrag = 2;
    }
}
