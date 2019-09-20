using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text m_text;
    public int score=0;
    public void AddScore()
    {
        score++;
        m_text.text = score.ToString();
    }
    public int GetScore()
    {
        return score;       
    }
}
