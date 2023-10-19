using System.Collections;
using UnityEngine;
using BNG;

public class FadeOutScript : MonoBehaviour
{
    public ScreenFader screenFader; 
    public float delayInSeconds; 
    public float fadeOutTime;

    private void Start()
    {
        screenFader.FadeInSpeed = fadeOutTime;
        StartCoroutine(FadeOutAfterDelay());
    }


    private IEnumerator FadeOutAfterDelay()
    {
        yield return new WaitForSeconds(delayInSeconds);

        
        screenFader.DoFadeIn();
        
    }
}