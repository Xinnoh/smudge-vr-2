using UnityEngine;

public class AudioOrder : MonoBehaviour
{
    public AudioClip[] audioClips;
    private int currentClipIndex = 0;
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        PlayNextClip();
    }

    private void PlayNextClip()
    {
        if (currentClipIndex < audioClips.Length)
        {
            audioSource.clip = audioClips[currentClipIndex];
            audioSource.Play();
            currentClipIndex++;
        }
    }

    private void Update()
    {
        if (!audioSource.isPlaying && currentClipIndex < audioClips.Length)
        {
            PlayNextClip();
        }
    }
}