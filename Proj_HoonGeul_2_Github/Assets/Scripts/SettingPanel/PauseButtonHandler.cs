using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseButtonHandler : MonoBehaviour
{
    //public GameObject panel;
    public Text buttonText;
    public Animator panelAnimator;
    public static bool panelState;

    public GgamJiGameManager GgamJiGameManager;


    
    
    public void OnClick()
    {
        if (panelState) // off
        {
            panelState = false;
            panelAnimator.SetTrigger("panelOff");
            buttonText.text = "설";
            GgamJiGameManager.SetState("PLAYING");
        }
        else //on
        {
            panelState = true;
            panelAnimator.SetTrigger("panelOn");
            buttonText.text = "X";
            GgamJiGameManager.SetState("PAUSE");
        }
    }
}
