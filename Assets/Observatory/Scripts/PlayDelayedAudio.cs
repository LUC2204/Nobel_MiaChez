using System.Collections;
using UnityEngine;

public class PlayDelayedAudio : MonoBehaviour
{
    public AudioSource audioSource; // Reference to the Audio Source component
    public float delayInSeconds = 15f; // Delay in seconds before playing the audio

    private void Start()
    {
        // Find the Audio Source if not manually assigned
        if (audioSource == null)
        {
            audioSource = GetComponent<AudioSource>();
        }

        // Ensure the Audio Source is ready to play
        if (audioSource != null)
        {
            // Disable "Play on Awake" to prevent auto-play
            //audioSource.playOnAwake = false;

            // Start the coroutine to play the audio with a delay
            StartCoroutine(PlayAudioWithDelay());
        }
    }

    private IEnumerator PlayAudioWithDelay()
    {
        // Wait for the specified delay
        yield return new WaitForSeconds(delayInSeconds);

        // Play the audio
        audioSource.Play();
    }
}
