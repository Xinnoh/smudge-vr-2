using UnityEngine;

public class PlantInteraction : MonoBehaviour
{
    public ParticleSystem particleSystem;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("WateringParticleSystem"))
        {
            // Particle system has collided with the plant
            Debug.Log("Water particle system collided with the plant.");

            // Trigger the particle system
            particleSystem.Play();
        }
    }
}