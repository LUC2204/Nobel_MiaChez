using UnityEngine;
using UnityEngine.UI;

public class PlayAudioOnClick : MonoBehaviour
{
    public AudioSource audioSource; // Reference to the Audio Source component

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
            // Add a listener to the button's click event
            Button button = GetComponent<Button>();
            if (button != null)
            {
                button.onClick.AddListener(PlayAudio);
            }
        }
    }

    // Function to play the audio clip
    private void PlayAudio()
    {
        if (audioSource != null && audioSource.clip != null)
        {
            audioSource.Play();
        }
    }
}
