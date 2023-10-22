using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BNG;

public class AudioGrabbable : MonoBehaviour
{
    private Grabbable grabbable;
    private bool audioTriggered = false;
    

    // Start is called before the first frame update
    void Start()
    {
        // Get a reference to the Grabbable component
        grabbable = GetComponent<Grabbable>();
    }

    // Update is called once per frame
    public void Update()
    {
        if (grabbable.BeingHeld && !audioTriggered)
        {
            // Trigger audio
            audioTriggered = true;
            GetComponent<AudioSource>().Play();
        }
        if (!grabbable.BeingHeld)
        {
            audioTriggered = false;
        }
    }
}
