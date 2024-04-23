using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleXrayOn : MonoBehaviour

{
    public Shader customShader; // Reference to the custom shader you want to use
    private Material originalMaterial; // Store the original material

    void Start()
    {
        // Get the renderer component attached to this GameObject
        Renderer renderer = GetComponent<Renderer>();

        // Store the original material
        originalMaterial = renderer.material;
    }

    void Update()
    {
        // Check if the space bar is pressed
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Get the renderer component attached to this GameObject
            Renderer renderer = GetComponent<Renderer>();

            // If the current material is the original material, switch to the custom shader
            if (renderer.material == originalMaterial)
            {
                // Create a new material using the custom shader
                Material customMaterial = new Material(customShader);

                // Assign the custom material to the renderer
                renderer.material = customMaterial;
            }
            else // If the current material is the custom material, switch back to the original material
            {
                // Assign the original material to the renderer
                renderer.material = originalMaterial;
            }
        }
    }
}
