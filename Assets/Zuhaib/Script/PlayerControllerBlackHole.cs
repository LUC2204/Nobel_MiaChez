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
    private bool hasReachedPointC = false;

    private enum MovementState
    {
        MovingToB,
        MovingToC
    }

    private MovementState currentState = MovementState.MovingToB;

    private void Start()
    {
        playerTransform = transform; // Assuming the script is on the XR Rig GameObject itself
        startPosition = pointA.position;
        endPosition = pointB.position;
    }

    private void Update()
    {
        currentTime += Time.deltaTime;

        if (currentState == MovementState.MovingToB)
        {
            if (currentTime < travelTimeAB)
            {
                // Calculate the interpolation value (0 to 1) based on time for segment AB
                float t = Mathf.Clamp01(currentTime / travelTimeAB);

                // Move the player smoothly from A to B
                playerTransform.position = Vector3.Lerp(startPosition, endPosition, t);
            }
            else
            {
                // Transition to moving to point C
                currentState = MovementState.MovingToC;
                currentTime = 0f;
                startPosition = pointB.position;
                endPosition = pointC.position;
                hasReachedPointC = false;
            }
        }
        else if (currentState == MovementState.MovingToC)
        {
            if (currentTime < travelTimeBC)
            {
                // Calculate the interpolation value (0 to 1) based on time for segment BC
                float t = Mathf.Clamp01(currentTime / travelTimeBC);

                // Move the player smoothly from B to C
                playerTransform.position = Vector3.Lerp(startPosition, endPosition, t);
            }
            else if (!hasReachedPointC)
            {
                // Player has reached point C
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
        }
    }
}
