using UnityEngine;

public class FishInteraction : MonoBehaviour
{
    public Animator eagleAnimator;
    public AudioSource eagleAudioSource;
    public AudioClip happySound;

    private bool hasInteracted = false;

    private void OnTriggerEnter(Collider other)
    {
        if (!hasInteracted && other.CompareTag("Eagle"))
        {
            hasInteracted = true;

            // Play the HappyAnimation
            eagleAnimator.Play("HappyAnimation");

            // Play the happy sound
            eagleAudioSource.PlayOneShot(happySound);

            // Add code to give the present to the player
            // For example, instantiate a present GameObject and place it on the table
        }
    }
}