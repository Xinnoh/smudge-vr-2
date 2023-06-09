using UnityEngine;

public class WateringParticle : MonoBehaviour
{
    public Blendshape blendshapeScript; // Reference to the Blendshape script on the plant

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PlantCollider"))
        {
            // Check if the blendshape script is assigned
            if (blendshapeScript != null)
            {
                // Trigger the blendshape animation on the plant
                blendshapeScript.StartBlendshapeAnimation();
            }
        }
    }
}