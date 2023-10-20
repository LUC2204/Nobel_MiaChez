using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class AdaptiveOptics : MonoBehaviour
{
    public Image monitorImage; 
    public Sprite initialPicture; 
    public Sprite updatedPicture; 
    public AudioSource audioSource; 
    public Text buttonText;
    public GameObject[] gameObjectsToActivate;
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

        // Make the text on the button disappear
        if (buttonText != null)
        {
            buttonText.text = "";
        }

        foreach (GameObject go in gameObjectsToActivate)
        {
            go.SetActive(true);
        }

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
        //SceneManager.LoadScene("Space Galaxy Scene"); // Replace with your scene name or index
    }
}
    