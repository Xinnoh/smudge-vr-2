using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pouch : MonoBehaviour
{
  SkinnedMeshRenderer skinnedMeshRenderer;
  Mesh skinnedMesh;
  int blendIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
      skinnedMeshRenderer = GetComponent<SkinnedMeshRenderer>();
      skinnedMesh = GetComponent<SkinnedMeshRenderer>().sharedMesh;
    }
  void onCollisionEnter(Collision col){
    if(!col.gameObject.CompareTag("Player")){
      skinnedMeshRenderer.SetBlendShapeWeight(0, 0);
      skinnedMeshRenderer.SetBlendShapeWeight(1, 100);
    }
  }

}
