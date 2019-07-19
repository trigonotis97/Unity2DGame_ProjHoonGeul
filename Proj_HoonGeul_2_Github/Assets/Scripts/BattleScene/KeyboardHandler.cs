﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;


public class KeyboardHandler : MonoBehaviour
{
    BattleManager m_battleManager;


    GameObject[] keyButtonObj;
    Text[] keyText;

    bool is5_3stage;
    // Start is called before the first frame update
    private void Awake()
    {
        if (SceneManager.GetActiveScene().name!="StartScene")
            m_battleManager = GameObject.FindGameObjectWithTag("BattleManager").GetComponent<BattleManager>();
    }

    void Start()
    {
        if (SceneManager.GetActiveScene().name != "StartScene")
            ChangeKeyboardKortoEng();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ChangeKeyboardKortoEng()
    {
        is5_3stage = (m_battleManager.Is2to5BossStage() == 7);

        //5-2 스테이지 일 경우 키보드 변경
        if (is5_3stage)
        {
            keyButtonObj = GameObject.FindGameObjectsWithTag("ChunjiinKeyText");
            keyText = new Text[keyButtonObj.Length];
            for (int i = 0; i < keyText.Length; i++)
            {
                keyText[i] = keyButtonObj[i].GetComponent<Text>();
                switch (keyText[i].text)
                {
                    case "엔터":
                        break;
                    case "띄움":
                        break;
                    case "ㅈㅊ":
                        keyText[i].text = "J Ch";
                        break;
                    case "ㅅㅎ":
                        keyText[i].text = "S H";
                        break;
                    case "ㅂㅍ":
                        keyText[i].text = "B P";
                        break;
                    case "ㄷㅌ":
                        keyText[i].text = "D T";
                        break;
                    case "ㄴㄹ":
                        keyText[i].text = "N R";
                        break;
                    case "ㄱㅋ":
                        keyText[i].text = "G K";
                        break;
                    case "ㅡ":
                        break;
                    case "ㆍ":
                        break;
                    case "ㅣ":
                        break;
                    case "ㅇㅁ":

                        keyText[i].text = "O M";
                        break;


                }
            }
        }
    }
}
