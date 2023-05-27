using UnityEngine;

public class WateringInteraction : MonoBehaviour
{
    public GameObject wateringCanPrefab; // Prefab of the watering can
    public Transform spawnPoint; // Point where the watering can will be spawned

    private GameObject currentWateringCan; // Reference to the spawned watering can

    private void Update()
    {
        // Check for interaction input (e.g., button press)
        if (Input.GetButtonDown("Interact"))
        {
            // Check if there is no active watering can
            if (currentWateringCan == null)
            {
                // Spawn the watering can at the designated spawn point
                currentWateringCan = Instantiate(wateringCanPrefab, spawnPoint.position, spawnPoint.rotation);
            }
        }
    }
}