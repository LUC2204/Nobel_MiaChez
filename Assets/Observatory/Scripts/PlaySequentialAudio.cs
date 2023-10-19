using UnityEngine;
using UnityEngine.UI;

public class PlaySequentialAudio : MonoBehaviour
{
    /*public AudioSource audioSource1; // The first audio source to play immediately
    public AudioSource audioSource2; // The second audio source to play after a delay
    public float delay; // Delay time for the second audio source

    private bool isFirstButtonPress = true;
    private CoroutineHandler coroutineHandler;

    private void Start()
    {
        if (audioSource1 == null)
        {
            audioSource1 = gameObject.AddComponent<AudioSource>();
        }

        if (audioSource2 == null)
        {
            audioSource2 = gameObject.AddComponent<AudioSource>();
        }

        Button button = GetComponent<Button>();
        if (button != null)
        {
            button.onClick.AddListener(PlayAudio);
        }

        audioSource1.Stop();
        audioSource2.Stop();
    }

    private void PlayAudio()
    {
        if (isFirstButtonPress)
        {
            audioSource1.Play();
            isFirstButtonPress = false;

            // Use the CoroutineHandler to start the coroutine
            coroutineHandler.StartDelayedAudioCoroutine(delay, audioSource2);
        }
    }
    */
}
