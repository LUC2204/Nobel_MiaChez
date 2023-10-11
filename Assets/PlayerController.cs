using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Transform pointA;  // Set this to the transform of point A
    public Transform pointB;  // Set this to the transform of point B
    public Transform pointC;  // Set this to the transform of point C

    private Transform playerTransform;
    private Vector3 startPosition;
    private Vector3 endPosition;
    private float travelTimeAB = 7f;  // Travel time from point A to B (7 seconds)
    private float travelTimeBC = 35f;  // Travel time from point B to C (35 seconds)
    private float currentTime = 0f;

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
                // Switch to segment BC
                currentState = MovementState.MovingToC;
                startPosition = pointB.position;
                endPosition = pointC.position;
                currentTime = 0f; // Reset time for the new segment
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
        }
    }
}
