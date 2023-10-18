using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class MinigameManager : MonoBehaviour
{
    public List<Button> buttons; // Reference to the buttons in the correct order
    public GameObject successScript; // Reference to the script to trigger on success
    public ObservatoryRotate observatoryRotate; // Reference to the ObservatoryRotate script
    public List<Light> buttonLights; // List of point lights associated with buttons

    public Color greenColor = Color.green; // Color for when the button is not clicked
    public AudioSource audioSource1;
    public AudioClip successAudioClip;
    public GameObject successObjectToActivate;

    private List<Button> clickedButtons = new List<Button>();
    private int currentButtonIndex = 0;

    private void Start()
    {

        // Attach click listeners to each button
        foreach (Button button in buttons)
        {
            Button currentButton = button; // Capture the current button in the loop
            currentButton.onClick.AddListener(() => OnButtonClick(currentButton));
        }
    }

    public void OnButtonClick(Button button)
    {
        if (button == buttons[currentButtonIndex])
        {
            if (currentButtonIndex >= 0 && currentButtonIndex < buttonLights.Count)
            {
                // Set the button color to green
                ColorBlock colors = button.colors;
                colors.pressedColor = greenColor;
                button.colors = colors;

                Debug.Log("Successfully pushed the right buttom");
                //button.gameObject.SetActive(false); // Do something when the button is pressed
                button.interactable = false;
            }

            
            // Correct button clicked, add it to the clicked buttons list
            clickedButtons.Add(button);
            currentButtonIndex++;
            
            if (currentButtonIndex == buttons.Count)
            {
                // All buttons clicked in the correct order
                Success();
            }
        }
        else
        {
            Debug.Log("Resetting buttons");
            // Incorrect button clicked, reset the sequence
           
        }
    }


    private void Success()
    {
        // Trigger the success script when the sequence is correct
        if (successScript != null)
        {
            TelescopeRotation telescopeRotation = successScript.GetComponent<TelescopeRotation>();
            if (telescopeRotation != null)
            {
                telescopeRotation.OnMinigameSuccess();
            }
        }

        // Trigger the additional success script if available
        if (observatoryRotate != null)
        {
            // Start the rotation in the ObservatoryRotate script
            observatoryRotate.StartRotation(30f); // You can pass the desired rotation angle
        }

        // Play the success audio clip
        if (audioSource1 != null && successAudioClip != null)
        {
            audioSource1.clip = successAudioClip;
            audioSource1.Play();
        }

        // Activate the success object
        if (successObjectToActivate != null)
        {
            successObjectToActivate.SetActive(true);
        }

        // Reset the sequence for the next round
        //ResetSequence();
    }
}