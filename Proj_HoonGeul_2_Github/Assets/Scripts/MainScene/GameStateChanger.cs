using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateChanger : MonoBehaviour
{
    GameManager m_gameManager;
    private void Awake()
    {
        m_gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();

    }
    public void ChangeGameModeState(int i)
    {
        m_gameManager.SetGameMode(i);
    }
}
