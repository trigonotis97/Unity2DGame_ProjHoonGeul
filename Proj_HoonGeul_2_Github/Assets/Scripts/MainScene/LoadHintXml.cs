using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using System;

public class LoadHintXml : MonoBehaviour
{
    GameManager m_gameManamger;
    Dictionary<string, Dictionary<string, string>> chosungValHintTable = new Dictionary<string, Dictionary<string, string>>();
    Dictionary<string, string[]> chosungWrongHintTable = new Dictionary<string, string[]>();
    //key : chosung value , value : value hint table 

    private static string m_cho_Tbl = "ㄱㄲㄴㄷㄸㄹㅁㅂㅃㅅㅆㅇㅈㅉㅊㅋㅌㅍㅎ"; // 10부터 시작
    private static string m_jung_Tbl = "ㅏㅐㅑㅒㅓㅔㅕㅖㅗㅘㅙㅚㅛㅜㅝㅞㅟㅠㅡㅢㅣ";
    private static string m_alphabet_Tbl = "abcdefghijklmnopqrstuvwxyz";


    string[] word_arr ={"ㅇㅅ",

"ㄱㅅ",
"ㄱㅈ",
"ㅇㄱ",
"ㄱㅇ",
"ㅇㅇ",
"ㅇㅈ",
"ㄱㄱ",
"ㅈㄱ",
"ㅅㅅ",
"ㅈㅅ",
"ㅅㅈ",
"ㅅㄱ",
"ㅈㅇ",
"ㅅㅇ",
"ㅈㅈ",
"ㅂㅅ",
"ㅎㅅ",
"ㄱㅂ",
"ㅇㅂ",
"ㅂㅇ",
"ㅂㅈ",
"ㅁㅅ",
"ㅇㅁ",
"ㅇㄹ",
"ㅂㄱ",
"ㅎㄱ",
"ㄱㄹ",
"ㅎㅇ",
"ㅇㅎ",
"ㅊㄱ",
"ㄱㅎ",
"ㄱㅊ",
"ㄱㅁ",
"ㅊㅅ",
"ㅅㅎ",
"ㅇㄷ",
"ㅅㅂ",
"ㅎㅈ",
"ㅁㅈ",
"ㅈㅂ",
"ㅇㅊ",
"ㅊㅈ",
"ㄷㅅ",
"ㅅㅊ",
"ㅁㅇ",
"ㅅㄹ",
"ㅈㅊ",
"ㅈㄹ",
"ㅈㅁ",
"ㅈㅎ",
"ㄱㄷ",
"ㅁㄱ",
"ㅅㅁ",
"ㅊㅇ",
"ㄷㄱ",
"ㄷㅈ",
"ㅂㅊ",
"ㅂㅎ",
"ㅈㄷ",
"ㅂㅂ",
"ㅎㅂ",
"ㅅㄷ",
"ㄷㅇ",
"ㅂㅁ",
"ㄴㅅ",
"ㅁㅁ",
"ㅍㅅ",
"ㄷㅂ",
"ㅂㄹ",
"ㄴㅇ",
"ㅅㅍ",
"ㄴㅈ",
"ㅎㄷ",
"ㅂㄷ",
"ㅊㅂ",
"ㅌㅅ",
"ㅍㄱ",
"ㅎㅁ",
"ㄱㅍ",
"ㅁㅂ",
"ㅈㅍ",
"ㅌㄱ",
"ㅍㅈ",
"ㅎㅎ",
"ㄷㄹ",
"ㅁㄷ",
"ㅇㅍ",
"ㅅㅌ",
"ㅊㅎ",
"ㅎㄹ",
"ㅁㄹ",
"ㅇㄴ",
"ㄴㄱ",
"ㄴㅂ",
"ㅅㄴ",
"ㅌㅇ",
"ㅍㅇ",
"ㄱㅌ",
"ㄷㅁ",
"ㅁㅎ",
"ㅂㅍ",
"ㅇㅌ",
"ㄱㄴ",
"ㅊㅁ",
"ㅎㅊ",
"ㅁㅊ",
"ㅌㅈ",
"ㅊㄷ",
"ㅊㅊ",
"ㅊㄹ",
"ㅂㅌ",
"ㄷㄷ",
"ㄷㅊ",
"ㄷㅍ",
"ㅎㅍ",
"ㅍㄹ",
"ㄴㅁ",
"ㅈㅌ",
"ㄴㄹ",
"ㄷㅎ",
"ㅈㄴ",
"ㅍㄷ",
"ㅍㅂ",
"ㄴㅊ",
"ㅍㅁ",
"ㅎㅌ",
"ㅂㄴ",
"ㅍㅎ",
"ㄴㅎ",
"ㅁㄴ",
"ㄷㄴ",
"ㅁㅍ",
"ㅊㅌ",
"ㅎㄴ",
"ㅌㅎ",
"ㄴㄷ",
"ㅊㄴ",
"ㅊㅍ",
"ㅌㄹ",
"ㅁㅌ",
"ㅌㅂ",
"ㅍㅊ",
"ㄴㅍ",
"ㅌㅁ",
"ㅌㄷ",
"ㅌㅊ",
"ㄴㅌ",
"ㅌㅍ",
"ㅍㅍ",
"ㄷㅌ",
"ㅍㅌ",
"ㅅㅋ",
"ㅇㅋ"
        };

