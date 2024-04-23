using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class highlightPancreas : MonoBehaviour
{
    public Material pancreasMaterial; // Reference to the pancreas material
    private Material originalMaterial; // Store the original material
    private bool pancreasMaterialActive = false; // Track whether pancreas material is active

    void Start()
    {
        // Get the renderer component attached to this GameObject
        Renderer renderer = GetComponent<Renderer>();

        // Store the original material
        originalMaterial = renderer.material;
    }

    void Update()
    {
        // Check if 'P' key is pressed for pancreas material toggle
        if (Input.GetKeyDown(KeyCode.P))
        {
            TogglePancreasMaterial();
        }
    }

    void TogglePancreasMaterial()
    {
        // Get the renderer component attached to this GameObject
        Renderer renderer = GetComponent<Renderer>();

        if (!pancreasMaterialActive)
        {
            // Assign the pancreas material to the renderer
            renderer.material = pancreasMaterial;

            pancreasMaterialActive = true;
        }
        else
        {
            // Assign the original material to the renderer
            renderer.material = originalMaterial;

            pancreasMaterialActive = false;
        }
    }
}
