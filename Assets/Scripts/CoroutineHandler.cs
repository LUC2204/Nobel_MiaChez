using UnityEngine;
using System.Collections;

public class CoroutineHandler : MonoBehaviour
{
    public void StartDelayedAudioCoroutine(float delay, AudioSource audioSource)
    {
        StartCoroutine(PlayDelayedAudioCoroutine(delay, audioSource));
    }

    private IEnumerator PlayDelayedAudioCoroutine(float delay, AudioSource audioSource)
    {
        yield return new WaitForSeconds(delay);
        audioSource.Play();
    }
}
