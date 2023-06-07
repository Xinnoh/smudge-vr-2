using UnityEngine;

public class WateringScript : MonoBehaviour
{
    public ParticleSystem wateringParticles;
    private bool isWatering = false;
    private Quaternion initialRotation;

    private void Start()
    {
        initialRotation = transform.rotation;
        wateringParticles.Stop();
    }

    private void Update()
    {
        // Calculate the angle difference between the initial rotation and current rotation
        Quaternion currentRotation = transform.rotation;
        float angleDifference = Quaternion.Angle(initialRotation, currentRotation);

        // Check if the angle difference is greater than 45 degrees
        if (angleDifference > 45f)
        {
            // Start watering
            if (!isWatering)
            {
                wateringParticles.Play();
                isWatering = true;
            }
        }
        else
        {
            // Stop watering
            if (isWatering)
            {
                wateringParticles.Stop();
                isWatering = false;
            }
        }
    }
}
