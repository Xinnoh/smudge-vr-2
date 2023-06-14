using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EmissionController : MonoBehaviour
{
    public GameObject system1;
    public GameObject system2;
    public GameObject system3;
    public GameObject system4;
    public GameObject system5;
    private ParticleSystem[] particleSystems; // Internal array to manage ParticleSystems
    private const int MaxRate = 20;

    private int particleCounter = 0;

    void Start()
    {
        
        // Initialize internal array and disable all particle systems
        particleSystems = new ParticleSystem[] { 
            system1.GetComponent<ParticleSystem>(), 
            system2.GetComponent<ParticleSystem>(), 
            system3.GetComponent<ParticleSystem>(), 
            system4.GetComponent<ParticleSystem>(), 
            system5.GetComponent<ParticleSystem>() 
        };
        
        foreach (var ps in particleSystems)
        {
            var emission = ps.emission;
            emission.enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {

        // To increase the number of colours on the hand, increase this number by one.


        if (Input.GetMouseButtonDown(0)) 
        {
            SceneManager.LoadScene("smudgeEnd");
            particleCounter += 1;
            TurnOnSystem(particleCounter);
            Debug.Log(particleCounter);
        }

    }



    public void TurnOnSystem(int index)
    {
        var emission = particleSystems[index].emission;
        emission.enabled = true;
        UpdateEmissionRates();
    }

    public void TurnOffSystem(int index)
    {
        var emission = particleSystems[index].emission;
        emission.enabled = false;
        UpdateEmissionRates();
    }


    private void UpdateEmissionRates()
    {
        int activeCount = 1;

        // Count the number of active particle systems
        foreach (var ps in particleSystems)
        {
            if (ps.emission.enabled)
            {
                activeCount++;
            }
        }

        int newRate = MaxRate / activeCount;
    
        foreach (var ps in particleSystems)
        {
            if (ps.emission.enabled)
            {
                var emission = ps.emission;
                emission.rateOverTime = newRate;
            }
        }
    }
}
