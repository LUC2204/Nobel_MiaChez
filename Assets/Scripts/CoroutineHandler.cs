using UnityEngine;
using System.Collections;
using System.Collections.Generic;


[RequireComponent(typeof(AudioSource))]
public class CoroutineHandler : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private List<AudioClip> _audioClips = new List<AudioClip>();
    [SerializeField] private float _delayToTheSecondClip;

    public void PlayAudio() {
        StartCoroutine(Play());
    }

    IEnumerator Play() {
        _audioSource.PlayOneShot(_audioClips[0]);
        yield return new WaitForSeconds(_delayToTheSecondClip);
        _audioSource.PlayOneShot(_audioClips[1]);
    }



    /*
    public void StartDelayedAudioCoroutine(float delay, AudioSource audioSource)
    {
        StartCoroutine(PlayDelayedAudioCoroutine(delay, audioSource));
    }


    private IEnumerator PlayDelayedAudioCoroutine(float delay, AudioSource audioSource)
    {
        yield return new WaitForSeconds(delay);
        audioSource.Play();
    }
    */
}
