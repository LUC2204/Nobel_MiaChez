using System.Collections;
using UnityEngine;

public class LaserShootUp : MonoBehaviour
{
    public GameObject startPoint; // Drag your starting GameObject here in the inspector
    public float laserExtendSpeed = 1.0f; // Speed at which the laser extends along the y-axis
    public float maxLaserLength = 10f; // The maximum length the laser can achieve
    private LineRenderer lineRenderer;
    private float currentLaserLength = 0f;

    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.enabled = true; // Enable the LineRenderer
        lineRenderer.SetPosition(0, startPoint.transform.position); // Start position
        lineRenderer.SetPosition(1, startPoint.transform.position); // End position (same as start initially)

        StartCoroutine(ExtendLaser());
    }

    IEnumerator ExtendLaser()
    {
        while (currentLaserLength < maxLaserLength)
        {
            currentLaserLength += laserExtendSpeed * Time.deltaTime; // Increase length
            Vector3 newEndPoint = startPoint.transform.position + new Vector3(0, currentLaserLength, 0); // Calculate new end point

            lineRenderer.SetPosition(1, newEndPoint); // Set the new end point

            yield return null; // Wait until the next frame
        }
    }
}
