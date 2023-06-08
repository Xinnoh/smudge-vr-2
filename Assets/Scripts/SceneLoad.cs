using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneLoad : MonoBehaviour
{
  public bool backAgain;
  GameObject[] objects1;
  GameObject[] objects2;
  GameObject[] objects3;

    // Start is called before the first frame update
    void Update()
    {
      if(backAgain){
        OnLoad();
      }
    }

    public void OnLoad()
    {
      if(backAgain){
        objects1 = GameObject.FindGameObjectsWithTag("Scene2 only");
        for(int i = 0; i< objects1.Length; i++){
          objects1[i].SetActive(true);
        }
        objects2 = GameObject.FindGameObjectsWithTag("Pouch");
        for(int i = 0; i< objects2.Length; i++){
          objects2[i].SetActive(true);
        }
        objects3 = GameObject.FindGameObjectsWithTag("scene1 only");
        for(int i = 0; i< objects3.Length; i++){
          objects3[i].SetActive(false);
        }
      }
      if(!backAgain){
        objects1 = GameObject.FindGameObjectsWithTag("Scene2 only");
        for(int i = 0; i< objects1.Length; i++){
          objects1[i].SetActive(false);
        }
        objects2 = GameObject.FindGameObjectsWithTag("Pouch");
        for(int i = 0; i< objects2.Length; i++){
          objects2[i].SetActive(false);
        }
        objects3 = GameObject.FindGameObjectsWithTag("scene1 only");
        for(int i = 0; i< objects3.Length; i++){
          objects3[i].SetActive(true);
        }
      }
    }
}
