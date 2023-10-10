using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Reflection;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;

public class mirrorJump: MonoBehaviour
{
    public Transform target; // Assign the target object in the Inspector

    // How many times it can reflect
    [SerializeField] private int maxReflectionCount = 3;
    // How Far the line goes
    [SerializeField] private float maxStepDistance = 200f;
    // The Line Renderer to use
    [SerializeField] private LineRenderer lineRenderer;
    // What gameObject the mirrors are a child of
    [SerializeField] private GameObject mirrors;


    [SerializeField] private Dictionary<int, Vector3> reflectionPoints;
    [SerializeField] private Material rend;

    private Vector3 initialPosition;

    private Transform _transform;
    private GameObject _gameObject;

    private Vector3[] vP;




    void Start()
    {
        //mirrors = GameObject.Find("/Mirrors");
        _transform = this.transform;
        _gameObject = _transform.gameObject;
        initialPosition = this.transform.position + this.transform.forward * 0.75f;
        this.transform.LookAt(target);

    }


    void Update()
    {
        this.transform.LookAt(target);
        // resets the points each update, to check and update mirror bounces.
        reflectionPoints = new Dictionary<int, Vector3>();

        // Damages or charges and creates the points for the beam, if they hit a mirror this function is called again, within itself adding all the mirrors the beam hits, infinitively.
        createBeam(this.transform.position + this.transform.forward * 0.75f, this.transform.forward, 1);

        // Creates the actuall Line renderer with shader attached.
        updateBeam();

    }

    private void updateBeam()
    {
        // adds as many points to the lineRenderer as it needs to create the full path.
        lineRenderer.positionCount = reflectionPoints.Count + 1;
        // Create an array for storing the points for the moment.
        Vector3[] pos = new Vector3[reflectionPoints.Count + 1];

        //UnityEngine.Debug.Log("lineRenderer.positionCount = " + reflectionPoints.Count); //Uncomment for debugging

        // Sets the first point of the lineRenderer to the origin (The gameObject)
        pos[0] = this._transform.position;

        // Iterates over the points stored in the dictionary.
        foreach (KeyValuePair<int, Vector3> position in reflectionPoints)
        {
            // Adds the points to the temporary array.
            pos[position.Key] = position.Value;
        }

        // Send the points to the lineRenderer for rendering.
        lineRenderer.SetPositions(pos);


    }

    //private void createBeam(Vector3 position, Vector3 direction, int reflectionsRemaining, int lineRendererCount)
    private void createBeam(Vector3 position, Vector3 direction, int lineRendererCount)
    {
        // If true the beam hits a mirror, initial state = false
        bool mirrored = false;

        // For debugging
        Vector3 startingPosition = position;


        // Cast a ray, get hit, if hit = true, check for what was hit.
        Ray ray = new Ray(position, direction);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, maxStepDistance))
        {
            // Adds the direction of the reflection of mirrors and the point where it hits.
            direction = Vector3.Reflect(direction, hit.normal);
            position = hit.point;

            // If a mirror is hit
            if (hit.collider.gameObject.transform.IsChildOf(mirrors.transform))
            {
                // Hits a mirror so state = true
                mirrored = true;
            }

        }
        else
        {
            // If nothing is hit, while mirrored, create a beam wherever it's mirrored.
            position += direction * maxStepDistance;
        }

        // Debug line
        //UnityEngine.Debug.DrawLine(startingPosition, position, Color.red);

        // Add a reflectionPoint, (Adds a point where the village or charge tower is hit aswell, but does not bounce off them)
        reflectionPoints.Add(lineRendererCount, position);

        // If mirrored create another beam in the mirrored direction
        if (mirrored)
            createBeam(position, direction, lineRendererCount + 1);
    }

    // Destroys itself after given time
    IEnumerator DestroySelfAfterSeconds(float destroyTime)
    {
        yield return new WaitForSeconds(destroyTime);
        Destroy(_gameObject);
    }
}
