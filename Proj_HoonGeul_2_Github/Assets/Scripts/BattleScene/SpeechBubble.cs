using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class SpeechBubble : MonoBehaviour
{
    int randInt;
    public float bubbleWaitTime;
    string[] noDict= {"그게 뭔가?","잘못 친거같은데…","그런말이 있나?","그게 말이 된다고 생각하나?"}; //사전에 없는 단어. 3
        string[] noDictAmericaBoss = { "자판을 다시 한번 보시게", "다시 잘 살펴보게", "당황하지 말게", "자네 영어 안배웠나?", "알파벳 모르나..?" };
    //현재 스테이지가 미국 보스인 경우, 사전에 없을 때 noDict 대신 noDictAmericaBoss 를 사용.4
    string[] alreadyUsed = { "중복이네", "이미 사용한 단어야", "한번 사용한 단어는 다시 쓸 수 없네", "또?", "자네 기억력이... 흠..." }; //이미 사용한 단어. 4
    string[] yesDictWrong = { "아직 때가아니네", "맞는 말이긴 하네만…", "다시 확인해보시게" }; // 사전에는 있으나, 현재 과제와 맞지 않음.2


    string[] japanPatternWrong = { "받침이 없어야 된다네", "받침이 없는 단어로 다시 해보게", "일본어에는 받침이 없다네" }; //일본 보스 패턴에 맞지 않음. 2
    string[] chinaPatternWorng = { "한자어를 써야하네", "저자는 중국인일세", "한자어만 사용해야 한다네", "한자로 된 단어만 알아듣는건가...?" }; //3

    ///우의정 조선 스테이지1. 3
    string[] joseonRightMinister = { "그 모음은 쓰면 안되네", "그게 들어가면 안되네", "저 모음(자음)들은 사용해선 안돼.", "쓰면 안되는 모음이 있는 것 같은데?" };
    
    //좌의정 조선 스테이지2. 2
    string[] joseonLeftMinister = { "꼭 필요한 모음이 빠진 것 같은데..", "저자가 말하는 모음이 포함되야해", "저 모음이 사용되지 않은 것 같은데..?" };

    //영의정 조선 스테이지3 인 경우, 사전에 없을 때 nodict 대신 joseonYoungMinister를 사용. 2 
    string[] joseonYoungMinister = { "마음의 눈으로 보시오", "눈에 보이는게 다가 아니네", "당황하지 마시게" };

    public Text bubbleText;
    public Image bubbleImage;
    public RectTransform rectTransform;
    public float textWidthScale = 0.1f;

    //코루틴 시간 확인을 위한 변수 (말풍선 순삭버그)
    bool isCoRunning = false;

    private void Start()
    {
        bubbleImage.enabled = false;
        bubbleText.text = "";
    }
    public void makeBubbleText(int count)
    {
        if (!isCoRunning)
        {
            switch (count)
            {

                case -1: //사전에 없는 단어
                    randInt = Random.Range(0, noDict.Length);
                    bubbleText.text = noDict[randInt];

                    break;

                case -2: //이미 사용한 단어
                    randInt = Random.Range(0, alreadyUsed.Length);
                    bubbleText.text = alreadyUsed[randInt];
                    break;

                case -9: //사전에 있지만 현재 과제와 맞지 않음 
                    randInt = Random.Range(0, yesDictWrong.Length);
                    bubbleText.text = yesDictWrong[randInt];
                    break;

                case -4: //사전에 있지만 받침이 있음 (일본 보스 chapter 2 boss)
                    randInt = Random.Range(0, japanPatternWrong.Length);
                    bubbleText.text = japanPatternWrong[randInt];
                    break;

                case -5: //한자어가 아님 (중국 보스)
                    randInt = Random.Range(0, chinaPatternWorng.Length);
                    bubbleText.text = chinaPatternWorng[randInt];
                    break;

                case -6: // case -1 처럼 사전에 없고, 현재 스테이지가 미국 보스일 때
                    randInt = Random.Range(0, noDictAmericaBoss.Length);
                    bubbleText.text = noDictAmericaBoss[randInt];
                    break;

                case -7: //(chapter 5-1 boss ) : 제한된 모음이 사용된 오답. //못쓰게 하는거
                    randInt = Random.Range(0, joseonRightMinister.Length);
                    bubbleText.text = joseonRightMinister[randInt];
                    break;

                case -8: //(chapter 5-2 boss) : 강요된 모음이 사용되지 않은 오답. //쓰게하는거
                    randInt = Random.Range(0, joseonLeftMinister.Length);
                    bubbleText.text = joseonLeftMinister[randInt];
                    break;

                case -10: //(chpater 5-3 boss) : no dict 대신 사용
                    randInt = Random.Range(0, joseonYoungMinister.Length);
                    bubbleText.text = joseonYoungMinister[randInt];
                    break;
            }

            rectTransform.sizeDelta += new Vector2(bubbleText.preferredWidth * textWidthScale, 0);
            rectTransform.anchoredPosition = new Vector3(-453.7f + (bubbleText.preferredWidth * textWidthScale * 0.35f), 783.2f, 0);
            bubbleImage.enabled = true;
            StartCoroutine("maintainBubble");
        }
    }
    IEnumerator maintainBubble()
    {
        isCoRunning = true;
        yield return new WaitForSeconds(bubbleWaitTime);
        bubbleImage.enabled = false;
        bubbleText.text = "";
        rectTransform.anchoredPosition = new Vector3(-453.7f, 783.2f, 0);
        rectTransform.sizeDelta = new Vector2 (249.7f, 228.6f);
        isCoRunning = false;
    }
    //public void MaintainBubble_enter()
    //{  
    //        bubbleImage.enabled = false;
    //        bubbleText.text = "";
    //        rectTransform.anchoredPosition = new Vector3(-453.7f, 783.2f, 0);
    //        rectTransform.sizeDelta = new Vector2(249.7f, 228.6f);            
    //}

}
