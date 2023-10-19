using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DelayedAudioButton : MonoBehaviour
{
    public AudioSource audioSource;
    public float delayInSeconds;
    private bool audioScheduled = false;

    private void Start()
    {
        // Find the Audio Source if not manually assigned
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        Button button = GetComponent<Button>();
        if (button != null)
        {
            button.onClick.AddListener(ScheduleAudio);
        }

        // Disable the audio source at the start
        audioSource.Stop();
    }

    // Function to schedule the audio to play after the button is clicked
    private void ScheduleAudio()
    {
        if (!audioScheduled)
        {
            StartCoroutine(PlayAudioDelayed(delayInSeconds));
            audioScheduled = true;
        }
    }

    // Coroutine to play the audio clip after a delay
    private IEnumerator PlayAudioDelayed(float delay)
    {
        yield return new WaitForSeconds(delay);
        audioSource.Play();
    }
}
