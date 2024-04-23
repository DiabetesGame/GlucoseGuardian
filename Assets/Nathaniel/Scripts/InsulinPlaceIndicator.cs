using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InsulinPlaceIndicator : MonoBehaviour
{
    [SerializeField] GameObject staticInsulinKey;

    // Start is called before the first frame update
    void OnEnable()
    {
        staticInsulinKey.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("InsulinKey"))
        {
            staticInsulinKey.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("InsulinKey"))
        {
            staticInsulinKey.SetActive(false);
        }
    }

}
