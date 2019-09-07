using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class settingButtonHandler : MonoBehaviour
{
    public GameObject panel;
    public Text buttonText;
    public Animator panelAnimator;

    // Start is called before the first frame update
    
    public void OnClick()
    {
        if (panel.activeSelf)
        {
            panelAnimator.SetTrigger("panelOff");
            buttonText.text = "설";
        }
        else
        {
            panelAnimator.SetTrigger("panelOff");
            buttonText.text = "X";
        }
    }
}
