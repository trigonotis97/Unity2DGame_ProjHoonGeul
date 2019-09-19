﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GgamJiModeManager : MonoBehaviour
{
    public MainSceneChange MainSceneChange;
    GameManager m_gameManager;

    public Text title, stageText;
    public GameObject startButton;

    // Start is called before the first frame update
    void Start()
    {
        if (GameObject.FindGameObjectWithTag("GameManager") != null)
        {
            m_gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        }
        title.text = "깜지 경연 대회";
        stageText.text = "원하는 글을 선택하시오.";
    }

    public void SelectJeol(int jeolNum)
    {
        title.text = "애국가 " + jeolNum.ToString() + "절";
        stageText.text = "최고 기록\n" + "임0:0시"; //게임매니저에서 최고기록 받아오기
        m_gameManager.SetGgamJiStageNum(jeolNum);//게임매니저에 몇절인지 변수 넣기
        if (startButton.activeSelf == false) startButton.SetActive(true);
    }
}