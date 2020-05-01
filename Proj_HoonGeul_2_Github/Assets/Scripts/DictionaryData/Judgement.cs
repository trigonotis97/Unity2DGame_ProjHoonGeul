using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

///private static string m_cho_Tbl = "ㄱㄲㄴㄷㄸㄹㅁㅂㅃㅅㅆㅇㅈㅉㅊㅋㅌㅍㅎ"; // 10부터 시작
///private static string m_jung_Tbl = "ㅏㅐㅑㅒㅓㅔㅕㅖㅗㅘㅙㅚㅛㅜㅝㅞㅟㅠㅡㅢㅣ"; //10+ 21
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
    private static string m_cho_Tbl = "ㄱㄲㄴㄷㄸㄹㅁㅂㅃㅅㅆㅇㅈㅉㅊㅋㅌㅍㅎ"; // 10부터 시작
    private static string m_jung_Tbl = "ㅏㅐㅑㅒㅓㅔㅕㅖㅗㅘㅙㅚㅛㅜㅝㅞㅟㅠㅡㅢㅣ"; //10+ 21

    string[,] ch5_1_moeumTable =  { { "10", "15", "22" }, { "18", "19", "27" }, { "30", "28", "21" }, { "23", "11", "12" }, { "14", "16", "26" } };

    string[,]ch5_2_moeumTable =new string[3, 3] { { "16", "19", "27" }, { "11", "15", "21" }, { "28", "22", "12" } };
    //string[] ch5_2_moeunTable = new string[5] { "10", "18", "30", "23", "14" };


    int bossCondCount = 0;
    public Text bossCondText;

    //힌트 단어테이블의 정답단어 삭제를 위한 변수
    public EnemyHintBulletHandler hintHandler;
    
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
        bossCondCount = 0;

        UpdateCondText();//조건 텍스트 보여주기  

    }


    // 0 1 2345 6789 10 


    //정답 판정 알고리즘            //모음인지 아닌지, 입력단어 ,현재 문제 초성(자음) value array, 어원을 사용하는지 : 0-미사용 1-고유어 2- 한자어 3-혼종어 4-외래어)
    public int IsCorrectAnswer(bool isMoeum, string inputWord, string[] questionVal_arr, int usingType,bool isChapter2Boss)
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
                Debug.Log("받침 ::"+inputValue[10]);
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
                /*
                ///단어수 검사
                if (!(inputValue[0].ToString() == wordCount.ToString()))
                {
                    Debug.Log("오답! : 사전에 있지만 단어수가 다름" + inputWord);
                    return -6;
                }
                */

                ///어원 검사
                //0-미사용 1-고유어 2- 한자어 3-혼종어 4-외래어
                if (usingType > 0)
                {
                    bool isCorrectType = false;
                    
                    if (inputValue[1].ToString() == (usingType).ToString())//정해진 타입과 맞는 단어일경우
                    {
                        isCorrectType = true;
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


                /// /////////    보스 패턴 부분   ////////////
                if (bossStageIdx==2) /// chapter 2 boss 
                {
                    if(inputValue[10]=='1')
                    {
                        Debug.Log("오답! (chapter 2 boss) : 사전에 있지만 받침이 있음! " + inputWord);
                        return -4;
                    }
                }
                /*
                else if(bossStageIdx==4) /// chapter 4 boss
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
                        Debug.Log("오답! (chapter 4 boss ) : 사전에 있지만 ㅏ ㅔ ㅣ ㅗ ㅜ 를 사용하지 않는 모음이 포함 " + inputWord);
                        return -5;
                    }
                }
                */
                else if (bossStageIdx == 5) ///chapter 5-1 boss
                {
                    string moeumChapt5_1 = inputValue.Substring(6, 4);
                    bool isCondCorrect = true;
                    for (int q = 0; q < 2; q++)//모음 글자 2개 순서대로 검사
                    {
                        string moeumSingle = moeumChapt5_1.Substring(q * 2, 2);

                        for(int i=0;i<3;i++)//3개의 모음을 제한
                        {
                            if(moeumSingle==ch5_1_moeumTable[bossCondCount,i])
                            {
                                isCondCorrect = false;
                                break;
                            }
                        }
                        if (isCondCorrect)
                            break;
                    }
                    if (!isCondCorrect)
                    {
                        Debug.Log("오답! (chapter 5-1boss ) : 사전에 있지만 제한된 모음을 사용함" + inputWord);
                        return -7;
                    }
                    else//정답일때 조건 바꾸기
                    {
                        bossCondCount++;
                        if (bossCondCount == ch5_1_moeumTable.GetLength(0))//배열인덱스 초과시 초기화
                            bossCondCount = 0;
                        
                            
                    }
                }

                else if (bossStageIdx == 6)///chapter 5-2
                {
                    string moeumChapt5_2 = inputValue.Substring(6, 4);
                    bool isCondCorrect = false;
                    for (int q = 0; q < 2; q++)
                    {
                        string moeumSingle = moeumChapt5_2.Substring(q * 2, 2);
                        for(int i=0;i<3;i++)
                        {
                            if(moeumSingle==ch5_2_moeumTable[bossCondCount,i])
                            {
                                isCondCorrect = true;
                                break;
                            }
                        }
                    }

                    if (!isCondCorrect)
                    {
                        Debug.Log("오답! (chapter 5_2 boss ) : 사전에 있지만 조건에 맞는 모음을 포함하지 않음" + inputWord);
                        return -8;
                    }
                    else //정답을 맞출 경우
                    {
                        bossCondCount++;
                        if (bossCondCount == ch5_2_moeumTable.GetLength(0))//5개의 모음배열중 마지막을 가리킬때
                            bossCondCount = 0;
                        
                            
                    }
                }


                //일반 정답 처리부분 
                for (int j = 0; j < 3; j++)
                {
                    if (questionVal_arr[j] == wordValue)//문제와 매치한다면 정답처리
                    {
                        Debug.Log("정답 ! :" + inputWord);
                        usedWordDict.Add(inputWord, wordValue);

                        UpdateCondText();

                        //힌트 테이블에서 정답 지우기

                        hintHandler.DeleteHintWord(wordValue, inputWord);
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
            if(bossStageIdx==7)
            {
                Debug.Log("오답! 사전에 없음(chapter5-3):" + inputWord);
                return -10;

            }
            else if(bossStageIdx==4)
            {
                Debug.Log("오답! 사전에 없음(chapter4 boss):" + inputWord);
                return -6;
            }
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
    

    void UpdateCondText()
    {
        if (bossStageIdx == 5)
        {
            bossCondText.text = "사용 금지!\n";
            for (int i = 0; i < 3; i++)
            {
                if (i == 0)
                    bossCondText.text += ValuetoWord(ch5_1_moeumTable[bossCondCount, i], 1).ToString();
                else
                    bossCondText.text += ValuetoWord(ch5_1_moeumTable[bossCondCount, i], 1);

            }

            
        }
        else if (bossStageIdx == 6)
        {
            bossCondText.text = "이 중 하나는 꼭 사용!\n";
            for (int i = 0; i < 3; i++)
            {
                if(i==0)
                    bossCondText.text += ValuetoWord(ch5_2_moeumTable[bossCondCount, i], 1).ToString();
                else
                    bossCondText.text += ValuetoWord(ch5_2_moeumTable[bossCondCount, i], 1);

                

            }
        }
    }
    char ValuetoWord(string value,int type)
    {
        if(type==0)//자음
        {
            return m_cho_Tbl[int.Parse(value) - 10];
        }
        else//모음
        {
            return m_jung_Tbl[int.Parse(value) - 10];
        }
    }
}