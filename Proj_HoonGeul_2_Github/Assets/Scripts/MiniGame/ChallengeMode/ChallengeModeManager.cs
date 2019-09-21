using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChallengeModeManager : MonoBehaviour
{
    
    public float maxTime_tmp;

    public int patternNum_tmp; //0: is test num
    public int gameModeNum_tmp;

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
