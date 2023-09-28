using UnityEngine;

public class TelescopeRotation : MonoBehaviour
{
    [Tooltip("Speed of the rotation in degrees per second")]
    public float rotationSpeed = 30f;

    [Tooltip("Maximum angle of rotation")]
    public float maxRotationAngle = 20f;

    private float currentRotationAngle = 0f;

    private AudioSource audioSource;

    private bool hasAudioPlayed = false;
    private bool startRotation = false; // Flag to start rotation

    void Start()
    {
        // Get the AudioSource component attached to this GameObject
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        // Check if the rotation should start
        if (startRotation && currentRotationAngle < maxRotationAngle)
        {
            // Play audio when rotation starts, but only once
            if (!hasAudioPlayed)
            {
                audioSource.Play();
                hasAudioPlayed = true;
            }

            float rotationThisFrame = rotationSpeed * Time.deltaTime;
            float possibleRotation = currentRotationAngle + rotationThisFrame;

            if (possibleRotation > maxRotationAngle)
            {
                rotationThisFrame = maxRotationAngle - currentRotationAngle;
            }

            transform.Rotate(rotationThisFrame, 0, 0, Space.Self);
            currentRotationAngle += rotationThisFrame;
        }
    }

    // Function to start the rotation when called (e.g., from a button press)
    public void StartRotation()
    {
        startRotation = true;
    }
}