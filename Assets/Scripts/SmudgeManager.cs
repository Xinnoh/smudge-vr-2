using System;
using UnityEngine.Audio;
using UnityEngine;
using System.Collections;
using OculusSampleFramework;

public class SmudgeManager : MonoBehaviour
{
  public Sound[] sounds;
  public GameObject[] emmitters;
  private ParticleSystem[] particleSystems; // Internal array to manage ParticleSystems
  private AudioSource[] audioSources;
  public int stage;
  private const int MaxRate = 100;
  public bool stageActive;
    //Awake is called before Start()
  public NextScene compass;
    public ParticleSystem smallRing;
    private bool cooldown = false;
    
    public OVRInput.Button b1 = OVRInput.Button.One;
    public OVRInput.Button b2 = OVRInput.Button.Two;
    public OVRInput.Button b3 = OVRInput.Button.Three;
    public OVRInput.Button b4 = OVRInput.Button.Four;
    private bool canHelp;

    void Awake()
    {
      stage = 0;
      audioSources = gameObject.GetComponents<AudioSource>();
      sounds[0].source = audioSources[0];
      for(int i = 1; i < sounds.Length; i++){       //Create audiosources for all sound clips
        sounds[i].source = audioSources[1];
      }
      particleSystems = new ParticleSystem[emmitters.Length]; //sets particleSystems to be of the same length as emmitters

      for(int i = 0; i < emmitters.Length; i++){ //gets all emmitters and adds their ParticleSystems to particleSystems
        particleSystems[i] = emmitters[i].GetComponent<ParticleSystem>();
      }
      foreach (var ps in particleSystems)
      {
          var emission = ps.emission;
          emission.enabled = false;
      }
      TurnOnSystem(0);
    }

    // Start is called before the first frame update
    void Start()
    {
      Play("Music");
      System.Action bakeC2 = ()=>{Play("C2");};
      FunctionTimer.Create(bakeC2, 10f);
      System.Action bakeC3 = ()=>{Play("C3");};
      FunctionTimer.Create(bakeC3, 35f);
      System.Action bakeC4 = ()=>{Play("C4");};
      FunctionTimer.Create(bakeC4, 46f);

      System.Action bakeHelp = ()=>{canHelp = true;};
      FunctionTimer.Create(bakeHelp, 46f);
    }

    // Update is called once per frame
    void Update(){
      if (Input.GetMouseButtonDown(0))
      {
          stage += 1;
          Debug.Log("stage " + stage);
          stageActive = true;
      }
      if(stageActive){
        StageUpdate();

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
        Vector3 ringPos = new Vector3(1.0f, 2.0f, 3.0f);


        // During gifting phase
        if(stage == 0){
            ringPos = new Vector3(0.036f, 0.74f, 0.323f);
        }
        else if(stage == 1){
          ringPos = new Vector3(0.45f, 0.80f, -0.126f);
        }
        else if(stage == 2){
          ringPos = new Vector3(-0.05f, 0.80f, -0.47f);
        }
        else if(stage == 5){
          ringPos = new Vector3(-0.6f, 0.80f, .12f);
        }

        if(stage == 0 || stage == 1 || stage == 2 || stage == 5){

        }
        if(canHelp){
          PlaySmallRing(ringPos);
        }
    }

    //Play, plays a sound when called
    void Play(string name){
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

    //working on it ^^;
    public void Fade(string name, float volumeStart, float volumeEnd, float time){
      for(int i = 0; i < sounds.Length; i++){
        if(sounds[i].name == name){
          sounds[i].source.volume = volumeEnd;
        }
      }
    }

    //part that changes based on stage
    void StageUpdate(){
      switch(stage){

        case 0:
          
        break;

        // Start
        case 1:
          TurnOnSystem(1);
          TurnOnSystem(2);
          TurnOnSystem(3);
          System.Action bakeSage = ()=>{Play("C5");TurnOffSystem(1);TurnOffSystem(2);TurnOffSystem(3);};
          FunctionTimer.Create(bakeSage, 1f);
        break;
        // Sweetgrass
        case 2:
          TurnOnSystem(4);
          TurnOnSystem(5);
          TurnOnSystem(6);
          System.Action bakeSweet = ()=>{Play("C6");TurnOffSystem(4);TurnOffSystem(5);TurnOffSystem(6);};
          FunctionTimer.Create(bakeSweet, 5f);
        break;
        // Cedar
        case 3:
          TurnOnSystem(7);  //tree
          TurnOnSystem(8);  //tree 
          TurnOnSystem(9);  //plant
          TurnOnSystem(10); //hand
          System.Action bakeCedar = ()=>{Play("C7");TurnOffSystem(7);TurnOffSystem(8);TurnOffSystem(9);TurnOffSystem(10);};
          FunctionTimer.Create(bakeCedar, 5f);
        break;
        // Introduce
        case 4:
          Play("C9");
        break;
        // Compass
        case 5:
          Play("C10");
          System.Action bakeC11 = ()=>{Play("C11");};
          FunctionTimer.Create(bakeC11, 3f);
          System.Action bakeE = ()=>{Play("Eagle");};
          FunctionTimer.Create(bakeE, 8f);
          System.Action compassDone = ()=>{compass.complete = true;};
          FunctionTimer.Create(compassDone, 8f);

        break;
      }
      stageActive = false;
    }

    //Particle related functions
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


    // Plays small ring animation
    private void PlaySmallRing(Vector3 position)
    {
      
        position += new Vector3(0f, 0.4f, 0f);
        ParticleSystem particleSystemInstance = Instantiate(smallRing, position, Quaternion.identity);
        particleSystemInstance.Play();
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
    
    // 4 second cooldown on button
    private IEnumerator Cooldown()
    {
        cooldown = true;
        yield return new WaitForSeconds(2f);
        cooldown = false;
    }
}
