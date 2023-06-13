using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OculusSampleFramework;

public class SmudgeEndController : MonoBehaviour
{
    // Start is called before the first frame update
    public int stage = 1;

    public OVRInput.Button b1 = OVRInput.Button.One;
    public OVRInput.Button b2 = OVRInput.Button.Two;
    public OVRInput.Button b3 = OVRInput.Button.Three;
    public OVRInput.Button b4 = OVRInput.Button.Four;
    public ParticleSystem bigRing;
    public ParticleSystem smallRing;
    public GameObject cedar;
    public GameObject sweetgrass;
    public GameObject sage;
    public GameObject ball1;
    public GameObject ball2;
    public GameObject ball3;
    public GameObject matchbox;
    public GameObject match;
    private Renderer ballRenderer;
    private Matchbox matchboxScript;
    private bool playedRing = false;
    private bool cooldown = false;
    private bool phase5;

    void Start()
    {
        matchboxScript = matchbox.GetComponent<Matchbox>();
        if (matchboxScript != null)
        {
            // Access the public int variable from the other script
            phase5 = matchboxScript.nextPhase;
            Debug.Log("Value of publicInt: " + phase5);
        }

    }
    
    void Update()
    {
        if (matchboxScript != null)
        {
            // Access the public int variable from the other script
            phase5 = matchboxScript.nextPhase;
            if(phase5){
                stage = 5;
            }
        }

        if(!cooldown){
            // 4s button cooldown

            // Check if the specified button is pressed on the Oculus Touch controller
            if (OVRInput.GetDown(b1) || OVRInput.GetDown(b2) || OVRInput.GetDown(b3) || OVRInput.GetDown(b4))
            {   
                //Highlight help tips
                HelpPlayer();
            }
        }
    }


    private void HelpPlayer(){
        StartCoroutine(Cooldown());
        playedRing = false;

        // During gifting phase
        if(stage == 1 || stage == 2 || stage == 3){

            // Check for each of the 3 ball positions if they are still being rendered, if true, play a ring there.

            Vector3 ballPosition = ball1.transform.position;

            ballRenderer = ball1.GetComponent<Renderer>();
            if(IsBallVisible()){
                ballPosition = ball1.transform.position;
            }

            ballRenderer = ball2.GetComponent<Renderer>();
            if(IsBallVisible()){
                ballPosition = ball2.transform.position;
            }

            ballRenderer = ball3.GetComponent<Renderer>();
            if(IsBallVisible()){
                ballPosition = ball3.transform.position;
            }

            PlaySmallRing(ballPosition);

            // if stage == 1
            Vector3 bigPosition = sage.transform.position;
            
            if(stage == 2){
                bigPosition = sweetgrass.transform.position;
            }

            if(stage == 3){
                bigPosition = cedar.transform.position;
            }
            
            StartCoroutine(delayBigRing(bigPosition));
    
        }

        if(stage == 4){
            Vector3 matchPosition = match.transform.position;
            Vector3 matchboxPosition = matchbox.transform.position;
            PlaySmallRing(matchPosition);
            StartCoroutine(delaySmallRing(matchboxPosition));

        }
    }

    // Plays small ring animation
    private void PlaySmallRing(Vector3 position)
    {
        ParticleSystem particleSystemInstance = Instantiate(smallRing, position, Quaternion.identity);
        particleSystemInstance.Play();
    }

    // Plays big ring animation
    private void PlayBigRing(Vector3 position)
    {
        // Increase height to be above floor
        position += new Vector3(0f, 1, 0f);
        ParticleSystem particleSystemInstance = Instantiate(bigRing, position, Quaternion.identity);
        particleSystemInstance.Play();
    }

    // Waits for 2 seconds before playing a big ring
    private IEnumerator delayBigRing(Vector3 position)
    {
        yield return new WaitForSeconds(2f);
        PlayBigRing(position);
    }

    // Waits for 2 seconds before playing a small ring
    private IEnumerator delaySmallRing(Vector3 position)
    {
        yield return new WaitForSeconds(2f);
        PlaySmallRing(position);
    }

    // Return if a ball is rendered
    private bool IsBallVisible()
    {
        if (ballRenderer != null)
        {
            // Check if the ball1 GameObject's mesh is visible
            return ballRenderer.isVisible;
        }

        // Return false if Renderer component is not found
        return false;
    }

    // 4 second cooldown on button
    private IEnumerator Cooldown()
    {
        cooldown = true;
        yield return new WaitForSeconds(4f);
        cooldown = false;
    }

}
