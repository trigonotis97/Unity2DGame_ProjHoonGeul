using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PuzzleMainManager : MonoBehaviour
{
    GameManager m_gameManager;
    public Text bestScoreText;

    // Start is called before the first frame update
    private void Awake()
    {
        m_gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }
    void Start()
    {
        bestScoreText.text = m_gameManager.GetBestPuzzleScore().ToString() + "/100";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
