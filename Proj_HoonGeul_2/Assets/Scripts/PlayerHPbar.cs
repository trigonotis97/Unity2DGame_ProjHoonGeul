using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerHPbar : MonoBehaviour
{
    public GameObject player;
    Slider m_slider;
    // Start is called before the first frame update
    void Start()
    {
        m_slider = gameObject.GetComponent<Slider>();

    }
    void setHPDown(int input)
    {
        //m_slider.value-=input*
    }

    
}
