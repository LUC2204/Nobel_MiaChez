using UnityEngine;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
    public TelescopeRotation telescopeRotation; // Reference to the TelescopeRotation script

    private Button button;

    void Start()
    {
        // Get the Button component attached to this GameObject
        button = GetComponent<Button>();

        // Add a listener to the button's onClick event
        button.onClick.AddListener(StartTelescopeRotation);
    }

    void StartTelescopeRotation()
    {
        // Call the StartRotation function of the TelescopeRotation script
        if (telescopeRotation != null)
        {
            telescopeRotation.StartRotation();
        }
    }
}