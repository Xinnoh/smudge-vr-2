using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceUpwardsEnd : MonoBehaviour
{
    private void LateUpdate()
    {
        // Set the rotation to always face upwards
        transform.rotation = Quaternion.LookRotation(Vector3.up);
    }
}
