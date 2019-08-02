using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//like every moment in the end

public class Judgement : MonoBehaviour
{
    GameManager m_gameManager;
    BattleManager m_battleManager;


    //사전 데이터 받아올 테이블
    Dictionary<string, string>[] m_dictTbl = new Dictionary<string, string>[4];

    //이미 사용한 단어 테이블
    Dictionary<string, string> usedWordDict;



    
    private int wordCount; //사용하는 단어의 글자 수
    private int[] wordType_arr = new int[4]; // 단어 어원 선택
                                             //(1 : 고유어 2: 한자어 3: 외래어  4 : 혼종어

    

    //보스 스테이지 관련 변수
    int bossStageIdx;
    
    private void Awake()
    {
        m_gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        m_battleManager = GameObject.FindGameObjectWithTag("BattleManager").GetComponent<BattleManager>();

    }


    void Start()
    {
        //Debug.Log("aj : im here!");
        wordCount = 2; //글자수
        StartCoroutine("GetDictXml");
        //m_dictTbl = m_gameManager.GetXmlDictData();
        usedWordDict = new Dictionary<string, string>(); //매 스테이지 시작시 초기화

        /*
            게임 시작시 스테이지 조건 변수들 가져오기
        */

        //지금은 임의로 입력

        //보스스테이지 관련 인덱스 가져오기 (0:default)
        bossStageIdx = m_battleManager.Is2to5BossStage();
        

    }
    // 0 1 2345 6789 10 


