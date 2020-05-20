using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GgAniStateHandler : MonoBehaviour
{
   
    public GgamJiGameManager GgamJiGameManager;
    public RankModeManager RankModeManager;
    public Text Text;

    public void SetState(string i)
    {
        if (GgamJiGameManager == null)
        {
            RankModeManager.SetState(i);
        }
        else GgamJiGameManager.SetState(i);
    }
    public void TextInsert(string i)
    {
        Text.text = i;    
    }
}
