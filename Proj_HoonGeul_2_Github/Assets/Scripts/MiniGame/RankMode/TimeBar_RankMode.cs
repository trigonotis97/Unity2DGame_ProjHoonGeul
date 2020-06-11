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

    public float currentTime;

    // Start is called before the first frame update
    private void Awake()
    {
        timeSlider=GetComponent<Slider>();
        currentTime = 280f / (m_rankModeManager.score + 28);
        timeSlider.maxValue = currentTime;
        timeSlider.value = currentTime;
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
        currentTime = 280f / (m_rankModeManager.score + 27);
        timeSlider.maxValue = currentTime;
        timeSlider.value = currentTime;
    }
 
}
