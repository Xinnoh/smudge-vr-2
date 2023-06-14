using System.Collections;
using UnityEngine;

public class FishEagleInteraction : MonoBehaviour
{
    public Animator eagleAnimator;
    public GameObject presentPrefab;
    public Transform presentSpawnPoint;

    private bool isFishGiven = false;
    private GameObject presentObject;
    public GameObject compass;

    public ParticleSystem eat;
    public AudioSource audioSource;
    public AudioClip presentSound;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Fish") && !isFishGiven)
        {
            isFishGiven = true;

            // Trigger the animation state for the eagle to change its animation
            eagleAnimator.SetTrigger("ChangeAnimation");

            // Destroy the fish object
            Destroy(other.gameObject);

            // Instantiate the present prefab at the present spawn point
            presentObject = Instantiate(presentPrefab, presentSpawnPoint.position, presentSpawnPoint.rotation);
            // Hide the present object initially
            presentObject.SetActive(false);

            // Plays eating animation
            eat.gameObject.SetActive(true);
            eat.Play();

            // Play the present sound
            audioSource.PlayOneShot(presentSound);

            // Start a coroutine to wait for the animation clip to complete
            StartCoroutine(WaitForAnimation());

            compass.GetComponent<NextScene>().complete = true;
        }
    }

    private IEnumerator WaitForAnimation()
    {
        // Wait for the animation clip to complete
        yield return new WaitForSeconds(eagleAnimator.GetCurrentAnimatorClipInfo(0)[0].clip.length);

        // Show the present object
        presentObject.SetActive(true);
    }
}