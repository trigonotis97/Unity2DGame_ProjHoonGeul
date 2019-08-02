using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Test_Input : MonoBehaviour
{
    //public Animator board1, board2, board3;
    public InputField InputText;
    public string InputedText;
    public int EnterClicked = 0;
    //ttackText chosungObj
    PlayerScript m_playerScript;
    GameObject choObj;
    AttackText choObj_inputText_srt;
    ChosungGenerator choObj_genrator_srt;

    //
    public Judgement ansJudge;

    private void Start()
    {
        m_playerScript = GameObject.Find("Player").GetComponent<PlayerScript>();
        choObj = GameObject.Find("ChosungObject");

        choObj_genrator_srt = choObj.GetComponent<ChosungGenerator>();
        choObj_inputText_srt = choObj.GetComponent<AttackText>();
    }

    public void text(Text Test_Text) //디버그용 텍스트. 인게임에서 영향은 없다.
    {
        Test_Text.text = InputText.text;
    }

    public void textInputEnter() // 엔터 버튼을 눌렀을 때
    {
        string inputWord = InputText.text; //tmp에 엔터 버튼을 눌렀을 때의 문자열 저장.
        //int CorrectIdx = ansJudge.IsCorrectAnswer(false,inputWord, choObj_genrator_srt.getQuestValue(),0);
        /*
        if(CorrectIdx>-1)
        {
            choObj_genrator_srt.MakeNewQuestion(CorrectIdx);
            choObj_inputText_srt.ShowInputText(); //@@@@구조 변경 필요@@@@
            m_playerScript.Attack(inputWord);
        }
        */

        /*
        SkillClassStore skillClass = new SkillClassStore(); // SkillClassStore불러오기
        for (int i = 0; i < 3; i++)
        {
            if (skillClass.skiils[ChosungGenerator.Chosung1Num, i] == tmp) //Chosung1Num == 각 초성들의 단어의 집합인 행. for문을 통해서 반복하면서 행 전체를 검사한다.
            {
                //올리고
                //board1.SetTrigger("board1");
                choObj_inputText_srt.ShowInputText(); // AttackText.cs (ChosungObject안에 있어요)의 ShowInputText 함수 호출.
                m_playerScript.Attack(skillClass.skiils[ChosungGenerator.Chosung1Num, i]); // 공격 호출
                                                                                           //내리고

                choObj_genrator_srt.MakeNewQuestion(i); // 무작위 초성 생성.  
                break;
            }
            if (skillClass.skiils[ChosungGenerator.Chosung2Num, i] == tmp)
            {
                //board2.SetTrigger("board2");
                choObj_inputText_srt.ShowInputText(); // AttackText.cs (ChosungObject안에 있어요)의 ShowInputText 함수 호출.
                m_playerScript.Attack(skillClass.skiils[ChosungGenerator.Chosung2Num, i]); // 공격 호출

                choObj_genrator_srt.MakeNewQuestion(i); // 무작위 초성 생성.  
                break;
            }
            if (skillClass.skiils[ChosungGenerator.Chosung3Num, i] == tmp)
            {
                //board3.SetTrigger("board3");
                choObj_inputText_srt.ShowInputText(); // AttackText.cs (ChosungObject안에 있어요)의 ShowInputText 함수 호출.
                m_playerScript.Attack(skillClass.skiils[ChosungGenerator.Chosung3Num, i]); // 공격 호출

                choObj_genrator_srt.MakeNewQuestion(i); // 무작위 초성 생성.  
                
                break;
            }
        }
        */
        InputText.text = ""; //입력창 초기화
    }
}
