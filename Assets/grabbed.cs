using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grabbed : MonoBehaviour
{
    public HandManager handManager;
    public GameObject hand;
    public bool isGrabbed;

    // Start is called before the first frame update
    void Start()
    {            
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger");
        if (other.CompareTag("Hand"))
        {        Debug.Log("Hand");

            isGrabbed = true;
            handManager.OnTreeGrabbed();
        }
    }


}
