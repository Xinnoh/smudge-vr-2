using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneLoad : MonoBehaviour
{
  public bool backAgain;
  GameObject[] objects;
    // Start is called before the first frame update
    void OnLoad()
    {
      if(backAgain){
        objects = GameObject.FindGameObjectsWithTag("Scene2 only");
        for(int i = 0; i< objects.Length; i++){
          objects[i].SetActive(true);
        }
        objects = GameObject.FindGameObjectsWithTag("Scene1 only");
        for(int i = 0; i< objects.Length; i++){
          objects[i].SetActive(false);
        }
      }
      if(!backAgain){
        objects = GameObject.FindGameObjectsWithTag("Scene2 only");
        for(int i = 0; i< objects.Length; i++){
          objects[i].SetActive(false);
        }
        objects = GameObject.FindGameObjectsWithTag("Scene1 only");
        for(int i = 0; i< objects.Length; i++){
          objects[i].SetActive(true);
        }
      }
    }
}
