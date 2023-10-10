using System.Collections;
using UnityEngine;

public class LaserShootUp : MonoBehaviour
{
    public GameObject startPoint; // The GameObject from which the laser starts
    public GameObject pulsatingLight; // The GameObject with a Light component for pulsating effect
    public float laserExtendSpeed = 1.0f; // Speed at which the laser extends
    public float maxLaserLength = 10f; // Maximum length the laser can have
    public float minLightIntensity = 1f; // Minimum light intensity
    public float maxLightIntensity = 4f; // Maximum light intensity
    public float pulseSpeed = 1f; // Speed of the light pulse

    private LineRenderer lineRenderer;
    private Light lightComponent;
    private float currentLaserLength = 0f;

    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lightComponent = pulsatingLight.GetComponent<Light>();
        lineRenderer.enabled = true;

        Vector3 worldStartPosition = startPoint.transform.position;
        lineRenderer.SetPosition(0, worldStartPosition);
        lineRenderer.SetPosition(1, worldStartPosition);

        StartCoroutine(ExtendLaser());
        StartCoroutine(PulseLight());
    }

    IEnumerator ExtendLaser()
    {
        Vector3 worldStartPosition = startPoint.transform.position;

        while (currentLaserLength < maxLaserLength)
        {
            currentLaserLength += laserExtendSpeed * Time.deltaTime;

            Vector3 newEndPoint = new Vector3(
                worldStartPosition.x,
                worldStartPosition.y + currentLaserLength,
                worldStartPosition.z);

            lineRenderer.SetPosition(1, newEndPoint);

            // Update the position of the pulsating light
            pulsatingLight.transform.position = newEndPoint;

            yield return null;
        }
    }

    IEnumerator PulseLight()
    {
        float lerpTime = Mathf.PingPong(Time.time * pulseSpeed, 1);
        while (true)
        {
            lerpTime = Mathf.PingPong(Time.time * pulseSpeed, 1);
            lightComponent.intensity = Mathf.Lerp(minLightIntensity, maxLightIntensity, lerpTime);
            yield return null;
        }
    }
}
