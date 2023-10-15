using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class CanvasSwitcher : MonoBehaviour
{
    public Canvas firstCanvas;  // Reference to the first Canvas
    public Canvas secondCanvas; // Reference to the second Canvas
    public Canvas thirdCanvas;  // Reference to the third Canvas
    public Canvas fourthCanvas; // Reference to the fourth Canvas

    public Button firstCanvasButton;  // Button on the first Canvas to switch to the second Canvas
    public Button secondCanvasButton; // Button on the second Canvas to switch to the third Canvas
    public Button thirdCanvasButton;  // Button on the third Canvas to switch to the fourth Canvas

    private bool isSceneChanging = false;

    private void Start()
    {
        // Hide all canvases except the first one
        secondCanvas.gameObject.SetActive(false);
        thirdCanvas.gameObject.SetActive(false);
        fourthCanvas.gameObject.SetActive(false);

        // Add onClick listeners to the buttons
        firstCanvasButton.onClick.AddListener(ShowSecondCanvas);
        secondCanvasButton.onClick.AddListener(ShowThirdCanvas);
        thirdCanvasButton.onClick.AddListener(ShowFourthCanvas);
    }

    private void ShowSecondCanvas()
    {
        // Show the second Canvas
        secondCanvas.gameObject.SetActive(true);

        // Hide the first Canvas
        firstCanvas.gameObject.SetActive(false);
    }

    private void ShowThirdCanvas()
    {
        // Hide the second Canvas
        secondCanvas.gameObject.SetActive(false);

        // Show the third Canvas
        thirdCanvas.gameObject.SetActive(true);
    }

    private void ShowFourthCanvas()
    {
        // Hide the third Canvas
        thirdCanvas.gameObject.SetActive(false);

        // Show the fourth Canvas
        fourthCanvas.gameObject.SetActive(true);

        // Start the scene change coroutine after the third canvas button has been pressed
        if (!isSceneChanging)
        {
            isSceneChanging = true;
            StartCoroutine(ChangeSceneAfterDelay());
        }
    }

    private IEnumerator ChangeSceneAfterDelay()
    {
        yield return new WaitForSeconds(10f); // Wait for 5 seconds

        // Change the scene (replace "YourSceneName" with the actual scene name)
        SceneManager.LoadScene("Observatory");
    }
}