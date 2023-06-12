using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FunctionTimer
{
    public static FunctionTimer Create(Action action, float timer){
      var hook = new GameObject("FunctionTimer", typeof(MonoBehaviourHook));
      FunctionTimer functionTimer = new FunctionTimer(action, timer, hook);
      hook.GetComponent<MonoBehaviourHook>().onUpdate = functionTimer.Update;
      return functionTimer;
    }
    private class MonoBehaviourHook : MonoBehaviour{
        public Action onUpdate;
        private void Update(){
          if(onUpdate != null) onUpdate();
        }
    }
    private Action action;
    private float timer;
    private GameObject gameObject;
    private bool done;

    private FunctionTimer(Action action, float timer, GameObject gameObject){
      this.action = action;
      this.timer = timer;
      this.gameObject = gameObject;
      done = false;
    }
    // Update is called once per frame
    void Update()
    {
      if(!done){
        timer -= Time.deltaTime;
        if(timer<0){
          action();
          done = true;
          UnityEngine.Object.Destroy(gameObject);
        }
    }
  }
}
