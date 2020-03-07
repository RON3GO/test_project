using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diamond : MonoBehaviour
{
  
    void OnTriggerEnter(Collider other)
    {
       GameObject.Find("Canvas").transform.GetChild(0).GetComponent<Score>().PlusDiamonds();
        Destroy(this.gameObject);
    }
}