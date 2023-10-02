using System.Collections;
using UnityEngine;

public class LaserShoot : MonoBehaviour
{
    public float laserLength = 100f;
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

        yield return new WaitForSeconds(0.02f);

        lineRenderer.enabled = false;
    }
}
