using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GgAniStateHandler : MonoBehaviour
{
    public GgamJiGameManager GgamJiGameManager;
    public Text Text;

    public void SetState(string i)
    {
        GgamJiGameManager.SetState(i);
    }
    public void TextInsert(string i)
    {
        Text.text = i;    
    }
}
