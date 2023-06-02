using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    public string[] sceneNames; // Array of scene names to load

    private int currentSceneIndex = 0; // Index of the current scene to load

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (currentSceneIndex < sceneNames.Length - 1)
            {
                SceneManager.LoadScene(sceneNames[currentSceneIndex]);
                currentSceneIndex++;
            }
            else if (currentSceneIndex == sceneNames.Length - 1)
            {
                SceneManager.LoadScene(sceneNames[currentSceneIndex]);
            }
            else
            {
                Debug.Log("All scenes have been loaded.");
                // Optionally, reset the currentSceneIndex to 0 if you want to loop back to the first scene
            }
        }
    }
}