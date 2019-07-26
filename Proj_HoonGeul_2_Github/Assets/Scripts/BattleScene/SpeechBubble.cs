using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SpeechBubble : MonoBehaviour
{
    Text bubbleText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void makeBubbleText(int count)
    {
        switch(count)
        {
            case 1:
                break;
        }
        StartCoroutine("maintainBubble");
    }
    IEnumerator maintainBubble()
    {
        yield return new WaitForSeconds(1f);
        bubbleText.text = "";
    }

}
