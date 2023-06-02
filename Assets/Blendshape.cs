using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blendshape : MonoBehaviour
{
    SkinnedMeshRenderer skinnedMeshRenderer;
    Mesh skinnedMesh;
    int blendShapeCount;

    int playIndex = 0;
    float blend = 0;
    int blendIndex = 0;
    public int frames=1;
    public bool start = false;

    // Start is called before the first frame update
    void Start()
    {
      skinnedMeshRenderer = GetComponent<SkinnedMeshRenderer>();
      skinnedMesh = GetComponent<SkinnedMeshRenderer>().sharedMesh;
      blendShapeCount = skinnedMesh.blendShapeCount;
    }

    // Update is called once per frame
    void Update()
    {
      if(start){
        if(playIndex > 0) skinnedMeshRenderer.SetBlendShapeWeight(playIndex-1, 100f-(blendIndex*(100f/frames)));
        if(playIndex == 0) skinnedMeshRenderer.SetBlendShapeWeight(blendShapeCount-1,100f-(blendIndex*(100f/frames)));
        skinnedMeshRenderer.SetBlendShapeWeight(playIndex, (blendIndex*(100f/frames)));
        blendIndex ++;
        if(blendIndex >frames){
          if(playIndex > 0) skinnedMeshRenderer.SetBlendShapeWeight(playIndex-1, 0f);
          if(playIndex == 0) skinnedMeshRenderer.SetBlendShapeWeight(blendShapeCount-1, 0f);

          playIndex ++;
          if(playIndex >blendShapeCount -1){
            start = false;
             playIndex = 0;
           }
          blendIndex = 0;
        }
      }
  }
}
