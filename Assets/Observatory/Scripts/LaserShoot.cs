using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class LaserShoot : MonoBehaviour
{
    public float laserLength = 100f;
    public float laserDuration = 0.02f;  // You can adjust this in the Inspector
    public UnityEvent OnLaserShootComplete;  // UnityEvent to be invoked when the laser shoot is complete

    private LineRenderer lineRenderer;

    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        StartCoroutine(ShootLaser());
    }

    IEnumerator ShootLaser()
    {
        lineRenderer.enabled = true;
        Vector3 laserEnd = transform.position + transform.forward * laserLength;

        lineRenderer.SetPosition(0, transform.position);
        lineRenderer.SetPosition(1, laserEnd);

        yield return new WaitForSeconds(laserDuration);

        lineRenderer.enabled = false;

        OnLaserShootComplete?.Invoke();  // Invoke the UnityEvent
    }
}
