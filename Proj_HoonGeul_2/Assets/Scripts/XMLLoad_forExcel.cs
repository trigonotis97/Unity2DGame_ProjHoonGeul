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
    public int[] chosungCountArr = new int[21 * 21];
    public string[] countKey_arr = new string[21 * 21];
    public int[] countValue_arr = new int[21 * 21];
    public string[] choQuest_arr = new string[21 * 21];
    public int[] jongCount_arr;
    Text[] text_arr = new Text[4];

    int moeumCount = 21;
    public string[] moeumValue_arr;
    public int[] moeumCount_arr;
    void Start()
    {
        
        moeumCount = 21;

        chosungCountArr = new int[moeumCount * moeumCount];
        countKey_arr=new string[moeumCount * moeumCount];
        countValue_arr=new int[moeumCount * moeumCount];
        choQuest_arr=new string[moeumCount * moeumCount];
        jongCount_arr = new int[21*21];

        moeumValue_arr = new string[21];
        moeumCount_arr = new int[21];


        //text로 내보내기
        for (int i=0;i<4;i++)
        {
            if (i == 0)
                text_arr[i] = GameObject.Find("Text").GetComponent<Text>();
            else
                text_arr[i] = GameObject.Find("Text ("+i+")").GetComponent<Text>();
        }
        
        
        MakeKeyTabel();
        //MakeMoeumTable();

        LoadXml();

        //210000/
        //0 1 2345 6789
        
        ///text 로 카운트 데이터 내보내기
        for (int i = 0; i < 4; i++)
        {
            foreach (KeyValuePair<string, string> items in dictTbl[i])
            {
                wordCount(items.Value.Substring(6,4));
                
            }
            
            {
                //중성 조합한글글자와 카운트 내보내기
                for (int j = 0; j < moeumCount * moeumCount; j++)
                {
                    text_arr[i].text += choQuest_arr[j] + "\t" + countValue_arr[j] + "\n";// + jongCount_arr[j] + "\n";
                    countValue_arr[j] = 0;//다음 어원 카운트 할 수 있게 데이터 초기화
                    jongCount_arr[j] = 0;
                }
            }
            /*
            { //moeum
                for(int j=0;j<21;j++)
                {
                    text_arr[i].text += m_jung_Tbl[j] + "\t" + moeumCount_arr[j] + "\n";
                }
            }
            */

        }
        
    }
    //0 1 2345 6789   
  //  1 2 3456 78910 11
    //    0123 4567 8
    void wordCount(string inputvalue)
    { 
       
        string value = inputvalue.Substring(0, 4);
        //string jongValue = inputvalue.Substring(8);
        for (int i = 0; i < countKey_arr.Length; i++)
        {
            if (countKey_arr[i] == value)
            {
                countValue_arr[i]++;
                /*
                if (jongValue == "1")
                    jongCount_arr[i]++;*/
                break;
            }
        }
        /*
        

        //모음전용
        for(int i=0;i<2;i++)
        {
            string moeumVal = inputvalue.Substring(i * 2, 2);
            moeumCount_arr[ int.Parse(moeumVal)-10]++;
        }
        */

    }

    void MakeMoeumTable()
    {
        for(int i=0;i<21;i++)
        {
            moeumCount_arr[i] = 0;
            moeumValue_arr[i] = (10 + i).ToString();
        }
        
    }

    void MakeKeyTabel()
    {
        //모음형태로 바꿔놓음
        int word1 = 1000;
        int word2 = 10;
        int defaultindex = 1010;
        int indexCount = 0;

        int moEumCount = 21;
        for (int i = 0; i < moEumCount; i++)
        {

            for (int j = 0; j < moEumCount; j++)
            {
                if(indexCount>=countValue_arr.Length)
                {
                    print("throw error");
                }
                int temp = defaultindex + i * 100 + j;
                countValue_arr[indexCount] = 0;
                jongCount_arr[indexCount] = 0;

                countKey_arr[indexCount] = temp.ToString();

                choQuest_arr[indexCount++] = m_jung_Tbl[i].ToString() + m_jung_Tbl[j].ToString();
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
