using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class settingButtonHandler : MonoBehaviour
{
    public GameObject panel;
    public Text buttonText;
    // Start is called before the first frame update
    
    public void onClick()
    {
        if (panel.activeSelf)
        {
            panel.SetActive(false);
            buttonText.text = "설";
        }
        else
        {
            panel.SetActive(true);
            buttonText.text = "X";
        }
    }
}
