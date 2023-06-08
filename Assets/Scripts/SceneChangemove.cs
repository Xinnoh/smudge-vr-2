using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class SceneChangeMove : MonoBehaviour
{
  public string[] sceneNames; // Array of scene names to load

  public AnimationCurve easingCurve;

  private int currentSceneIndex = 0; // Index of the current scene to load

  float elapsedTime = 0f;
  float duration = 100f;
  public Image image;
  public bool started;
  void Update () {
    if(started){
      StartCoroutine(Fade());

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
  IEnumerator Fade() {
    while (elapsedTime < duration) {
    float t = easingCurve.Evaluate(elapsedTime / duration);

    float newAlpha = Mathf.Lerp(0, 2, t);
    image.color = new Color(0, 0, 0, newAlpha);


          elapsedTime += Time.deltaTime;
          yield return null;

      }
      yield return new WaitForSeconds(3);
      started = false;
}

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
          started = true;
        }
    }
}
