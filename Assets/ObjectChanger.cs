using UnityEngine;

public class ObjectChanger : MonoBehaviour
{
    public GameObject newObject;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Water"))
        {
            Debug.Log("Particle System collision detected with water!");
            ChangeObject();
        }
    }

    private void ChangeObject()
    {
        // Replace the current object with the new object
        if (newObject != null)
        {
            Instantiate(newObject, transform.position, transform.rotation);
            Destroy(gameObject);
        }
        else
        {
            Debug.LogWarning("No new object assigned for replacement!");
        }
    }
}