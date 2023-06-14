using UnityEngine;

public class PresentInteraction : MonoBehaviour
{
    public GameObject present;
    public GameObject place;
    public AudioClip[] audioClips;

    private AudioSource audioSource;

    private void Start()
    {
        // Get the AudioSource component attached to the same GameObject
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if both the present and place objects are colliders
        if (other.gameObject == present && place != null && place.GetComponent<Collider>() != null)
        {
            // Play a random audio clip
            if (audioClips != null && audioClips.Length > 0 && audioSource != null)
            {
                int randomIndex = Random.Range(0, audioClips.Length);
                audioSource.clip = audioClips[randomIndex];
                audioSource.Play();
            }
        }
    }
}