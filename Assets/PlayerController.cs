using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Transform pointA;  // Set this to the transform of point A
    public Transform pointB;  // Set this to the transform of point B
    public float speed = 5.0f; // Public speed variable that you can adjust in the Inspector

    private Transform playerTransform;
    private Vector3 startPosition;
    private Vector3 endPosition;
    private float currentTime = 0f;

    private void Start()
    {
        playerTransform = transform; // Assuming the script is on the XR Rig GameObject itself
        startPosition = pointA.position;
        endPosition = pointB.position;
    }

    private void Update()
    {
        currentTime += Time.deltaTime;

        // Calculate the interpolation value (0 to 1) based on time
        float t = Mathf.Clamp01(currentTime / speed);

        // Move the player smoothly from A to B
        playerTransform.position = Vector3.Lerp(startPosition, endPosition, t);
    }
}
