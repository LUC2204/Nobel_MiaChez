using UnityEngine;

public class ObservatoryRotate : MonoBehaviour
{
    public float rotationSpeed = 1.0f; // Speed of rotation

    // Unity event to start rotation
    public void StartRotation(float degrees)
    {
        // Rotate the GameObject around its y-axis
        transform.Rotate(new Vector3(0, degrees * rotationSpeed, 0));
    }
}
