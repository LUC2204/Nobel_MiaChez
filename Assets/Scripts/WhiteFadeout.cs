using System.Collections;
using UnityEngine;
using BNG;

public class WhiteFadeout : MonoBehaviour
{
    public ScreenFader screenFader;
    public float delayInSeconds;
    public float fadeOutTime;
    public AudioFadeout _audioFadeout;


    [SerializeField] private AudioSource _audioSource;

    /// <summary>
    private Color fadeOutColor; 
    /// </summary>

    private void Start()
    {
        _audioSource.volume = 1.0f;
        // Set the fade-out color
        //screenFader.FadeMaterial.color = fadeOutColor;

        screenFader.FadeColor = fadeOutColor;

        // Set the fade-out speed
        screenFader.FadeInSpeed = fadeOutTime;

        StartCoroutine(FadeOutAfterDelay());
    }

    private IEnumerator FadeOutAfterDelay()
    {
        yield return new WaitForSeconds(delayInSeconds);

        screenFader.DoFadeIn();
        StartCoroutine(_audioFadeout.DoFadeOutAudio(_audioSource));

    }

}