    //정답 판정 알고리즘            //모음인지 아닌지, 입력단어 ,현재 문제 초성(자음) value array, 어원을 사용하는지 : 0-미사용 1-고유어 2- 한자어 3-혼종어 4-외래어)
    public int IsCorrectAnswer(bool isMoeum, string inputWord, string[] questionVal_arr, int usingType,bool isChapter2Boss)
    {
        string wordValue = "";
        /*

        */
        bool isExist = false;
        string inputValue = ""; //11자리 숫자
        ///1. 사전에 있는지 검색
        for (int i = 0; i < 4; i++)
        {
            if (m_dictTbl[i].ContainsKey(inputWord))
            {
                isExist = true;
                inputValue = m_dictTbl[i][inputWord];//입력단어의 value 값 가져오기
            }
        }

        if (isExist)//사전에 있는 단어일 경우
        {
            ///2. 이미 사용한 단어인지 검색
            if (usedWordDict.ContainsKey(inputWord))
            {
                Debug.Log("오답! 이미 사용한 단어:" + inputWord);
                return -2;
            }
            ///2. 단어수 , 어원 , 초성 매치 여부 순서대로 검색
            {
                ///단어수 검사
                if (!(inputValue[0].ToString() == wordCount.ToString()))
                {
                    Debug.Log("오답! : 사전에 있지만 단어수가 다름" + inputWord);
                    return -6;
                }

                ///어원 검사
                //0-미사용 1-고유어 2- 한자어 3-혼종어 4-외래어
                if (usingType > 0)
                {
                    bool isCorrectType = false;
                    for (int i = 0; i < 4; i++)
                    {

                        if (inputValue[1].ToString() == (usingType-1).ToString())//정해진 타입과 맞는 단어일경우
                        {
                            isCorrectType = true;
                            break;
                        }
                    }
                    //정해진 타입과 맞는 단어가 아니면 오답 , 맞으면 다음 검사로 넘어감
                    if (!isCorrectType)
                    {
                        Debug.Log("오답! : 사전에 있지만 정해진 타입과 다름" + inputWord);
                        return -3;
                    }
                }

                ///초성 매치

                if (isMoeum)//모음 문제일경우
                {
                    wordValue = inputValue.Substring(6, 4);
                }
                else //초성 문제일경우
                {
                    wordValue = inputValue.Substring(2, 4);
                }


                ////////////    보스 패턴 부분   ////////////
                if (bossStageIdx==2) // chapter 2 boss 
                {
                    if(inputValue[10]=='1')
                    {
                        Debug.Log("오답! (chapter 2 boss) : 사전에 있지만 받침이 있음! " + inputWord);
                        return -4;
                    }
                }
                else if(bossStageIdx==4) // chapter 4 boss
                {
                    string moeumChapt4= inputValue.Substring(6, 4);
                    bool isCondCorrect = true;
                    for (int q=0;q<2;q++)
                    {
                        string temp = moeumChapt4.Substring(q * 2, 2);
                        if( !((temp == "10")|| (temp == "15")|| (temp == "18")||
                            (temp == "30")|| (temp == "23")) )
                        {
                            isCondCorrect = false;
                            break;
                        }
                    }

                    if(!isCondCorrect)
                    {
                        Debug.Log("오답! (chapter 4 boss ) : 사전에 있지만 ㅏ ㅔ ㅣ ㅗ ㅜ 를 사용하지 않는 모음이 포함" + inputWord);
                        return -5;
                    }
                }
                else if (bossStageIdx == 5) //chapter 5-1 boss
                {
                    string jaeumChapt5 = inputValue.Substring(2, 4);
                    bool isCondCorrect = true;
                    for (int q = 0; q < 2; q++)
                    {
                        string temp = jaeumChapt5.Substring(q * 2, 2);
                        if (!((temp == "10") || (temp == "12") || (temp == "13") || (temp == "15") ||
                           (temp == "16") || (temp == "17")))
                        {
                            isCondCorrect = false;
                            break;
                        }
                    }

                    if (!isCondCorrect)
                    {
                        Debug.Log("오답! (chapter 5 boss ) : 사전에 있지만 ㄱ ㄴ ㄷ ㄹ ㅁ ㅂ 를 사용하지 않는 자음이 포함" + inputWord);
                        return -7;
                    }
                }
                else if (bossStageIdx == 6)//6==chapter 5-2
                {
                    string moeumChapt5 = inputValue.Substring(6, 4);
                    bool isCondCorrect = true;
                    for (int q = 0; q < 2; q++)
                    {
                        string temp = moeumChapt5.Substring(q * 2, 2);

                        if (((temp == "10") || (temp == "12") || (temp == "14") || (temp == "16") ||
                            (temp == "18") || (temp == "22")))
                        {
                            isCondCorrect = false;
                            break;
                        }
                    }

                    if (!isCondCorrect)
                    {
                        Debug.Log("오답! (chapter 5 boss ) : 사전에 있지만 ㅏ ㅑ ㅓ ㅕ ㅗ ㅛ 이(가) 모음이 포함 " + inputWord);
                        return -8;
                    }
                }


                //일반 정답 처리부분 
                for (int j = 0; j < 3; j++)
                {
                    if (questionVal_arr[j] == wordValue)//문제와 매치한다면 정답처리
                    {
                        Debug.Log("정답 ! :" + inputWord);
                        usedWordDict.Add(inputWord, wordValue);

                        return j;
                    }
                    
                }

                {//사전에 있지만 문제와 다를경우
                    Debug.Log("오답! :사전에 있지만 문제와 맞지 않음" + inputWord);
                    return -9;
                }


            }

        }
        else//사전에 없는 단어일 경우
        {
            Debug.Log("오답! 사전에 없음:" + inputWord);
            return -1;
        }
    }

    //테스트를 위한 함수. xml 데이터 연동과 메인부터 씬 이동이 구현 된다면
    //게임 시작시 xml을 받아올것이므로 이 함수가 필요없다.
    IEnumerator GetDictXml()
    {
        // Debug.Log(" ienum : im start1");
        do
        {
            if (m_gameManager.GetXmlDictData() == null)
            {
                Debug.Log("dict : not yet");
                yield return new WaitForSeconds(0.3f);
                StartCoroutine(GetDictXml());
            }
            else
            {
                m_dictTbl = m_gameManager.GetXmlDictData();
                Debug.Log("get dictionary xml data successfully");
            }
        } while (m_dictTbl == null);
    }
}