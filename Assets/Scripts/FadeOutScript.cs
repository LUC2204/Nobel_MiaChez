using System.Collections;
using UnityEngine;
using BNG;

public class FadeOutScript : MonoBehaviour
{
    public ScreenFader screenFader;
    public float delayInSeconds;
    public float fadeOutTime;

    //[SerializeField] 
    //private Color fadeOutColor; 

    private void Start()
    {
        // Set the fade-out color
        //screenFader.FadeMaterial.color = fadeOutColor;

        // Set the fade-out speed
        screenFader.FadeInSpeed = fadeOutTime;

        StartCoroutine(FadeOutAfterDelay());
    }

    private IEnumerator FadeOutAfterDelay()
    {
        yield return new WaitForSeconds(delayInSeconds);

        screenFader.DoFadeIn();
    }

}
