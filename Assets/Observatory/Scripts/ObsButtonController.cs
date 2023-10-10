using UnityEngine;
using UnityEngine.UI;

public class ObsButtonController : MonoBehaviour
{
    public ObservatoryRotate observatoryRotate; // Reference to the ObservatoryRotate script
    public float rotationDegrees = 45.0f; // Degrees to rotate when the button is clicked

    private Button button;

    void Start()
    {
        // Get the Button component attached to this GameObject
        button = GetComponent<Button>();

        // Add a listener to the button's onClick event
        button.onClick.AddListener(() => StartObjectRotation(rotationDegrees));
    }

    void StartObjectRotation(float degrees)
    {
        // Call the StartRotation function of the ObservatoryRotate script
        if (observatoryRotate != null)
        {
            observatoryRotate.StartRotation(degrees);
        }
    }
}
