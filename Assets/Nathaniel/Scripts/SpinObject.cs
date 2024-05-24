using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinObject : MonoBehaviour
{
    [SerializeField] Animator difficultyAnimator;
    [SerializeField] Rigidbody difficultyRB;
    int speed = 2;

    // Start is called before the first frame update
    void Start()
    {
        try
        {
            difficultyRB = GetComponentInChildren<Rigidbody>();
            difficultyAnimator = gameObject.GetComponentInChildren<Animator>();
        }
        catch(NullReferenceException)
        {
            Debug.LogWarning("You forgot to set something!");
        }
    }

    public void SpinThing()
    {
        difficultyAnimator.Play("Base Layer.RaiseAndSpin");
        if (difficultyRB.angularVelocity.y <= 5)
        {
            difficultyRB.AddTorque(Vector3.up * speed);
            difficultyRB.angularDrag = 0;
        }
    }
    public void StopSpin()
    {
        difficultyRB.angularDrag = 2;
    }
}
