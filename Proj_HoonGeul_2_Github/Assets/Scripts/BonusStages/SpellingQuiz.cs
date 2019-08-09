using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SpellingQuiz : MonoBehaviour
{
    GameManager m_gameManager;

    public Text question;
    public Text num1;
    public Text num2;
    public Text num3;

    public SceneData sceneData;

    int selectAns;
    int correctAns;
    string[,] answerStr = new string[8, 4] {{ "이게 뭐하는 ___야","짓거리","짓꺼리", "짓걸이"},
                                            { "동훈이는 정말 __이구나","숙맥", "쑥맥", "쑥멕" },
                                            { "범준이는 ____ 장가가기 힘들겠구나","웬만해선", "왠만해선","왼만해선" },
                                            { "이 문은 ___로 만들었어", "널빤지", "널판지", "널반지" },
                                            { "앞치마를 ___", "두르다", "둘르다", "둘으다" },
                                            { "서영이는 정말 ____", "가냘프다", "가날프다", "갸냘프다" },
                                            { "우신이는 천화에게 _____", "치근덕댄다", "추근적댄다", "추근덕댄다" },
                                            { "유어 웰컴 = ____ ", "천만에요", "천만해요", "천만애요"} };
    string[] nowAnsStr = new string[4];
    private void Start()
    {
        m_gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        AnsGenerator();
        sceneData = m_gameManager.GetSceneData();
    }

    public void AnsGenerator()
    {
        selectAns = Random.Range(0, 8);     //문제 번호 랜덤
        correctAns = Random.Range(1, 4);    //정답 문항 랜덤
        for (int i = 0; i < 4; i++)
        {
            nowAnsStr[i] = answerStr[selectAns, i]; //중간 매개 배열
        }
        // 정답 문항으로 각 문제[1] 을 이동시키기 위한 코드.
        string temp = nowAnsStr[correctAns];
        nowAnsStr[correctAns] = nowAnsStr[1];
        nowAnsStr[1] = temp;
        Debug.Log(nowAnsStr[correctAns]);
        Debug.Log(correctAns);


        //텍스트로 문자열 출력
        question.GetComponent<Text>().text = nowAnsStr[0];
        num1.GetComponent<Text>().text = nowAnsStr[1];
        num2.GetComponent<Text>().text = nowAnsStr[2];
        num3.GetComponent<Text>().text = nowAnsStr[3];
    }

    public void AnsClick(int BtNum)
    {
        if (BtNum == correctAns)
        {
            Debug.Log("정답");
            m_gameManager.SetCurrentSceneKey(m_gameManager.GetCurrentSceneKey() + 1);
            switch (sceneData.nextScene)
            {
                case 0:
                    SceneManager.LoadScene("StartScene", LoadSceneMode.Single);
                    break;
                case 1:
                    m_gameManager.SetCurrentDialogKey(sceneData.nextSceneKey);
                    SceneManager.LoadScene("DialogScene", LoadSceneMode.Single);
                    break;
                case 2:
                    m_gameManager.SetCurrentBattlekey(sceneData.nextSceneKey);
                    SceneManager.LoadScene("BattleScene", LoadSceneMode.Single);
                    break;
                case 3:
                    SceneManager.LoadScene("BonusStageCharacter", LoadSceneMode.Single);
                    break;
                case 4:
                    SceneManager.LoadScene("BonusStageSpelling", LoadSceneMode.Single);
                    break;
                case 5:
                    SceneManager.LoadScene("BonusStageSukBong", LoadSceneMode.Single);
                    break;
            }
        }
        else
        {
            Debug.Log("오답");
            //깜지 씬으로 이동
        }
    }
}
