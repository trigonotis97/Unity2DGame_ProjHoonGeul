using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleAniStateHandler : MonoBehaviour
{
    public BattleManager GgamJiGameManager;
    public Text Text;
    public MainSceneChange m_MainSceneChange;

    private void Start()
    {
        GgamJiGameManager.SetStatePause();
    }
    public void SetState(string i)
    {
        GgamJiGameManager.SetStatePlaying();
    }
    public void TextInsert(string i)
    {
        Text.text = i;
    }
    public void SetSceneNameFromMainSceneChange(string i)
    {
        m_MainSceneChange.SetSceneName(i);
    }
}
