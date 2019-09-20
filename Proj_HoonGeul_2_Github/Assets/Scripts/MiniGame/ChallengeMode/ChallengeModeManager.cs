using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChallengeModeManager : MonoBehaviour
{
    public float enemyHp;
    public int patternNum;
    public int gameModeNum;

    GameManager m_gameManager;



    private void Awake()
    {
        m_gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();

    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
