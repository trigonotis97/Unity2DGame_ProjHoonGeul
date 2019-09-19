using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeBar : MonoBehaviour
{
    public float timeSpeed;
    public BattleManager m_battleManager;
    Slider timeSlider;
    // Start is called before the first frame update
    void Start()
    {
        timeSlider=GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        if(m_battleManager.GetState()==StageState.PLAYING)
        {
            DecreaseTimeBar();
        }

        


    }

    void DecreaseTimeBar()
    {
        timeSlider.value -= Time.deltaTime * timeSpeed;
        if(timeSlider.value<=0f)
        {
            m_battleManager.SetStateGameover();
        }
    }
    public void IncreaseTimeBar(float healValue)
    {
        timeSlider.value += healValue;
    }
}
