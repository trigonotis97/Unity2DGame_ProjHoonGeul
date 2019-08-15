﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BonusPenalty : MonoBehaviour
{
    GameManager m_gameManager;

    public Text problem;
    public InputField InputText;

    public SceneData sceneData;

    int selectAns;
    string[,] answerStr = new string[2, 8] {{"동해물과 백두산이 마르고 닳도록",
                                        "하느님이 보우하사 우리나라 만세",
                                        "무궁화 삼천리 화려강산",
                                        "대한 사람 대한으로 길이 보전하세",
                                        "남산 위에 저 소나무 철갑을 두른 듯",
                                        "바람서리 불변함은 우리 기상일세",
                                        "무궁화 삼천리 화려강산",
                                        "대한 사람 대한으로 길이 보전하세"},
                                          {"가을 하늘 공활한데 높고 구름 없이",
                                        "밝은 달은 우리 가슴 일편단심일세",
                                        "무궁화 삼천리 화려강산",
                                        "대한 사람 대한으로 길이 보전하세",
                                        "이 기상과 이 맘으로 충성을 다하여",
                                        "괴로우나 즐거우나 나라 사랑하세",
                                        "무궁화 삼천리 화려강산",
                                        "대한 사람 대한으로 길이 보전하세"}};
    string[] nowAnsStr = new string[8];

    void Start()
    {
        m_gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        sceneData = m_gameManager.GetSceneData();
        AnsGenerator();
    }

    public void AnsGenerator()
    {
        selectAns = Random.Range(0, 2);
        for (int i = 0; i < 8; i++)
        {
            nowAnsStr[i] = answerStr[selectAns, i]; //중간 매개 배열
        }

        //problem.GetComponent<Text>().text = nowAns;
    }

    /*public void textInputEnter()
    {
        string inputWord = InputText.text;
        if (nowAns == inputWord)
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
        InputText.text = "";
    }
    */
}