    //Dictionary<string, string>[] dictTable;

    XmlDocument xmlDoc = new XmlDocument();


    // Start is called before the first frame update
    private void Awake()
    {
        ///만약 테스트 씬에서 테스트를 해야한다면 이 줄을 주석처리 하세요
        m_gameManamger = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }

    void Start()
    {
        Load_tXml();
       
        Load_wrongHintXml();

        if (m_gameManamger != null)
            m_gameManamger.SetAllHintData(chosungValHintTable, chosungWrongHintTable);
    }


    string AlphabettoValue(string alpabetSet)
    {
        string outValue = "";
        string singleAlpha;
        for (int j = 0; j < 2; j++)
        {
            singleAlpha = alpabetSet.Substring(j, 1);
            for (int i = 0; i < m_alphabet_Tbl.Length; i++)
            {
                if (singleAlpha == m_alphabet_Tbl[i].ToString())
                {
                    outValue += i.ToString();
                    break;
                }
            }
        }
        return outValue;
    }


    string ValuetoAlphabet(string value)
    {
        string outAlpha = "";

        for (int i = 0; i < 2; i++)
            outAlpha += m_alphabet_Tbl[int.Parse(value.Substring(i * 2, 2)) - 10].ToString();
        return outAlpha;
    }

    string WordtoValue(string word, int type)
    {
        string outValue = "";
        if (type == 0)//자음
        {

            for (int i = 0; i < 2; i++)
            {
                char singleWord = word[i];
                for (int j = 0; j < m_cho_Tbl.Length; j++)
                {
                    if (m_cho_Tbl[j] == singleWord)
                        outValue += (10 + j).ToString();
                }
            }
        }
        else//모음
        {
            for (int i = 0; i < 2; i++)
            {
                char singleWord = word[i];
                for (int j = 0; j < m_jung_Tbl.Length; j++)
                {
                    if (m_jung_Tbl[j] == singleWord)
                        outValue += (10 + j).ToString();
                }
            }
        }
        return outValue;
    }

    void Load_tXml()
    {
        XmlDocument xmlDoc = new XmlDocument();

        TextAsset textAsset = (TextAsset)Resources.Load("HintData");
        xmlDoc.LoadXml(textAsset.text);

        for (int i = 0; i < word_arr.Length; i++)
        {
            string valueSet = WordtoValue(word_arr[i], 0);
            Dictionary<string, string> singleHintDict = new Dictionary<string, string>();

            string alphaSet = ValuetoAlphabet(valueSet);
            XmlNodeList nodes = xmlDoc.SelectNodes("HintData/" + alphaSet + "/WordSet");
            foreach (XmlNode node in nodes)
            {
                singleHintDict.Add(node.SelectSingleNode("Key").InnerText, node.SelectSingleNode("Value").InnerText);
            }

            chosungValHintTable.Add(valueSet, singleHintDict);

        }
        //        print("Hell World!");
    }

    void Load_wrongHintXml()
    {

        XmlDocument xmlDoc = new XmlDocument();

        TextAsset textAsset = (TextAsset)Resources.Load("WrongHintDataXml");
        xmlDoc.LoadXml(textAsset.text);


        XmlNodeList nodes = xmlDoc.SelectNodes("WrongHintData/HintSet");

        foreach (XmlNode node in nodes)
        {
            string[] wordset = node.SelectSingleNode("Value").InnerText.Split(',');
            chosungWrongHintTable.Add(node.SelectSingleNode("Key").InnerText, wordset);

        }
    }



}
