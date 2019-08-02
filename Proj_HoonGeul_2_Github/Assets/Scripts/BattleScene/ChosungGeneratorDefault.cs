using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChosungGeneratorDefault : MonoBehaviour
{
    public float waitsecond_;
    BattleManager m_battleManager;
    // 무작위 초성 생성 담당 스크립트

    string[] questTbl ;

    string[] hellquestTbl;

    public Animator[] tile = new Animator[3];
    public Animation signAni;


    public Text[] Chosung_text_arr = new Text[3]; //문제판의 텍스트를 처리
    string[] questionVal_arr = new string[3]; // 
    int[] questionHealOrDeal_arr = new int[3]; // 문제판이 힐, 딜 정보 저장 및 갱신
                                           
    bool[] hellQueue = new bool[3];

    public static int ChosungRandom; // 이 ChosungNum 변수가 Test_Input.cs에서 2차원 배열을 불러올 때 사용됨. 즉 초성에 맞는 단어 사전의 주소가 되는 역할. 
    public static string ChosungStr; // 랜덤 정수 값으로 생성된 ChosungNum을 String으로 변경. 0부터 차례로 ㄱㄱ, ㄱㄴ, ㄱㄷ ... 순으로 우선 배열해 둠. 

    public static int Chosung1Num; //
    public static int Chosung2Num; // #######-> 협의 후 필요없으면 삭제
    public static int Chosung3Num; //

    string m_cho_Tbl = "ㄱㄲㄴㄷㄸㄹㅁㅂㅃㅅㅆㅇㅈㅉㅊㅋㅌㅍㅎ";
    string m_jung_Tbl = "ㅏㅐㅑㅒㅓㅔㅕㅖㅗㅘㅙㅚㅛㅜㅝㅞㅟㅠㅡㅢㅣ"; //10+ 21
    string[] ques_cho_value = new string[3];

    public InputField InputText;


    public Judgement ansJudge; 
    AttackText choObj_inputText_srt;
    public Sunbi m_sunbi;
    public int dealHeal = -1; // 딜, 힐 속성. 1은 힐, 0은 딜
   // public float healProbability = 20.0f; //힐 확률 결정. 

    Color HealColor = new Color(0.0f, 0.7f, 0.3f);
    Color HellColor = new Color(0.0f, 0.7f, 0.3f);


    public bool isChapter1Boss=false;
    public int correctState;
    //초성생성 애니메이션 문제로 전역화

    public bool isChapter2Boss = false;
    public bool isChapter3Boss = false;

 
    //[Space(16)]
    [Header("Show Variable")]
    //헬과제 관련 변수
    public int countCorrect_hell;
    public bool isHellQuestState;
    public int hellCountInd;
    public int hellCountNum; //여기서 개수 조절 퍼블릭으로
    //[Space(16)]


    //확률관련 변수 조정
    [Header("Percentage(int) : 0 ~ 100 (=always True)")]
    public int countCorrect_heal;
    public int healProbability;
    public int percentageAddNum;
    public int count_0;
    public int count_1;
    public int count_2;
    public int count_3;
    public int count_4;
    public int count_5;
    public int count_6;
    public int count_7;


    //보스 스테이지 관련 변수
    int bossStageIdx;
    int wordType;


    //모드 관련 변수
    bool isMoeumStage = false;

    //오답 말풍선 (함수사용)
    SpeechBubble speechBubble;


    private void Awake()
    {
        //퍼블릭으로 할당했습니다. 이름이 같아야 애니메이터를 공유할 수 있어서!
        m_sunbi = GameObject.FindGameObjectWithTag("Sunbi").GetComponent<Sunbi>();
        m_battleManager = GameObject.FindGameObjectWithTag("BattleManager").GetComponent<BattleManager>();
        speechBubble = GetComponent<SpeechBubble>();
       // m_playerScript = GameObject.Find("Player").GetComponent<PlayerScript>();//@@@교체
    }

    void Start()
    {
        //사용 변수 초기화
        isChapter1Boss = false;
        wordType = 0;
        isMoeumStage = false;
        questionVal_arr = new string[3] { "", "", "" };
        choObj_inputText_srt = GetComponent<AttackText>();
        countCorrect_hell = 0;
        isHellQuestState = false;
        hellCountInd = 0;

       
        //처음 문제 생성
        for (int i = 0; i < 3; i++)
            MakeNewQuestion(i, isChapter1Boss);

        isChapter1Boss = m_battleManager.Is1BossStage();//1챕터 보스 확인
        bossStageIdx = m_battleManager.Is2to5BossStage();//2~5챕터 보스인지 확인
        MakeBossStage(bossStageIdx);



    }

    /// 엔터 버튼을 눌렀을 때
    public void textInputEnter() 
    {
        string inputWord = InputText.text; //tmp에 엔터 버튼을 눌렀을 때의 문자열 저장.

        //모음인지 아닌지, 입력단어 ,현재 문제 초성(자음) value array, 어원을 사용하는지 : 0-미사용 1-고유어 2- 한자어 3-혼종어 4-외래어)
        correctState = ansJudge.IsCorrectAnswer(false,inputWord, getQuestValue(), wordType, isChapter2Boss);
        
      

        ///정답일 경우
        if (correctState > -1)//correctState 가 맞은 문제의 인덱스를 나타낸다.
        {
            tile[correctState].SetTrigger("correct"); //애니메이션이 끝날때 make new question 실행.
            signAni.Play("O");


            countCorrect_hell++;
            countCorrect_heal++;


            if (questionHealOrDeal_arr[correctState] == 1) //힐일 경우
            {
                m_sunbi.Attack(inputWord);
                m_sunbi.Heal();
            }
            else if (questionHealOrDeal_arr[correctState] == 0) //딜일 경우
            {
                m_sunbi.Attack(inputWord);
                Debug.Log("딜");
            }
            
            
            if (countCorrect_hell >= hellCountNum) //2개 맞추면 헬로 만들기
            {
                isHellQuestState = true;
                countCorrect_hell = 0;
            }
            //StartCoroutine("MakeTextTransparently",correctState);
            //choObj_inputText_srt.ShowInputText();
            //m_sunbi.Attack(inputWord);
        }
        /////여기 성율이가 추가함. O X 애니메이션 띄우기 위함.
        ///오답일경우
        else
        {
            ///오답 말풍선 띄우기
            speechBubble.makeBubbleText(correctState);
            signAni.Play("X");
        }
        
        InputText.text = ""; //입력창 초기화

    }


    ///문제생성
    public void MakeNewQuestion(int index,bool isChapter1Boss)
    {
        ///사용 변수 초기화
        string questStr;
        bool isSameWord = false;


        ///1챕터 보스일경우
        if (isChapter1Boss)
        {
            // questStr = getRandomChoseongText();
            questStr = Chosung_text_arr[index].text;
        }
        else///1챕터 보스 아닐경우 일반적인 문제 생성
        {
            ///초성 풀에 있는 단어중 지금 사용하지 않고있는 단어 고르기
            do
            {
                questStr = getRandomChoseongText();
                isSameWord = false;
                for (int t = 0; t < 3; t++)
                {
                    if (Chosung_text_arr[t].text == questStr)
                    {
                        /*if (isChapter1Boss == false)
                        {

                        }*/
                        isSameWord = true;
                        break;
                    }
                }
            } while (isSameWord);


            ///헬 판정부분
            //헬 문제일경우 ( 앞에서 만드는게 반복되었기 때문에 밑에서 bool 변수를 바꿔준다)
            if (isHellQuestState)
            {
                isHellQuestState = false;
                Chosung_text_arr[index].color = HellColor;
            }


            ///현재 만든 초성의 val값 뽑아내기
            int[] choVal = new int[2];
            if (isMoeumStage)//모음 스테이지 일 경우
            {
                for (int n = 0; n < 2; n++)
                {
                    for (int i = 0; i < 21; i++)
                    {
                        if (questStr[n] == m_jung_Tbl[i])
                        {
                            choVal[n] = i + 10;
                            break;
                        }

                    }
                }
            }
            else//자음 스테이지 일 경우
            {
                for (int n = 0; n < 2; n++)
                {
                    for (int i = 0; i < 19; i++)
                    {
                        if (questStr[n] == m_cho_Tbl[i])
                        {
                            choVal[n] = i + 10;
                            break;
                        }

                    }
                }
            }

            //Debug.Log(" current str :" + questStr);

            string cho_value = choVal[0].ToString() + choVal[1].ToString();
            questionVal_arr[index] = cho_value;


        }

        ///힐 판정부분
        //RandomRange가 아닌 다른 방법으로 확률 생성하는 방법?
        float Percent = Random.Range(1.0f, 100.0f); // 딜.힐 속성 생성. 0이면 Heal일 예정. 즉, Heal:Deal 비율은 1:4로 우선 해둠.
        
        if (Percent <= healProbability)
        {
            Chosung_text_arr[index].color = HealColor;
            questionHealOrDeal_arr[index] = 1;
            countCorrect_heal=0;
            healProbability = 0;
        }
        else
        {
            switch(countCorrect_heal)
            {
                case 0:
                    healProbability = count_0;
                    break;
                case 1:
                    healProbability = count_1;
                    break;
                case 2:
                    healProbability = count_2;
                    break;
                case 3:
                    healProbability = count_3;
                    break;
                case 4:
                    healProbability = count_4;
                    break;
                case 5 :
                    healProbability = count_5;
                    break;
                case 6:
                    healProbability = count_6;
                    break;
                case 7:
                    healProbability = count_7;
                    break;
                case 8:
                    healProbability = 100;
                    break;
            }
            Chosung_text_arr[index].color = Color.black;
            questionHealOrDeal_arr[index] = 0;
        }



        Chosung_text_arr[index].text = questStr;

    }
        /*
        헬과제는 3개 순서대로.이미 있는건 건너뛰기?
        */
    public string getRandomChoseongText() 
    {
        string outString;
        if (!isHellQuestState)
        {
            
            outString = questTbl[Random.Range(0, questTbl.Length)];
        }
        else//헬 문제 만들경우
        {
            //outString = hellquestTbl[Random.Range(0, 3)];
            outString = hellquestTbl[hellCountInd];
            hellCountInd++;
        }
        return outString;
    }
    public string[] getQuestValue()
    {
        return questionVal_arr;
    }

    public void SetProblempocket(string [] normalTbl,string[]hellTbl)
    {
        questTbl = normalTbl;
        hellquestTbl = hellTbl;
    }
    //IEnumerator MakeTextTransparently(int index)
    //{
    //    Chosung_text_arr[index].color = new Color(Chosung_text_arr[index].color.r, Chosung_text_arr[index].color.g, Chosung_text_arr[index].color.b, 0);
    //    Debug.Log("is waiting");
    //    yield return StartCoroutine("waitTime");
    //    Debug.Log("anddddddddddddd Done!");
        
    //    MakeNewQuestion(index, isChapter1Boss);
        
    //}
    IEnumerator waitTime()
    {
        yield return new WaitForSeconds(waitsecond_);
    }

    ///일반 스테이지에서 보스 스테이지일 경우 변경
    void MakeBossStage(int bossStageInd)
    {
        switch (bossStageIdx)
        {
            case 3://3챕터 보스일경우
                wordType = 2;
                break;
            case 8://5-4 스테이지 일 경우

                //중앙의 하나의 문제만 남김.
                Destroy(Chosung_text_arr[0].gameObject);
                Destroy(Chosung_text_arr[2].gameObject);
                wordType = 4;//0-미사용 1-고유어 2- 한자어 3-혼종어 4-외래어
                //+ 추가 ㅂ버추얼키보드 영어로 바꾸기

                break;
        }
    }
}
