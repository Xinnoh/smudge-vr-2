using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SageTake : MonoBehaviour
{

    // This script plays a particle system when touched.
    public ParticleSystem targetSystem; // Plant Particle System
    public ParticleSystem targetSystem2; // If using 2 systems for effect
    public ParticleSystem handSystem;   // Burst from hand
    public ParticleSystem emberSystem;  // Permanent embers
    public int WatchTime = 3;
    public int waitTime2 = 1;
    public int startDelay = 2;
    public ParticleSystem giftEffect;
    public int endSpeed = 20;

    public int order;

    private bool doOnce = false;
    private SmudgeEndController otherScript;
    private int stage;
    public GameObject stateManager;


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
        otherScript = stateManager.GetComponent<SmudgeEndController>();

        if (otherScript != null)
        {
            // Access the public int variable from the other script
            stage = otherScript.stage;
            Debug.Log("Value of publicInt: " + stage);
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (otherScript != null)
        {
            // Access the public int variable from the other script
            stage = otherScript.stage;
        }
    }

        private void OnTriggerEnter(Collider other)
    {

        Debug.Log(other.gameObject.tag);
        // Check if the object that triggered the event is the user's hand
        // This assumes your hand object is tagged with "Hand"

        if (other.gameObject.tag == "Sage")
        {
            if(stage == order)
            {
                Debug.Log("True");
                if(!doOnce)
                {
                    Instantiate(giftEffect, other.transform.position, other.transform.rotation);

                    Renderer objectRenderer = other.gameObject.GetComponent<Renderer>();
                    if (objectRenderer != null)
                    {
                        objectRenderer.enabled = false;
                    }

                    StartSequence();
                    otherScript.stage += 1;
                    doOnce = true;
                }
            }
            else{
                Debug.Log("False");
                Debug.Log(stage);
                Debug.Log(order);
            }
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

        // Wait X seconds then start

        yield return new WaitForSeconds(WatchTime);

        // emission.enabled = false;
        // emission2.enabled = false;

        // Disable after X seconds
        
        yield return new WaitForSeconds(waitTime2);

        hand.enabled = true;
        emission.rateOverTime = endSpeed;

        // Enable temporary particles on hand after X seconds

        yield return new WaitForSeconds(WatchTime);

        hand.enabled = false;
        ember.enabled = true;

        // Disable temporary particles, enable permanent embers


    }

}
