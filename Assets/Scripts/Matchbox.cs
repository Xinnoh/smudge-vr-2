using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Matchbox : MonoBehaviour
{
    public ParticleSystem particleEffect;  // The particle effect to play
    private bool matchLit = false;  // Ensures the effect only plays once
    public bool nextPhase = false;
    
    public GameObject stateManager;

    // Start is called before the first frame update
    void Start()
    {
            var emission = particleEffect.emission;
            emission.enabled = false;

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
    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collision");

        // Check if we've collided with the target object and haven't already triggered the effect
        if (collision.gameObject.CompareTag("Match"))
        {
            // If so, play the particle effect and mark the collision as having happened
            var emission = particleEffect.emission;
            emission.enabled = true;
        }
    }


    void OnTriggerEnter(Collider other)
    {
        if(!matchLit){
            if (other.gameObject.CompareTag("Match"))
            {
                // If so, play the particle effect and mark the collision as having happened
                var emission = particleEffect.emission;
                emission.enabled = true;
            }
        }

        if (other.gameObject.CompareTag("Bowl"))
        {
            Debug.Log("True");
            nextPhase = true;
        }
    

    }
    

}
