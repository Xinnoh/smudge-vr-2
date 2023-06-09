using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchObject : MonoBehaviour
{

    // This script plays a particle system when touched.
    public ParticleSystem targetSystem; // Plant Particle System
    public ParticleSystem targetSystem2; // If using 2 systems for effect
    public ParticleSystem handSystem;   // Burst from hand
    public ParticleSystem emberSystem;  // Permanent embers
    public int WatchTime = 3;
    public int waitTime2 = 1;
    public int startDelay = 2;


    // Start is called before the first frame update
    void Start()
    {
        var emission = targetSystem.emission;
        var emission2 = targetSystem2.emission;
        var hand = handSystem.emission;
        var ember = emberSystem.emission;

        emission.enabled = false;
        emission2.enabled = false;
        hand.enabled = false;
        ember.enabled = false;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

        private void OnTriggerEnter(Collider other)
    {

        Debug.Log(other.gameObject.tag);
        // Check if the object that triggered the event is the user's hand
        // This assumes your hand object is tagged with "Hand"
        if (other.gameObject.tag == "Player")
        {
            StartSequence();
        }

    }


    private void StartSequence(){

        StartCoroutine(WaitAndPrint());


    }

        IEnumerator WaitAndPrint()
    {

        var emission = targetSystem.emission;
        var emission2 = targetSystem2.emission;
        var hand = handSystem.emission;
        var ember = emberSystem.emission;


        yield return new WaitForSeconds(startDelay);

        emission.enabled = true;
        emission2.enabled = true;

        yield return new WaitForSeconds(WatchTime);

        emission.enabled = false;
        emission2.enabled = false;
        
        yield return new WaitForSeconds(waitTime2);

        hand.enabled = true;

        yield return new WaitForSeconds(WatchTime);

        hand.enabled = false;
        ember.enabled = true;


    }


}
