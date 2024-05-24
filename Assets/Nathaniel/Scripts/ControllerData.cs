using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ControllerData : MonoBehaviour
{
    //Property to be referenced
    [SerializeField] InputActionProperty triggerProperty;
    //Value to be changed on update
    float triggerVal;
    public bool triggered = false;
    //Read-Only value that can be accessed from anywhere
    public float TriggerValue { private set { } get { return triggerVal; } }

    // Update is called once per frame
    void Update()
    {
        triggerVal = triggerProperty.action.ReadValue<float>();
        if (triggerVal >= 0.8)
        {
            triggered = true;
        }
        else
        {
            triggered = false;
        }
    }
}
