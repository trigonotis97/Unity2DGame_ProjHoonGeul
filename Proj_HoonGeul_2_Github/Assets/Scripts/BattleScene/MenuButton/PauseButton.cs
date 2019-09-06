using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseButton : MonoBehaviour
{
    public GameObject pausePanel;
    // Start is called before the first frame update
    void Start()
    {
        pausePanel.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void onPauseButtonClick()
    {
        pausePanel.SetActive(true);
    }
    public void onPauseButtonCLoseClick()
    {
        pausePanel.SetActive(false);

    }

}
