using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BNG;

/// <summary>
/// Put this script on the object you want to return to the
/// original position when it is released.
/// Keep in mind that the same object needs to have "Grabbable" and "GrabbableUnityEvents" component
///
/// On the GrabbableUnityEvents component, attach this script and reference the function
/// ReturnToOriginalPosition in it
/// </summary>

[RequireComponent(typeof(Grabbable))] // Makes the script require component "Grabbable"
[RequireComponent(typeof(GrabbableUnityEvents))] // Makes the script require ocmponent "GrabbableUnityEvents"
public class GrabReturner : MonoBehaviour
{
    // Set this in the inspector
    [SerializeField] private Transform _positionToReturnTo;
    
    // Call this function through the event "On Release()" in the inspector in the GrabbableUnityEvents component
    public void ReturnToOriginalPosition() {
        transform.position = _positionToReturnTo.position;
        transform.rotation = _positionToReturnTo.rotation;
    }
}
