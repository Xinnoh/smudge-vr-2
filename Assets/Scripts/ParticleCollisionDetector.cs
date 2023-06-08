using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleCollisionDetector : MonoBehaviour
{
    public GameObject plant;

    private void OnEnable()
    {
        // Subscribe to the OnParticleCollision event
        ParticleSystem ps = GetComponent<ParticleSystem>();
        var triggerModule = ps.trigger;
        triggerModule.enabled = true;
        triggerModule.SetCollider(0, plant.GetComponent<Collider>());
    }

    private void OnParticleCollision(GameObject other)
    {
        if (other.CompareTag("Plant"))
        {
            // Perform actions when the particle system collides with the plant
            Debug.Log("Particle collided with the plant!");

            // Add your logic here to trigger the plant's growth or any other desired behavior
        }
    }
}