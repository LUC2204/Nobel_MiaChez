using UnityEngine;

public class PlayerControllerBlackHole : MonoBehaviour
{
    public Transform pointA;  // Set this to the transform of point A
    public Transform pointB;  // Set this to the transform of point B

    private Transform playerTransform;
    private Vector3 startPosition;
    private Vector3 endPosition;
    public float travelTimeAB = 15f;  // Travel time from point A to B (15 seconds)
    private float currentTime = 0f;

    private enum MovementState
    {
        MovingToB
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
        }
    }
}
