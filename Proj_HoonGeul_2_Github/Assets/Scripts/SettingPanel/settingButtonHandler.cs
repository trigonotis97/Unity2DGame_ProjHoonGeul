using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class settingButtonHandler : MonoBehaviour
{
    //public GameObject panel;
    //public Text buttonText;
    public Sprite openIcon, closeIcon;
    public Image iconImage;
    public Animator panelAnimator;
    public static bool panelState;
    public BattleManager BattleManager;
    public RankModeManager RankModeManager;
    public GgamJiGameManager ggamJiGameManager;

    private void Start()
    {
        iconImage.sprite = openIcon;
    }
    public void OnClick()
    {
        if (panelState) // off
        {
            panelState = false;
            panelAnimator.SetTrigger("panelOff");
            iconImage.sprite = openIcon;
            if (BattleManager != null)
            {
                BattleManager.SetStatePlaying();
            }
            else if (RankModeManager != null)
            {
                RankModeManager.SetStatePlaying();
            }
            else if (ggamJiGameManager != null)
            {
                ggamJiGameManager.SetState("PLAYING");
            }
        }
        else //on
        {
            panelState = true;
            panelAnimator.SetTrigger("panelOn");
            iconImage.sprite = closeIcon;
            if (BattleManager != null)
            {
                BattleManager.SetStatePause();
            }
            else if (RankModeManager != null)
            {
                RankModeManager.SetStatePause();
            }
            else if (ggamJiGameManager != null)
            {
                ggamJiGameManager.SetState("PAUSE");
            }
        }
    }
}
