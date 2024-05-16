using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class startTutorial : MonoBehaviour
{
    public GameObject[] objectsToDisableOnClick;
    public GameObject[] objectsToEnableOnClick;

    private bool buttonEnabled = false;

    void Update()
    {
        // Enable the button after 20 seconds
        if (!buttonEnabled && Time.timeSinceLevelLoad > 20f)
        {
            buttonEnabled = true;
            // Enable the button
            GetComponent<Button>().interactable = true;
        }
    }

    public void ButtonClickHandlerMethod()
    {
        // Disable objectsToDisableOnClick and enable objectsToEnableOnClick
        foreach (GameObject obj in objectsToDisableOnClick)
        {
            obj.SetActive(false);
        }
        foreach (GameObject obj in objectsToEnableOnClick)
        {
            obj.SetActive(true);
        }

        // Disable the button
        GetComponent<Button>().interactable = false;
    }
}