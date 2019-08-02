using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using System;
using UnityEngine.UI;

public class XMLLoad : MonoBehaviour
{
    GameManager m_gameManager;
    public Dictionary<string, string> []dictTbl = new Dictionary<string, string>[4];

    BattleSceneData []battleDataTbl;
    DialogData[] dialogDataTbl;

    public int dialogDataLength; //** 퍼블릭으로 xml data 변수 설정
    public int battleDataLength; //**
    private void Awake()
    {
        m_gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }
    void Start()
    {
        battleDataTbl = new BattleSceneData[battleDataLength];
        dialogDataTbl = new DialogData[dialogDataLength];
        LoadXml();
    }

    void LoadXml()
    {
        System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();

        sw.Start();


        TextAsset[] textAsset = new TextAsset[] {
            (TextAsset)Resources.Load("2umjul_Goyu"),
            (TextAsset)Resources.Load("2umjul_Hanja"),
            (TextAsset)Resources.Load("2umjul_Waerae"),
            (TextAsset)Resources.Load("2umjul_Honjong"),
            //(TextAsset)Resources.Load("BattleSceneXml"),
            (TextAsset)Resources.Load("BattleSceneXml_0607"),
            (TextAsset)Resources.Load("DialogSceneXml")
        };

        XmlDocument xmlDoc = new XmlDocument();

        for (int i = 0; i < 4; i++) // 단어 데이터들 딕셔너리에 저장
        {
            dictTbl[i] = new Dictionary<string, string>();
            xmlDoc.LoadXml(textAsset[i].text);

            XmlNodeList nodes = xmlDoc.SelectNodes("WordDic/WordSet"); // 가져올 노드 설정

            foreach (XmlNode node in nodes)
            {
                dictTbl[i].Add(node.SelectSingleNode("Key").InnerText, node.SelectSingleNode("Value").InnerText);
            }
        }
        
        for (int i = 4; i < 5; i++) // 배틀씬데이터 저장
        {
            xmlDoc.LoadXml(textAsset[i].text);
            XmlNodeList nodes = xmlDoc.SelectNodes("BattleScene/BattleSceneSet");
            int indCount = 0;
            foreach (XmlNode node in nodes)
            {
                BattleSceneData BSD = new BattleSceneData();
                BSD.key = int.Parse(node.SelectSingleNode("key").InnerText);
                BSD.chapterNum = int.Parse(node.SelectSingleNode("chapterNum").InnerText);
                BSD.stageNum = int.Parse(node.SelectSingleNode("stageNum").InnerText);
                string tmp_prob = node.SelectSingleNode("problemPocket").InnerText;
                BSD.problemPocket = tmp_prob.Split(new char[] { ',' });
                string tmp_hellprob = node.SelectSingleNode("hellProblemPocket").InnerText; 
                BSD.hellProblemPocket = tmp_hellprob.Split(new char[] { ',' });
                BSD.enemyPrefab = int.Parse(node.SelectSingleNode("enemyPrefab").InnerText);
                BSD.enemyHp = float.Parse(node.SelectSingleNode("enemyHP").InnerText);
                BSD.enemyDamage = float.Parse(node.SelectSingleNode("enemyDamage").InnerText);                
                BSD.isBoss = bool.Parse(node.SelectSingleNode("isBoss").InnerText);
                BSD.bossPattern = int.Parse(node.SelectSingleNode("bossPattern").InnerText);
                BSD.nextDialogNum = int.Parse(node.SelectSingleNode("nextDialogNum").InnerText);
                BSD.BGImage = node.SelectSingleNode("BGImage").InnerText;
                BSD.BGM = node.SelectSingleNode("BGM").InnerText; //암것도 안 들어있어서 주석 처리. 나중에 넣어주세요!
                battleDataTbl[indCount++] = BSD;
            }
        }

        for (int i = 5; i<6; i++) //다이얼로그 데이터 저장
        {
            xmlDoc.LoadXml(textAsset[i].text);
            XmlNodeList nodes = xmlDoc.SelectNodes("DialogScene/DialogSet");
            int indCount = 0;
            foreach (XmlNode node in nodes)
            {
                DialogData DLD = new DialogData();
                DLD.key = int.Parse(node.SelectSingleNode("key").InnerText);
                DLD.chapterNum = int.Parse(node.SelectSingleNode("chapterNum").InnerText);
                DLD.stageNum = int.Parse(node.SelectSingleNode("stageNum").InnerText);
                string tmp_script = node.SelectSingleNode("script").InnerText;
                DLD.script = tmp_script.Split(new char[] { ',' });
                string tmp_conv_state = node.SelectSingleNode("conv_state").InnerText;
                string[] tmp_conv_state_arr = tmp_conv_state.Split(new char[] { ',' });
                DLD.conv_state = Array.ConvertAll<string, int>(tmp_conv_state_arr, int.Parse);
                DLD.isNextBattle = bool.Parse(node.SelectSingleNode("isNextBattle").InnerText);
                DLD.isNextBonus = bool.Parse(node.SelectSingleNode("isNextBonus").InnerText);
                DLD.BGImage = node.SelectSingleNode("BGImage").InnerText;
                DLD.enemyImage = node.SelectSingleNode("enemyImage").InnerText;
                DLD.enemyWholeImage = node.SelectSingleNode("enemyWholeImage").InnerText;
                DLD.BGM = node.SelectSingleNode("BGM").InnerText; //암것도 안 들어있어서 주석 처리. 나중에 넣어주세요!
                dialogDataTbl[indCount++] = DLD;
            }
        }
              
        


        sw.Stop();//시간측정을 위한 함수
        Debug.Log(sw.ElapsedMilliseconds.ToString() + "ms");
        m_gameManager.SetXmlDictData(dictTbl);
        m_gameManager.SetXmlBattleSceneData(battleDataTbl);
        m_gameManager.SetXmlDialogData(dialogDataTbl);

    }
}
