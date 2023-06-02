using UnityEngine;

public class WateringScript : MonoBehaviour
{
    public ParticleSystem wateringParticles; // Reference to the watering particle system

    private bool isWatering = false; // Flag to track if watering is currently active

    private void Update()
    {
        // Check for button B input
        if (OVRInput.GetDown(OVRInput.Button.Two))
        {
            Debug.Log("Button B Pressed");
            // Start watering by enabling the particle system
            wateringParticles.Play();
            isWatering = true;
        }
        else if (OVRInput.GetUp(OVRInput.Button.Two))
        {
            // Stop watering by disabling the particle system
            wateringParticles.Stop();
            isWatering = false;
        }
    }
}