using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    // Update is called once per frame
    public void Destroy_Cube()
    {
        this.gameObject.GetComponentInChildren<platform_snake>().Timer_ = false;
        StartCoroutine( Destroy_() );
    }
    IEnumerator Destroy_()
    {
        
        yield return new WaitForSeconds(0.5f);

        Destroy(this.gameObject);
    }
}

