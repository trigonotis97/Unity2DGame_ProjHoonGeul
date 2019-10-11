using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleAniStateHandler : MonoBehaviour
{
    public BattleManager GgamJiGameManager;
    public Text Text;

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
}
