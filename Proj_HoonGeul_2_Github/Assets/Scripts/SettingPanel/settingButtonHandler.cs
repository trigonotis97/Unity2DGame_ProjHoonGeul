using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class settingButtonHandler : MonoBehaviour
{
    //public GameObject panel;
    public Text buttonText;
    public Animator panelAnimator;
    public static bool panelState;
    public BattleManager BattleManager;
    public RankModeManager RankModeManager; 

    public void OnClick()
    {
        if (panelState) // off
        {
            panelState = false;
            panelAnimator.SetTrigger("panelOff");
            buttonText.text = "설";
            if (BattleManager != null)
            {
                BattleManager.SetStatePlaying();
            }
            else if (RankModeManager != null)
            {
                RankModeManager.SetStatePlaying();
            }
        }
        else //on
        {
            panelState = true;
            panelAnimator.SetTrigger("panelOn");
            buttonText.text = "X";
            if (BattleManager != null)
            {
                BattleManager.SetStatePause();
            }
            else if (RankModeManager != null)
            {
                RankModeManager.SetStatePause();
            }
        }
    }
}
