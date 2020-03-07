using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    Text text;
    public int score = 0;

    public void PlusDiamonds()
    {
        score += 1;
        text = GetComponent<Text>();
        
        text.text = "Score: " + score.ToString();

    }

}
