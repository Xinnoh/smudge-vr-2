using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceUpwards : MonoBehaviour
{
    private void LateUpdate()
    {
        // Set the rotation to always face upwards
        transform.rotation = Quaternion.LookRotation(Vector3.up);
    }
}
