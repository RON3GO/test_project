using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platform_snake : MonoBehaviour
{
    GameObject platform__;
    const int Period = 5; // Частота платформ с Очками 
    public bool Timer_ = true;
    void Update()
    {
        if ((this.transform.position.z + 3.5f < GameObject.Find("Sphere").transform.position.z) &&
           (this.transform.position.x + 3.5f < GameObject.Find("Sphere").transform.position.x) && Timer_)
        {
            OnTriggerEnter();
            OnTriggerExit();
        }

    }

    public GameObject[] platf;
    int Diamonds_;
    //порядок в цепочке
    int difficulty_plat;

    static Vector3 xyz_;
    public void Null_xyz()
    {
        xyz_ = new Vector3(0, -8.21f, 0);
    }

    bool tour;
    public int count
    {
        get
        {
            return GameObject.Find("Sphere").GetComponent<Move>().count_;
        }
        
        set
        {
            GameObject.Find("Sphere").GetComponent<Move>().count_ = value;
        }
    }
    char[] CubeNumber = { 'C', 'u', 'b', 'e', ' ' };
    static int prov;
    void OnTriggerEnter()
    {

        Debug.Log("+"+this.transform.parent.name.Trim(CubeNumber));
        if (int.Parse(this.transform.parent.name.Trim(CubeNumber)) % 12 == 0) Roll();
    }



    public int[] abc = new int[9];
    void Roll()
    {
        platf = GameObject.Find("Sphere").GetComponent<Move>().platform;
        tour = GameObject.Find("Sphere").GetComponent<Move>().Tourne;

        difficulty_plat = GameObject.Find("Sphere").GetComponent<Move>().difficulty;
        GameObject.Find("Sphere").GetComponent<Move>().last = this.gameObject;
        switch (difficulty_plat)
            {
                case (1):
                    DiffOne();
                    break;

                case (2):
                    DiffTwo();
                    break;

                case (3):
                default:
                    DiffThree();
                    break;
            }

        GameObject.Find("Sphere").GetComponent<Move>().Tourne = tour;

        if (GameObject.Find("Sphere").GetComponent<Move>().First_Time) {
            switch (difficulty_plat)
            {
                case (1):
                    DiffOne();
                    break;

                case (2):
                    DiffTwo();
                    break;

                case (3):
                default:
                    DiffThree();
                    break;
            }
            
            GameObject.Find("Sphere").GetComponent<Move>().Tourne = tour;
            GameObject.Find("Sphere").GetComponent<Move>().First_Time = false;
        }
        

    }

    int i;
    public int j;
    void DiffOne()
    {
        int[] abc = new int[] { 3, 3, 3, 3,0 , 0 , 0 ,0 ,0 };
        for (i = 0; i <= 8; i++)
        {
            if (abc[i] == 0) continue;

            for (k = 1; k <= abc[i]; k++)
            {
                if (tour) xyz_.z += 7;
                else xyz_.x += 7;
                Diamonds_ = Random.Range(1, Period);
                platform__ = Instantiate(platf[Diamonds_ - 1], xyz_, Quaternion.identity);
                platform__.name = "Cube " + count.ToString();
                count++;
            }
            tour = !tour;

        }
        GameObject.Find("Sphere").GetComponent<Move>().Tourne = tour;

    }

    public int m, u,k;
    void DiffTwo()
    {
        k = Random.Range(1, 3);
        if (k == 1) { abc = new int[9] { 2, 2, 2, 2, 2, 2,0,0,0}; }
        else
        {
            abc = new int[9] { 2, 2, 2, 3, 3, 0, 0, 0, 0 };
            for (i = 0; i <= 8; i++)
            {
                k = abc[i];
                j = Random.Range(0, 9);
                abc[i] = abc[j];
                abc[j] = k;
            }
        }

        for (i = 0; i <= 8; i++)
        {
            if (abc[i] == 0) continue;

            for (k = 1; k <= abc[i]; k++)
            {
                if (tour) xyz_.z += 7;
                else xyz_.x += 7;
                Diamonds_ = Random.Range(1, Period+1);
                platform__ = Instantiate(platf[Diamonds_ - 1], xyz_, Quaternion.identity);
                platform__.name = "Cube " + count.ToString();
                count++;
            }
            tour = !tour;

        }
    }
    void DiffThree()
    {
        abc = new int[9];
        k = Random.Range(4, 8);
        for (i=0;i < k; i++)
            abc[i] = 1;
        j = 12 - k;
        u += k;
        if ((j - 3) % 2 == 0)
        {
            abc[k] = 3;
            u += abc[k];
            for (i = k + 1; i < 9; i++)
            {
                abc[i] = 2;
                u += abc[i];
            }
        }
        else for (i = k; i < 9; i++)
            {
                abc[i] = 2;
                u += abc[i];
            }

        if (u > 12)
        {
            abc[8] = 0;
            for (i = 0; i < 8; i++) {
                k = abc[i];
                j = Random.Range(0, 8);
                abc[i] = abc[j];
                abc[j] = k;
                    }
        }
        else
        {
            for (i = 0; i <= 8; i++)
            {
                k = abc[i];
                j = Random.Range(0, 9);
                abc[i] = abc[j];
                abc[j] = k;
            }
        }

        for (i = 0; i <= 8; i++)
        {
            if (abc[i] == 0) continue;

            for (k = 1; k <= abc[i]; k++)
            {
                if (tour) xyz_.z += 7;
                else xyz_.x += 7;
                Diamonds_ = Random.Range(1, Period+1);
                platform__ = Instantiate(platf[Diamonds_ - 1], xyz_, Quaternion.identity);
                platform__.name = "Cube " + count.ToString();
                count++;
            }
            tour = !tour;

        }






    }

    void OnTriggerExit()
    {
        if (int.Parse(this.transform.parent.name.Trim(CubeNumber)) >= 10) GameObject.Find("Sphere").GetComponent<Move>().difficulty = 2;
        if (int.Parse(this.transform.parent.name.Trim(CubeNumber)) >= 30) GameObject.Find("Sphere").GetComponent<Move>().difficulty = 3;

        this.GetComponentInParent<Destroy>().Destroy_Cube();
    }
}
