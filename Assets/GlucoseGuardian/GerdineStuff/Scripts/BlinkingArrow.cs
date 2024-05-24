using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlinkingArrow : MonoBehaviour
{
    // Variables to control blinking speed and intensity
    public float blinkSpeed = 2.0f;
    public float minIntensity = 0.0f;
    public float maxIntensity = 1.0f;

    // Private variables
    private Material material;
    private Color baseColor;
    private float emissionIntensity;

    void Start()
    {
        // Get the material from the Renderer component
        Renderer renderer = GetComponent<Renderer>();
        if (renderer != null)
        {
            material = renderer.material;
            // Get the base color of the material
            baseColor = material.GetColor("_EmissionColor");
        }
        else
        {
            Debug.LogError("Renderer component not found on the object.");
        }
    }

    void Update()
    {
        // Calculate the emission intensity based on time
        emissionIntensity = Mathf.Lerp(minIntensity, maxIntensity, Mathf.PingPong(Time.time * blinkSpeed, 1));
        // Set the emission color with the calculated intensity
        Color emissionColor = baseColor * Mathf.LinearToGammaSpace(emissionIntensity);
        material.SetColor("_EmissionColor", emissionColor);

        // Enable emission for the material
        material.EnableKeyword("_EMISSION");
    }
}
