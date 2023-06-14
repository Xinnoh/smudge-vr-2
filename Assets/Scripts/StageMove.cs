using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageMove : MonoBehaviour
{
  public GameObject manager;
  public int stage;
  private SmudgeManager controller;
  private bool canTouch = false;

  void Start(){
    controller = manager.gameObject.GetComponent<SmudgeManager>();
      System.Action enableTouch = ()=>{canTouch = true;};
      FunctionTimer.Create(enableTouch, 47f);

  }
  private void OnTriggerEnter(Collider other){
    if(other.tag == "Hand" && canTouch){
      Debug.Log("Stage attempt");
      if(controller.stage == (stage-1)){
        Debug.Log("moved");
        controller.stage +=1;
        controller.stageActive = true;
      }
    }
  }
}
