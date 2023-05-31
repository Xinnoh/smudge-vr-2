using UnityEngine;

public class WateringScript : MonoBehaviour
{
    public ParticleSystem wateringParticles;

    private bool isGrabbed = false;

    private void Update()
    {
        // Check for grab input from the player
        if (Input.GetKeyDown(KeyCode.B))
        {
            if (isGrabbed)
            {
                StopWatering();
            }
            else
            {
                StartWatering();
            }

            isGrabbed = !isGrabbed;
        }
    }

    private void StartWatering()
    {
        // Activate the particle system
        if (wateringParticles != null)
        {
            wateringParticles.Play();
        }
    }

    private void StopWatering()
    {
        // Deactivate the particle system
        if (wateringParticles != null)
        {
            wateringParticles.Stop();
        }
    }
}