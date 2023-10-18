using System.Collections;
using UnityEngine;
using BNG;

public class FadeOutScript : MonoBehaviour
{
    public ScreenFader screenFader; 
    public float delayInSeconds; 

    private void Start()
    {
        StartCoroutine(FadeOutAfterDelay());
    }

    private IEnumerator FadeOutAfterDelay()
    {
        yield return new WaitForSeconds(delayInSeconds);

        
        screenFader.DoFadeOut();
        
    }
}