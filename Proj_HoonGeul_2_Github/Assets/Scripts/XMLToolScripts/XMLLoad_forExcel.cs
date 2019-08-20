using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using System;
using UnityEngine.UI;

public class XMLLoad_forExcel : MonoBehaviour
{
    

    public Dictionary<string, string> []dictTbl = new Dictionary<string, string>[4];

    //for count
    private static string m_cho_Tbl = "ㄱㄲㄴㄷㄸㄹㅁㅂㅃㅅㅆㅇㅈㅉㅊㅋㅌㅍㅎ"; // 10부터 시작
    private static string m_jung_Tbl = "ㅏㅐㅑㅒㅓㅔㅕㅖㅗㅘㅙㅚㅛㅜㅝㅞㅟㅠㅡㅢㅣ"; //10+ 21
    public string[] valueIndex_arr = new string[21 * 21];
    public int[] countValue_arr = new int[21 * 21];
    public string[] word_arr = new string[21 * 21];
    public int[] jongCount_arr;
    Text[] text_arr = new Text[4];

    int jaeumCount = 19;
    int moeumCount = 21;
    int wordSize;
    public string[] wordValue_arr;
    public int[] wordCount_arr;
    void Start()
    {
        ///여기서 자음 모음 선택
        wordSize= jaeumCount;

        valueIndex_arr=new string[wordSize * wordSize];
        countValue_arr=new int[wordSize * wordSize];
        word_arr=new string[wordSize * wordSize];
        //jongCount_arr = new int[21*21];

        wordValue_arr = new string[wordSize];
        wordCount_arr = new int[wordSize];


        
        for (int i=0;i<4;i++)
        {
            if (i == 0)
                text_arr[i] = GameObject.Find("Text").GetComponent<Text>();
            else
                text_arr[i] = GameObject.Find("Text ("+i+")").GetComponent<Text>();
        }
        
        
        MakeWordTabel();

        LoadXml();


        //0 1 2345 6789 10
        
        ///text 로 카운트 데이터 내보내기
        for (int i = 0; i < 4; i++)
        {
            foreach (KeyValuePair<string, string> items in dictTbl[i])
            {
                wordCount(items.Value);
                
            }
            
            {
                //중성 조합한글글자와 카운트 내보내기
                for (int j = 0; j <wordSize * wordSize; j++)
                {
                    text_arr[i].text += word_arr[j] + "\t" + countValue_arr[j] + "\n";// + jongCount_arr[j] + "\n";
                    countValue_arr[j] = 0;//다음 어원 카운트 할 수 있게 데이터 초기화
                    //jongCount_arr[j] = 0;
                }
            }


        }
        
    }
    //0 1 2345 6789   
  //  1 2 3456 78910 11
    //    0123 4567 8
    void wordCount(string inputvalue)
    {
        string value;
        if(wordSize==19)
        {
            value=inputvalue.Substring(2, 4);
        }
        else // 모음
        {
            value = inputvalue.Substring(6, 4);
       
        }
        for (int i = 0; i < 2; i++)
        {
            string singleValue = value.Substring(i * 2, 2);
            wordCount_arr[int.Parse(singleValue) - 10]++;
        }


        for (int i = 0; i < valueIndex_arr.Length; i++)
        {
            if (valueIndex_arr[i] == value)
            {
                countValue_arr[i]++;
                break;
            }
        }


    }


    void InitTable()
    {
        for(int i=0;i<wordSize;i++)
        {
            wordCount_arr[i] = 0;
            wordValue_arr[i] = (10 + i).ToString();
        }
        
    }

    void MakeWordTabel()
    {

        int word1 = 1000;
        int word2 = 10;

        int defaultindex = 1010;
        int indexCount = 0;

        for (int i = 0; i < wordSize; i++)
        {

            for (int j = 0; j < wordSize; j++)
            {
                if(indexCount>=countValue_arr.Length)
                {
                    print("throw error");
                }
                int value = defaultindex + i * 100 + j;
                countValue_arr[indexCount] = 0;

                //jongCount_arr[indexCount] = 0; // 종성 카운트시 사용

                valueIndex_arr[indexCount] = value.ToString();
                if(wordSize==19)
                    word_arr[indexCount++] = m_cho_Tbl[i].ToString() + m_cho_Tbl[j].ToString();
                else // 모음
                    word_arr[indexCount++] = m_jung_Tbl[i].ToString() + m_jung_Tbl[j].ToString();


            }

        }
    }



    void LoadXml()
    {
        System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();

        sw.Start();


        TextAsset[] textAsset = new TextAsset[] { (TextAsset)Resources.Load("2umjul_Goyu"), (TextAsset)Resources.Load("2umjul_Hanja"), (TextAsset)Resources.Load("2umjul_Waerae"), (TextAsset)Resources.Load("2umjul_Honjong"), };
        //Debug.Log(textAsset);
        XmlDocument xmlDoc = new XmlDocument();

        for (int i = 0; i < 4; i++)
        {
            dictTbl[i] = new Dictionary<string, string>();
            xmlDoc.LoadXml(textAsset[i].text);

            XmlNodeList nodes = xmlDoc.SelectNodes("WordDic/WordSet"); // 가져올 노드 설정

            foreach (XmlNode node in nodes)
            {
                dictTbl[i].Add(node.SelectSingleNode("Key").InnerText, node.SelectSingleNode("Value").InnerText);
                //Debug.Log(node.SelectSingleNode("Key").InnerText + node.SelectSingleNode("Value").InnerText);
            }

        }

        sw.Stop();

        Debug.Log(sw.ElapsedMilliseconds.ToString() + "ms");
    }
}
