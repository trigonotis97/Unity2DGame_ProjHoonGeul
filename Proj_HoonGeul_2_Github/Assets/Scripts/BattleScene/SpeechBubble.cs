using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SpeechBubble : MonoBehaviour
{
    public Text bubbleText;
    
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
            case -1: //사전에 없는 단어
                bubbleText.text = "사전에 없네.";
                break;

            case -2: //이미 사용한 단어
                break;

            case -3: //사전에 있지만 정해진 타입과 다름 (보스 스테이지 전용)
                break;

            case -4: //사전에 있지만 받침이 있음 (chapter 2 boss)
                break;

            case -5: //chapter 4 boss: 사전에 있지만 ㅏ ㅔ ㅣ ㅗ ㅜ 를 사용하지 않는 모음이 포함 (chapter 4 boss )
                break;

            case -6: //사전에 있지만 단어수가 다름 (미사용)
                break;

            case -7: //오답! (chapter 5-1 boss ) : 사전에 있지만 ㄱ ㄴ ㄷ ㄹ ㅁ ㅂ 를 사용하지 않는 자음이 포함
                break;

            case -8: //오답!(chapter 5-2 boss ) : 사전에 있지만 ㅏ ㅑ ㅓ ㅕ ㅗ ㅛ 이(가) 모음이 포함
                break;

            case -9: //사전에 있지만 문제와 맞지 않음
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
