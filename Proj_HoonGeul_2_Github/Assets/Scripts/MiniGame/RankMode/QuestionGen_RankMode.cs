using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestionGen_RankMode : MonoBehaviour
{
    public RankModeManager m_rankModeManager;
    public string[] questTbl;
    string[] hellquestTbl;

    //ui 표시 관련 변수
    public Text[] Chosung_text_arr = new Text[3]; //문제판의 텍스트를 처리
    string[] questionVal_arr = new string[3]; // 

    string m_cho_Tbl = "ㄱㄲㄴㄷㄸㄹㅁㅂㅃㅅㅆㅇㅈㅉㅊㅋㅌㅍㅎ";
    string m_jung_Tbl = "ㅏㅐㅑㅒㅓㅔㅕㅖㅗㅘㅙㅚㅛㅜㅝㅞㅟㅠㅡㅢㅣ"; //10+ 21


    public InputField InputText;
    public Judgement_RankMode ansJudge;

    public Color HellColor = new Color(1f, 0f, 0f);


    //정답 판정을 위한 멤버변수
    public int correctState;

    //오답 말풍선 (함수사용)
    SpeechBubble speechBubble;


    //백그라운드 정답 문자 표시 변수
    public BackGroundWordGen backgroundWordGen;


    //애니메이션 변수
    public Animator[] tile = new Animator[3];
    public Animation signAni;

    //정답시 힐을 위한 변수
    public TimeBar_RankMode timeBar;


    ///임시 변수 (자음모음 문제가 확정되면 사용
    bool isMoeumStage; 




    private void Awake()
    {
        speechBubble = GetComponent<SpeechBubble>();

    }
    // Start is called before the first frame update
    void Start()
    {
        //처음 문제 생성
        for (int i = 0; i < 3; i++)
        {
            MakeNewQuestion(i, false);
           
        }
    }

    public void textInputEnter()
    {
        string inputWord = InputText.text; //tmp에 엔터 버튼을 눌렀을 때의 문자열 저장.

        //모음인지 아닌지, 입력단어 ,현재 문제 초성(자음) value array, 어원을 사용하는지 : 0-미사용 1-고유어 2- 한자어 3-혼종어 4-외래어)
        correctState = ansJudge.IsCorrectAnswer(false, inputWord, getQuestValue(), 0/*wordType*/, false/*isChapter2Boss*/);


        ///정답일 경우
        if (correctState > -1)//correctState 가 맞은 문제의 인덱스를 나타낸다.
        {
            tile[correctState].SetTrigger("correct"); //애니메이션이 끝날때 make new question 실행.
            signAni.Play("O");
            timeBar.IncreaseTimeBar();


            //백그라운드에 정답 문자 표시
            backgroundWordGen.MakeWordRandomPos(inputWord);

        }
        ///오답일경우
        else
        {
            ///오답 말풍선 띄우기
            speechBubble.makeBubbleText(correctState);
            signAni.Play("X");
        }

        InputText.text = ""; //입력창 초기화

    }



    public void MakeNewQuestion(int index, bool isChapter1Boss)
    {
        ///사용 변수 초기화
        string questStr;
        bool isSameWord = false;
        //Chosung_text_arr[index].color = Color.black;

       
            //초성 풀에 있는 단어중 지금 사용하지 않고있는 단어 고르기
            do
            {
                questStr = getRandomChoseongText();
                isSameWord = false;
                for (int t = 0; t < 3; t++)
                {
                    if (Chosung_text_arr[t].text == questStr)
                    {
                        isSameWord = true;
                        break;
                    }
                }
            } while (isSameWord);



            ///현재 만든 초성의 val값 뽑아내서 문제벨류배열에 넣음
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

            string cho_value = choVal[0].ToString() + choVal[1].ToString();
            questionVal_arr[index] = cho_value;



        /// ui 텍스트 수정
        Chosung_text_arr[index].text = questStr;

    }

    public string getRandomChoseongText()
    {
        string outString;
        
        outString = questTbl[Random.Range(0, questTbl.Length)];

        return outString;
    }

    public string[] getQuestValue()
    {
        return questionVal_arr;
    }

    public void SetProblempocket(string[] normalTbl, string[] hellTbl)
    {
        questTbl = normalTbl;
        hellquestTbl = hellTbl;
    }


}
