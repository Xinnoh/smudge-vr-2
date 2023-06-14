using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OculusSampleFramework;
using UnityEngine.Audio;

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
    public ParticleSystem ending;
    public ParticleSystem ending2;
    public ParticleSystem endingSmoke;
    private Renderer ballRenderer;
    private Matchbox matchboxScript;
    private bool cooldown = false;
    private AudioSource[] audioSources;
     public Sound[] sounds;

     private int localStage = 0;

    private bool phase5;

    void Start()
    {

        matchboxScript = matchbox.GetComponent<Matchbox>();

    }
    
    void Awake()
    {
      audioSources = gameObject.GetComponents<AudioSource>();
      sounds[0].source = audioSources[0];
      for(int i = 1; i < sounds.Length; i++){       //Create audiosources for all sound clips
        sounds[i].source = audioSources[1];
      }
    }


    void Update()
    {
        if(stage != localStage){
            stageChange();
            localStage = stage;
        }

        if (stage == 6)
        {
            StartCoroutine(EndSequence());
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

    private void stageChange(){

        if(stage == 1){
            System.Action b1 = ()=>{Play("C1");};
            FunctionTimer.Create(b1, 1f);
            System.Action b2 = ()=>{Play("C2");};
            FunctionTimer.Create(b2, 9f);
            System.Action b3 = ()=>{Play("C3");};
            FunctionTimer.Create(b3, 13f);
            System.Action b4 = ()=>{Play("C4");};
            FunctionTimer.Create(b4, 20f);
            System.Action b5 = ()=>{Play("C5");};
            FunctionTimer.Create(b5, 30f);
            System.Action b6 = ()=>{Play("C6");};
            FunctionTimer.Create(b6, 37f);
        }

        if(stage == 2){
            System.Action b7 = ()=>{Play("C7");};
            FunctionTimer.Create(b7, 3f);

            
        }
        if(stage == 3){
            System.Action b8 = ()=>{Play("C8");};
            FunctionTimer.Create(b8, 3f);
        }
        if(stage == 4){
            System.Action b9 = ()=>{Play("C9");};
            FunctionTimer.Create(b9, 3f);
            
        }
        if(stage == 5){
            System.Action b10 = ()=>{Play("C10");};
            FunctionTimer.Create(b10, 3f);
            System.Action b11 = ()=>{Play("C11");};
            FunctionTimer.Create(b11, 5f);
            System.Action b12 = ()=>{Play("C11");};
            FunctionTimer.Create(b12, 10f);
            
        }

        
    }


    private void Play(string name){
      for(int i = 0; i < sounds.Length; i++){
        if(sounds[i].name == name){
          sounds[i].source.clip = sounds[i].clip;
          sounds[i].source.volume = sounds[i].volume;
          sounds[i].source.spatialBlend = sounds[i].spatialBlend;
          sounds[i].source.Play();
          Debug.Log(name + " played");
        }
      }
    }


    private void HelpPlayer(){
        StartCoroutine(Cooldown());

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
        
        if(stage == 5){
            Vector3 matchPosition = match.transform.position;
            Vector3 abalonePosition = endingSmoke.transform.position;
            PlaySmallRing(matchPosition);
            StartCoroutine(delaySmallRing(abalonePosition));
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

    
    private IEnumerator EndSequence()
    {
        var smokeEmission = endingSmoke.emission;
        smokeEmission.enabled = true;


        yield return new WaitForSeconds(3f);

        var emission = ending.emission;
        emission.enabled = true;
        var emission2 = ending2.emission;
        emission2.enabled = true;

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
