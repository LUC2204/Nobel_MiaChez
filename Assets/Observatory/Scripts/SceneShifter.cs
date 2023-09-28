using UnityEngine;
using UnityEngine.UI;
public class SceneShifter : MonoBehaviour
{
    public string SceneToLoad;
    public Button buttonToClick; // Reference to the UI button
    private void Start()
    {
        // Attach a click event handler to the button
        buttonToClick.onClick.AddListener(ChangeSceneOnClick);
    }
    // Function to change the scene when the button is clicked
    private void ChangeSceneOnClick()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(SceneToLoad);
    }
}


