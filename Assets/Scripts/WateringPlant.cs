using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WateringPlant : MonoBehaviour
{
    public Blendshape plantBlendshape;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("WateringParticle"))
        {
            // Trigger the blendshape animation on the plant
            plantBlendshape.StartBlendshapeAnimation();
        }
    }
}