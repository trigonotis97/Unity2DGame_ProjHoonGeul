using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameOverPanel_RankMode : MonoBehaviour
{
    public RankModeManager m_rankModeManager;
    public GameObject gameOverPanel;
    public Score m_score;
    int score;
    public Text m_scoreText;

    private void Start()
    {
        gameOverPanel.SetActive(false);
    }
    public void SetScoreText()
    {
        score = m_score.GetScore();
        m_scoreText.text = score.ToString();
    }
}
