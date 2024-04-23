using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class highlightStomach : MonoBehaviour
{
    public Material stomachMaterial; // Reference to the stomach material
    private Material originalMaterial; // Store the original material
    private bool stomachMaterialActive = false; // Track whether stomach material is active

    void Start()
    {
        // Get the renderer component attached to this GameObject
        Renderer renderer = GetComponent<Renderer>();

        // Store the original material
        originalMaterial = renderer.material;
    }

    void Update()
    {
        // Check if 'S' key is pressed for stomach material toggle
        if (Input.GetKeyDown(KeyCode.S))
        {
            ToggleStomachMaterial();
        }
    }

    void ToggleStomachMaterial()
    {
        // Get the renderer component attached to this GameObject
        Renderer renderer = GetComponent<Renderer>();

        if (!stomachMaterialActive)
        {
            // Assign the stomach material to the renderer
            renderer.material = stomachMaterial;

            stomachMaterialActive = true;
        }
        else
        {
            // Assign the original material to the renderer
            renderer.material = originalMaterial;

            stomachMaterialActive = false;
        }
    }
}
