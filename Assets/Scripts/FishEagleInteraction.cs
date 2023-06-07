using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishEagleInteraction : MonoBehaviour
{
    public Animator eagleAnimator;
    public GameObject presentPrefab;
    public Transform presentSpawnPoint;
    public AudioSource audioSource;
    public AudioClip happySound;

    private bool fishGiven = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Fish") && !fishGiven)
        {
            fishGiven = true;
            eagleAnimator.SetTrigger("Happy");
            Instantiate(presentPrefab, presentSpawnPoint.position, presentSpawnPoint.rotation);

            if (audioSource != null && happySound != null)
            {
                audioSource.PlayOneShot(happySound);
            }
        }
    }
}