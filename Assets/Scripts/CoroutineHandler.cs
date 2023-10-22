using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(AudioSource))]
public class CoroutineHandler : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private List<AudioClip> _audioClips = new List<AudioClip>();
    [SerializeField] private float _delayToTheSecondClip;

    // Add a private reference to the currently playing coroutine
    private Coroutine _audioCoroutine;

    public void PlayAudio()
    {
        // Stop any previously playing coroutine before starting a new one
        if (_audioCoroutine != null)
        {
            StopCoroutine(_audioCoroutine);
        }

        _audioCoroutine = StartCoroutine(Play());
    }

    public void StopAudio()
    {
        // Stop the currently playing coroutine and audio source
        if (_audioCoroutine != null)
        {
            StopCoroutine(_audioCoroutine);
        }
        _audioSource.Stop();
    }

    IEnumerator Play()
    {
        _audioSource.PlayOneShot(_audioClips[0]);
        yield return new WaitForSeconds(_delayToTheSecondClip);
        _audioSource.PlayOneShot(_audioClips[1]);
    }
}
