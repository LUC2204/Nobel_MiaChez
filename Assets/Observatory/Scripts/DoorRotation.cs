using System.Collections;
using UnityEngine;

public class DoorRotation : MonoBehaviour
{
    
    public Transform targetPosition; 
    public float rotationSpeed =  -20.0f; 
    public float movementSpeed = 1.0f; 

    private bool isRotating = false;

    void Awake()
    {
        StartCoroutine(RotateAndMove());
    }

    IEnumerator RotateAndMove()
    {
        
        float elapsedTime = 0;
        while (elapsedTime < 20.0f)
        {
            transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        
        //transform.rotation = Quaternion.identity;

        
        isRotating = false;
        float journeyLength = Vector3.Distance(transform.position, targetPosition.position);
        float startTime = Time.time;

        while (transform.position != targetPosition.position)
        {
            float distanceCovered = (Time.time - startTime) * movementSpeed;
            float journeyFraction = distanceCovered / journeyLength;
            transform.position = Vector3.Lerp(transform.position, targetPosition.position, journeyFraction);
            yield return null;
        }
    }
}