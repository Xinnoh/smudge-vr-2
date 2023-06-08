using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnToPreviousScene : MonoBehaviour
{
    private int previousSceneIndex;

    private void Start()
    {
        // Get the index of the previous scene
        previousSceneIndex = SceneManager.GetActiveScene().buildIndex - 1;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Load the previous scene
            SceneManager.LoadScene(previousSceneIndex);
        }
    }
}