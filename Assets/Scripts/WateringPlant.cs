using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WateringPlant : MonoBehaviour
{
    public Blendshape blendshape;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("WateringParticleSystem"))
        {
            // Start the blend shape animation
            blendshape.StartBlendshapeAnimation();
        }
    }
}
