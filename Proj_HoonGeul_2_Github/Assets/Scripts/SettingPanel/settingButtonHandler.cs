using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class settingButtonHandler : MonoBehaviour
{
    //public GameObject panel;
    public Text buttonText;
    public Animator panelAnimator;
    public bool panelState;


    
    
    public void OnClick()
    {
        if (panelState) // off
        {
            panelState = false;
            panelAnimator.SetTrigger("panelOff");
            buttonText.text = "설";
        }
        else //on
        {
            panelState = true;
            panelAnimator.SetTrigger("panelOn");
            buttonText.text = "X";
        }
    }
}
