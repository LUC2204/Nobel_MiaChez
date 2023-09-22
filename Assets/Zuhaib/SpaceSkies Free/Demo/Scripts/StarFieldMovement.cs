using UnityEngine;

public class StarFieldMovement : MonoBehaviour
{
    public float scrollSpeed = 1.0f;

    private void Update()
    {
        // Move the star field in the desired direction
        transform.Translate(Vector3.forward * scrollSpeed * Time.deltaTime);
    }
}
