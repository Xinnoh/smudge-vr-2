using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OculusSampleFramework;

public class HandManager : MonoBehaviour
{
    public ParticleSystem brown;

    // Update is called once per frame
    void start()
    {

        
    }

    void Update()
    {
    }

    


    public void OnTreeGrabbed(){
        var emission = brown.emission;
        emission.enabled = true;

    }
}
