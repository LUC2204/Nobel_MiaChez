using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioFadeout : MonoBehaviour
{
    public float fadeSpeed;
    
    public IEnumerator DoFadeOutAudio(AudioSource audioSource){
        Debug.Log("Started to fade music!");
        audioSource.volume = 1.0f;
        for (float i = 1.0f; i > 0.0f; i -= Time.deltaTime * fadeSpeed){
            audioSource.volume = i;
            yield return null;
        }
    }

}
