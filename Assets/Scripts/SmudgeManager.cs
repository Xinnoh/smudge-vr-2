using System;
using UnityEngine.Audio;
using UnityEngine;

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
      FunctionTimer.Create(bakeC2, 20f);
      System.Action bakeC3 = ()=>{Play("C3");};
      FunctionTimer.Create(bakeC3, 45f);
      System.Action bakeC4 = ()=>{Play("C4");};
      FunctionTimer.Create(bakeC4, 56f);

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
    }
    //Play, plays a sond when called
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
        case 1:
          TurnOnSystem(1);
          TurnOnSystem(2);
          TurnOnSystem(3);
          System.Action bakeSage = ()=>{Play("C5");TurnOffSystem(1);TurnOffSystem(2);TurnOffSystem(3);};
          FunctionTimer.Create(bakeSage, 1f);
        break;
        case 2:
          TurnOnSystem(4);
          TurnOnSystem(5);
          TurnOnSystem(6);
          System.Action bakeSweet = ()=>{Play("C6");TurnOffSystem(4);TurnOffSystem(5);TurnOffSystem(6);};
          FunctionTimer.Create(bakeSweet, 5f);
        break;
        case 3:
          TurnOnSystem(7);
          TurnOnSystem(8);
          TurnOnSystem(9);
          TurnOnSystem(10);
          System.Action bakeCedar = ()=>{Play("C7");TurnOffSystem(7);TurnOffSystem(8);TurnOffSystem(9);TurnOffSystem(10);};
          FunctionTimer.Create(bakeCedar, 5f);
        break;
        case 4:
          Play("C9");
        break;
        case 5:
          Play("C10");
          System.Action bakeC11 = ()=>{Play("C11");};
          FunctionTimer.Create(bakeC11, 3f);
          System.Action bakeE = ()=>{Play("Eagle");};
          FunctionTimer.Create(bakeE, 8f);

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
