using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapToStart : MonoBehaviour
{
    public int speed;
     void Update()
    {
      if (Input.anyKey)
        {

            GameObject.Find("Sphere").GetComponent<Move>().speed = speed;
            this.gameObject.SetActive(false);

        }   
    }
}
