using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class startAni : MonoBehaviour
{
    public Text text1;
    public Text thisText;
    public Animation Animation;
    // Start is called before the first frame update
    void Start()
    {
        thisText = this.GetComponent<Text>();
        Animation.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (text1.text != "")
        {
            if (thisText.enabled == true)thisText.enabled = false;
        }
        else
        {
            if (thisText.enabled == false) thisText.enabled = true;
        }
    }
   
}
