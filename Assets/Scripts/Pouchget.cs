using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pouchget : MonoBehaviour
{
  public GameObject smudge;
    // Start is called before the first frame update
    void onCollisionEnter(Collider other)
    {
      if (other.CompareTag("Pouch"))
      {
          smudge.SetActive(true);
      }
    }

}
