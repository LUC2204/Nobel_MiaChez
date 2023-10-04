using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    public string SceneToLoad;

    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {        
            SceneManager.LoadScene(SceneToLoad);
        }
    }
}




