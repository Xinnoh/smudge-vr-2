using UnityEngine;

public class PlantGrowth : MonoBehaviour
{
    public GameObject[] growthStages; // Array of game objects representing the different growth stages
    public float[] growthStageTimes; // Array of time durations for each growth stage
    public AudioSource growthSound; // Sound to play when the plant grows

    private int currentStageIndex = 0; // Index of the current growth stage
    private float currentStageTime = 0f; // Timer for the current growth stage

    private void Start()
    {
        // Set the initial growth stage
        SetGrowthStage(currentStageIndex);
    }

    private void Update()
    {
        // Increment the timer for the current growth stage
        currentStageTime += Time.deltaTime;

        // Check if the current growth stage time has passed
        if (currentStageTime >= growthStageTimes[currentStageIndex])
        {
            // Transition to the next growth stage
            TransitionToNextStage();
        }
    }

    private void TransitionToNextStage()
    {
        // Check if the current stage is the last stage
        if (currentStageIndex == growthStages.Length - 1)
        {
            // Plant has reached the final growth stage, no more transitions
            return;
        }

        // Move to the next growth stage
        currentStageIndex++;

        // Play the growth sound effect
        growthSound.Play();

        // Set the new growth stage
        SetGrowthStage(currentStageIndex);

        // Reset the stage timer
        currentStageTime = 0f;
    }

    private void SetGrowthStage(int stageIndex)
    {
        // Disable all growth stages
        foreach (GameObject stage in growthStages)
        {
            stage.SetActive(false);
        }

        // Enable the current growth stage
        growthStages[stageIndex].SetActive(true);
    }
}