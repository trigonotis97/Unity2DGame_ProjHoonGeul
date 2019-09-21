using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadStoryModeInd : MonoBehaviour
{
    GameManager m_gameManager;

    private void Awake()
    {
        m_gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();

    }
    public void LoadStoryModeIndData()
    {
        int b = m_gameManager.LoadBattleStageIndex();
        int d = m_gameManager.LoadDialogStageIndex();
        int s = m_gameManager.LoadSceneIndex();
        Debug.Log(b + ":" + d + ":" + s);
        m_gameManager.SetCurrentBattlekey(b);
        m_gameManager.SetCurrentDialogKey(d);
        m_gameManager.SetCurrentSceneKey(s);
    }
}
