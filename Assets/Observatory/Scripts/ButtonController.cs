using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using BNG;

public class ButtonController : MonoBehaviour
{
    public TelescopeRotation telescopeRotation; // Reference to the TelescopeRotation script
    public GameObject playerObject; // Reference to the GameObject with Player Gravity Component
    private PlayerGravity playerGravity; // Reference to the PlayerGravity component

    private UnityEngine.UI.Button button; // Use the fully qualified name

    void Start()
    {
        // Get the UnityEngine.UI.Button component attached to this GameObject
        button = GetComponent<UnityEngine.UI.Button>(); // Use the fully qualified name

        // Add a listener to the button's onClick event
        button.onClick.AddListener(StartTelescopeRotation);

        // Get the PlayerGravity component from the playerObject
        playerGravity = playerObject.GetComponent<PlayerGravity>();
    }

    void StartTelescopeRotation()
    {
        // Call the StartRotation function of the TelescopeRotation script
        if (telescopeRotation != null)
        {
            telescopeRotation.StartRotation();
        }

        // Disable the Player Gravity Component
        if (playerGravity != null)
        {
            playerGravity.enabled = false;

            // Start a coroutine to enable the Player Gravity Component after 30 seconds
            StartCoroutine(EnablePlayerGravityAfterDuration());
        }
        else
        {
            Debug.LogError("Player Gravity Component not found on the playerObject.");
        }
    }

    IEnumerator EnablePlayerGravityAfterDuration()
    {
        yield return new WaitForSeconds(30f); // Wait for 30 seconds

        // Re-enable the Player Gravity Component
        if (playerGravity != null)
        {
            playerGravity.enabled = true;
        }
    }
}
