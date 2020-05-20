using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TimeBar_RankMode : MonoBehaviour
{
    public float timeSpeed;
    //public float healValue;
    public RankModeManager m_rankModeManager;
    Slider timeSlider;

    // Start is called before the first frame update
    private void Awake()
    {
        timeSlider=GetComponent<Slider>();
    }

    void Update()
    {
        if (m_rankModeManager.GetState() == StageState.PLAYING)
        {
            DecreaseTimeBar();
        }
    }

    void DecreaseTimeBar()
    {
        timeSlider.value -= Time.deltaTime * timeSpeed;
        if (timeSlider.value <= 0f)
        {
            m_rankModeManager.SetStateGameover();
        }
    }

    public void IncreaseTimeBar()
    {
        //timeSlider.maxValue
        timeSlider.value =1f;
    }
}
