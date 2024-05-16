using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickToChoseSnack : MonoBehaviour
{
    public GameObject[] objectsToDisable;
    public GameObject[] objectsToEnable;

    public void ButtonClickHandler()
    {
        // Disable objectsToDisable and enable objectsToEnable
        foreach (GameObject obj in objectsToDisable)
        {
            obj.SetActive(false);
        }
        foreach (GameObject obj in objectsToEnable)
        {
            obj.SetActive(true);
        }

        // Disable the button
        gameObject.SetActive(false);
    }
}
