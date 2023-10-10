using UnityEngine;
using System.Collections;

public class ObservatoryRotate : MonoBehaviour
{
    public float rotationSpeed = 1.0f; // Speed of rotation

    // Unity event to start rotation
    public void StartRotation(float targetDegrees)
    {
        // Start a coroutine to gradually rotate the GameObject
        StartCoroutine(RotateOverTime(targetDegrees));
    }

    // Coroutine to gradually rotate the GameObject
    private IEnumerator RotateOverTime(float targetDegrees)
    {
        float currentRotation = 0f;

        while (currentRotation < targetDegrees)
        {
            float rotationThisFrame = rotationSpeed * Time.deltaTime;
            currentRotation += rotationThisFrame;

            // Rotate the GameObject around its y-axis
            transform.Rotate(new Vector3(0, rotationThisFrame, 0));

            yield return null;
        }
    }
}