using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class NextScene : MonoBehaviour
{

    public ParticleSystem ring;
    public string nextSceneName;
    public bool complete = false;

     private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collided object tag: " + other.gameObject.tag);

        Debug.Log("Played1");

        if(complete){
            if (other.CompareTag("Hand"))
            {

                Debug.Log("Played2");
                // Play the ring effect
                var emission = ring.emission;
                emission.enabled = true;

                // Start the coroutine to load the next scene after a delay
                StartCoroutine(LoadSceneAfterDelay(2));
            }
        }
    }

    private IEnumerator LoadSceneAfterDelay(float delay)
    {
        
            Debug.Log("Played3");
        // Wait for the specified delay
        yield return new WaitForSeconds(delay);
        
            Debug.Log("Played4");
        // Load the next scene
        SceneManager.LoadScene(nextSceneName);
    }
}