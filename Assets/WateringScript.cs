using UnityEngine;

public class WateringScript : MonoBehaviour
{
    public GameObject plantObject;         // Reference to the plant object
    public GameObject grownPlantObject;    // Reference to the grown plant object
    public float growthTime = 10f;         // Time it takes for the plant to grow after watering

    private bool isWatering = false;       // Flag to track if the plant is being watered

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Plant"))
        {
            isWatering = true;
            Invoke("ChangePlantModel", growthTime);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Plant"))
        {
            isWatering = false;
            CancelInvoke("ChangePlantModel");
        }
    }

    private void ChangePlantModel()
    {
        if (isWatering)
        {
            plantObject.SetActive(false);
            grownPlantObject.SetActive(true);
            Debug.Log("Plant has grown!");
        }
    }
}