using UnityEngine;
using UnityEngine.XR;

public class TeleportToPosition : MonoBehaviour
{
    [SerializeField] private Vector3 targetPosition;

    void Update()
    {
        // Check for input from the B button on the Oculus Touch controller
        if (Input.GetKeyDown(KeyCode.JoystickButton1) || Input.GetKeyDown(KeyCode.JoystickButton3))
        {
            // Teleport the player to the target position
            transform.position = targetPosition;
        }
    }
}