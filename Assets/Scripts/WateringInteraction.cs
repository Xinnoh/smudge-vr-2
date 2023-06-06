using UnityEngine;

public class WateringInteraction : MonoBehaviour
{
    public ParticleSystem wateringParticles;

    private bool isGrabbed = false;
    private bool isTouched = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isTouched = true;
            PlayWateringParticles();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isTouched = false;
            StopWateringParticles();
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrabbed)
        {
            if (wateringParticles.isPlaying)
                StopWateringParticles();
            else
                PlayWateringParticles();
        }
    }

    private void PlayWateringParticles()
    {
        if (isGrabbed || isTouched)
        {
            wateringParticles.Play();
        }
    }

    private void StopWateringParticles()
    {
        wateringParticles.Stop();
    }

    public void SetIsGrabbed(bool grabbed)
    {
        isGrabbed = grabbed;
        if (grabbed)
        {
            PlayWateringParticles();
        }
        else
        {
            StopWateringParticles();
        }
    }
}