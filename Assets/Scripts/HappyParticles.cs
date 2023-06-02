using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HappyParticles : MonoBehaviour
{
    public ParticleSystem ps;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Check if the left mouse button is clicked
        if (Input.GetMouseButtonDown(0))
        {
            // Play the particle system
            ps.Play();
            Debug.Log("Play");
        }

    }
}
