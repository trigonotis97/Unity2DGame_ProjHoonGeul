using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Judgement_RankMode : MonoBehaviour
{
    GameManager m_gameManager;

    Dictionary<string, string>[] m_dictTbl = new Dictionary<string, string>[4];
    Dictionary<string, string> usedWordDict;

    private int wordCount; //사용하는 단어의 글자 수
    private int[] wordType_arr = new int[4]; // 단어 어원 선택
                                             //(1 : 고유어 2: 한자어 3: 외래어  4 : 혼종어

    private static string m_cho_Tbl = "ㄱㄲㄴㄷㄸㄹㅁㅂㅃㅅㅆㅇㅈㅉㅊㅋㅌㅍㅎ"; // 10부터 시작
    private static string m_jung_Tbl = "ㅏㅐㅑㅒㅓㅔㅕㅖㅗㅘㅙㅚㅛㅜㅝㅞㅟㅠㅡㅢㅣ"; //10+ 21

    private void Awake()
    {
        m_gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();

    }

    void Start()
    {
        wordCount = 2; //글자수
        StartCoroutine("GetDictXml");
        usedWordDict = new Dictionary<string, string>(); //매 스테이지 시작시 초기화


    }

    public int IsCorrectAnswer(bool isMoeum, string inputWord, string[] questionVal_arr, int usingType, bool isChapter2Boss)
    {
        string wordValue = "";

        bool isExist = false;
        string inputValue = ""; //11자리 숫자
        ///1. 사전에 있는지 검색
        for (int i = 0; i < 4; i++)
        {
            if (m_dictTbl[i].ContainsKey(inputWord))
            {
                isExist = true;
                inputValue = m_dictTbl[i][inputWord];//입력단어의 value 값 가져오기
                Debug.Log("받침 ::" + inputValue[10]);
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
            ///초성 매치
            {
                if (isMoeum)//모음 문제일경우
                {
                    wordValue = inputValue.Substring(6, 4);
                }
                else //초성 문제일경우
                {
                    wordValue = inputValue.Substring(2, 4);
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

    IEnumerator GetDictXml()
    {
        // Debug.Log(" ienum : im start1");
        do
        {
            if (m_gameManager.GetXmlDictData() == null)
            {
                Debug.Log("dict says : not yet");
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
