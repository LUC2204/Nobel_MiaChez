using UnityEngine;

public class PlayerControllerBlackHole : MonoBehaviour
{
    public Transform pointA;  // Set this to the transform of point A
    public Transform pointB;  // Set this to the transform of point B
    public Transform pointC;  // Set this to the transform of point C
    public float travelTimeAB = 15f;  // Travel time from point A to B (15 seconds)
    public float travelTimeBC = 5f;   // Travel time from point B to C (5 seconds)
    public AudioSource audioSource;  // Reference to the audio source

    private Transform playerTransform;
    private Vector3 startPosition;
    private Vector3 endPosition;
    private float currentTime = 0f;
    private bool hasReachedPointB = false;
    private bool hasReachedPointC = false;

    private void Start()
    {
        playerTransform = transform; // Assuming the script is on the XR Rig GameObject itself
        startPosition = pointA.position;
        endPosition = pointB.position;
    }

    private void Update()
    {
        currentTime += Time.deltaTime;

        if (currentTime < travelTimeAB && !hasReachedPointB)
        {
            // Calculate the interpolation value (0 to 1) based on time for segment AB
            float t = Mathf.Clamp01(currentTime / travelTimeAB);

            // Move the player smoothly from A to B with a circular motion
            playerTransform.position = Vector3.Lerp(startPosition, endPosition, t);
        }
        else if (!hasReachedPointB)
        {
            // Transition to moving to point C
            hasReachedPointB = true;
            currentTime = 0f;
            startPosition = pointB.position;
            endPosition = pointC.position;
        }

        if (hasReachedPointB && currentTime < travelTimeBC)
        {
            // Calculate the interpolation value (0 to 1) based on time for segment BC
            float t = Mathf.Clamp01(currentTime / travelTimeBC);

            // Move the player smoothly from B to C in a linear path
            playerTransform.position = Vector3.Lerp(startPosition, endPosition, t);

            if (hasReachedPointC == false && t >= 1)
            {
                hasReachedPointC = true;
                PlayAudioAtPointC();
            }
        }
    }

    private void PlayAudioAtPointC()
    {
        if (audioSource != null)
        {
            audioSource.Play();
            Debug.Log("Audio played at point C.");
        }
    }
}
