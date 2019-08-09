﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CharacterQuiz : MonoBehaviour
{
    GameManager m_gameManager;

    public Text question;
    public Text num1;
    public Text num2;
    public Text num3;

    public SceneData sceneData;

    int selectAns;
    int correctAns;
    string[,] answerStr = new string[9, 4] {{ "장영실", "전자시계", "물시계", "해시계" },
                                            { "이순신", "영의정", "학익진", "백의종군" },
                                            { "궁예", "고려", "관심법", "미륵" },
                                            { "문익점", "무역상", "붓", "목화씨" },
                                            { "원효", "고려", "해골물", "의상대사" },
                                            { "장희빈", "서인", "숙종", "희빈 장씨" },
                                            { "최무선", "고구려", "화통도감", "화약" },
                                            { "세종", "이산", "편경", "집현전"},
                                            { "논개", "한산대첩", "가락지", "임진왜란" } };
    string[] nowAnsStr = new string[4];

    private void Start()
    {
        m_gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        sceneData = m_gameManager.GetSceneData();
        AnsGenerator();
    }
    public void AnsGenerator()
    {
        selectAns = Random.Range(0, 9);     //문제 번호 랜덤
        correctAns = Random.Range(1, 4);    //정답 문항 랜덤
        for(int i = 0; i<4; i++)
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
