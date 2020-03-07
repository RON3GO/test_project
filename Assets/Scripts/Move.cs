using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Move : MonoBehaviour
{
    public GameObject[] platform;
    bool z_x;

    public int difficulty;
    public GameObject last;
    public bool Tourne;

    public int count_;// порядок
    public bool First_Time;//для  дублирования платформ в первый раз
    void Start()
    {
        GameObject.Find("Cube 0").GetComponentInChildren<platform_snake>().Null_xyz();
        First_Time = true;
        Tourne = true;
        difficulty = 1;
        count_ = 1;
        z_x = false;
        
    }
    public float speed;
 
    // Update is called once per frame
    void Update()
    {
        this.GetComponent<Rigidbody>().velocity = new Vector3(0, -10f, 0);
        if (this.transform.position.y < -20)
            SceneManager.LoadScene(1);
        if (Input.GetMouseButtonDown(0))
        {
            z_x = !z_x;
        }

        if (z_x) Key_W();
        if (!z_x)Key_D();
    }
    void Key_W()
    {
        this.GetComponent<Rigidbody>().velocity = new Vector3(0, -10, speed+difficulty*5); 
    }


    void Key_D()
    {
        this.GetComponent<Rigidbody>().velocity = new Vector3(speed + difficulty * 5, -10, 0);

    }
}
