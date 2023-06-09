using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Matchbox : MonoBehaviour
{
    public GameObject targetObject;  // The object we're looking to collide with
    public GameObject targetObject2;  // The object we're looking to collide with

    public ParticleSystem particleEffect;  // The particle effect to play
    private bool hasTriggered = false;  // Ensures the effect only plays once

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))  // 0 corresponds to the left mouse button
        {
            var emission = particleEffect.emission;
            emission.enabled = true;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(!hasTriggered){
            Debug.Log("Trigger");

            // Check if we've collided with the target object and haven't already triggered the effect
            if (other.gameObject == targetObject)
            {
                Debug.Log("Collision");
                // If so, play the particle effect and mark the collision as having happened
                var emission = particleEffect.emission;
                emission.enabled = true;
                hasTriggered = true;
            }
        }
    }

    

}
