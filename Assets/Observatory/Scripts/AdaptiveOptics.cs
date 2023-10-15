using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class AdaptiveOptics : MonoBehaviour
{
    public Image monitorImage; // Reference to the Image component displaying the picture
    public Sprite initialPicture; // The initial picture
    public Sprite updatedPicture; // The picture to display after clicking the button
    public AudioSource audioSource; // Reference to the AudioSource component
    private bool pictureChanged = false;

    private void Start()
    {
        if (monitorImage == null || initialPicture == null || updatedPicture == null)
        {
            Debug.LogError("Please assign the monitorImage and both pictures in the Inspector.");
            return;
        }

        // Display the initial picture
        DisplayInitialPicture();

        // Add a click listener to the button
        Button button = GetComponent<Button>();
        if (button != null)
        {
            button.onClick.AddListener(ChangePictureOnClick);
        }
    }

    private void ChangePictureOnClick()
    {
        if (!pictureChanged)
        {
            // Display the updated picture
            DisplayUpdatedPicture();
        }

        // Play the audio when the button is pressed
        if (audioSource != null)
        {
            audioSource.Play();
        }

        // Start a coroutine to change the scene after a delay
        StartCoroutine(ChangeSceneAfterDelay(16f)); // Change to the desired scene delay
    }

    private void DisplayInitialPicture()
    {
        monitorImage.sprite = initialPicture;
        pictureChanged = false;
    }

    private void DisplayUpdatedPicture()
    {
        monitorImage.sprite = updatedPicture;
        pictureChanged = true;
    }

    private IEnumerator ChangeSceneAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);

        // Change to the desired scene
        SceneManager.LoadScene("Space Galaxy Scene"); // Replace with your scene name or index
    }
}
