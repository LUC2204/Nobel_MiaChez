using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlaySequentialAudio : MonoBehaviour
{
    public AudioSource audioSource1; // Reference to the first Audio Source component
    public AudioSource audioSource2; // Reference to the second Audio Source component
    private bool isFirstButtonPress = true; // Track the first button press

    private void Start()
    {
        // Find the Audio Sources if not manually assigned
        if (audioSource1 == null)
        {
            audioSource1 = gameObject.AddComponent<AudioSource>();
        }

        if (audioSource2 == null)
        {
            audioSource2 = gameObject.AddComponent<AudioSource>();
        }

        // Add a listener to the button's click event
        Button button = GetComponent<Button>();
        if (button != null)
        {
            button.onClick.AddListener(PlayAudio);
        }

        // Disable the audio sources at the start
        audioSource1.Stop();
        audioSource2.Stop();
    }

    // Function to play the audio clips sequentially
    private void PlayAudio()
    {
        if (isFirstButtonPress)
        {
            // Play the first audio source
            audioSource1.Play();
            isFirstButtonPress = false;

            // Start a coroutine to play the second audio source after the first one
            StartCoroutine(PlaySecondAudioAfterFirst());
        }
    }

    private IEnumerator PlaySecondAudioAfterFirst()
    {
        yield return new WaitForSeconds(audioSource1.clip.length);

        // Play audio from the second source
        audioSource2.Play();
    }
}
