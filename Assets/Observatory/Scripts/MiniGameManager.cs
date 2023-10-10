using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class MinigameManager : MonoBehaviour
{
    public Button[] buttons; // Reference to the buttons in the correct order
    public GameObject successScript; // Reference to the script to trigger on success
    public List<Light> buttonLights; // List of point lights associated with buttons
    public Color greenColor = Color.green; // Color for when the button is not clicked
    public Color redColor = Color.red; // Color for when the button is clicked

    private List<Button> clickedButtons = new List<Button>();
    private int currentButtonIndex = 0;

    private void Start()
    {
        // Set the initial color of the lights to green
        foreach (Light light in buttonLights)
        {
            light.color = greenColor;
        }

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
                // Change the color of the point light to red when clicked
                buttonLights[currentButtonIndex].color = redColor;
            }

            // Correct button clicked, add it to the clicked buttons list
            clickedButtons.Add(button);
            currentButtonIndex++;

            if (currentButtonIndex == buttons.Length)
            {
                // All buttons clicked in the correct order
                Success();
            }
        }
        else
        {
            // Incorrect button clicked, reset the sequence
            ResetSequence();
        }
    }

    private void ResetSequence()
    {
        clickedButtons.Clear();
        currentButtonIndex = 0;

        // Reset the color of all lights associated with buttons to green
        foreach (Light light in buttonLights)
        {
            light.color = greenColor;
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

        // Reset the sequence for the next round
        ResetSequence();
    }
}