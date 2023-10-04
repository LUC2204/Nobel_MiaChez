using UnityEngine;
using System.Collections;

public class ObservatoryRotate : MonoBehaviour
{
    public float rotationSpeed = 1.0f; // Speed of rotation
    public Transform player; // Reference to the player's transform

    // Unity event to start rotation
    public void StartRotation(float targetDegrees, Transform playerTransform)
    {
        // Set the player reference
        player = playerTransform;

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

            // Rotate the player along with the observatory
            if (player != null)
            {
                player.Rotate(new Vector3(0, rotationThisFrame, 0));
            }

            yield return null;
        }
    }
}