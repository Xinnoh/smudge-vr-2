using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageMove : MonoBehaviour
{
  public GameObject manager;
  public int stage;
  private SmudgeManager controller;

  void Start(){
    // controller = manager.gameObject.GetComponent<SmudgeManager>();
  }
  private void OnTriggerEnter(Collider other){
    if(other.tag == "Player"){
      if(controller.stage == (stage-1)){
        controller.stage +=1;
        controller.stageActive = true;
      }
    }
  }
}
