using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using System;


//for Canvas include 4 child Text
public class Test_XmlDataTool : MonoBehaviour
{

    private static string m_cho_Tbl = "ㄱㄲㄴㄷㄸㄹㅁㅂㅃㅅㅆㅇㅈㅉㅊㅋㅌㅍㅎ"; // 10부터 시작
    private static string m_jung_Tbl = "ㅏㅐㅑㅒㅓㅔㅕㅖㅗㅘㅙㅚㅛㅜㅝㅞㅟㅠㅡㅢㅣ";
    private static string m_jong_Tbl = " ㄱㄲㄳㄴㄵㄶㄷㄹㄺㄻㄼㄽㄾㄿㅀㅁㅂㅄㅅㅆㅇㅈㅊㅋㅌㅍㅎ";
    private static ushort mUniCode_Base = 0xAC00;
    private static ushort mUniCode_Last = 0xD79F;
    private static string m_Cho;
    private static string m_Jung;
    private static string m_Jong;

    //자음개수 : 19
    //모음개수 : 21

    int[] chosungCount_arr = new int[19 * 19]; // 최종 output text
    string[] chosungValue_arr = new string[19 * 19];

    TextAsset[] textAsset = new TextAsset[4];
    string[] countKey_arr = new string[19 * 19];
    int[] countValue_arr = new int[19 * 19];
    string[] choQuest_arr = new string[19 * 19];

    void Start()
    {
        MakeKeyTabel();

        LoadDictionaryXml();
    }

    void LoadDictionaryXml()
    {
        textAsset[0] = (TextAsset)Resources.Load("2umjul_Goyu"); // WordDictionary.xml 파일은 Resources안에 있음. 
        textAsset[1] = (TextAsset)Resources.Load("2umjul_Hanja"); // WordDictionary.xml 파일은 Resources안에 있음. 
        textAsset[2] = (TextAsset)Resources.Load("2umjul_Honjong"); // WordDictionary.xml 파일은 Resources안에 있음. 
        textAsset[3] = (TextAsset)Resources.Load("2umjul_Waerae"); // WordDictionary.xml 파일은 Resources안에 있음. 

        XmlDocument xmlDoc = new XmlDocument();

        XmlNodeList nodes = xmlDoc.SelectNodes("WordDic/WordSet"); // 가져올 노드 설정

        string AllNodes = "";

        foreach (XmlNode node in nodes)
        {
            AllNodes = AllNodes + WordToValue("3", node.SelectSingleNode("Key").InnerText) + "\n"; // foreach문을 돌면서 모든 <Word>를 불러옴.
        }


    }

    string WordToValue(string wordType /*단어 어원*/ , string inputWord)
    {
        string output = "";

        output += inputWord.Length.ToString(); // 첫번째 : 글자개수 입력
        output += wordType; // 두번째 : 단어 어원 입력 ( 1-고유어 2-한자어 3-외래어 4-혼종어)

        //char[] word_array = inputWord.ToCharArray();


        output += Divide_Hangul(inputWord);



        return output;
    }


    public string Divide_Hangul(string s_input)
    {
        int i_cho_Idx, i_jung_Idx, i_jong_Idx; // 초성,중성,종성의 인덱스
        ushort uTempCode = 0x0000;       // 임시 코드용
                                         //Char을 16비트 부호없는 정수형 형태로 변환 - Unicode

        //string result="";
        string jaeum = "";
        string moeum = "";
        bool isExistedJong = false;
        for (int s = 0; s < s_input.Length; s++)
        {
            char c_input = s_input[s];
            uTempCode = Convert.ToUInt16(c_input);
            // 캐릭터가 한글이 아닐 경우 처리
            if ((uTempCode < mUniCode_Base) || (uTempCode > mUniCode_Last))
            {
                m_Cho = ""; m_Jung = ""; m_Jong = "";
            }


            // iUniCode에 한글코드에 대한 유니코드 위치를 담고 이를 이용해 인덱스 계산.
            int iUniCode = uTempCode - mUniCode_Base;

            i_cho_Idx = iUniCode / (21 * 28);
            iUniCode = iUniCode % (21 * 28);
            i_jung_Idx = iUniCode / 28;
            iUniCode = iUniCode % 28;
            i_jong_Idx = iUniCode;


            m_Cho = new string(m_cho_Tbl[i_cho_Idx], 1);
            m_Jung = new string(m_jung_Tbl[i_jung_Idx], 1);
            m_Jong = new string(m_jong_Tbl[i_jong_Idx], 1);

            /*
            Debug.Log("초성 : " + m_Cho);
            Debug.Log("중성 : " + m_Jung);
            Debug.Log("종성 : " + m_Jong);
            */
            //char[] cho_chartable = m_cho_Tbl.ToCharArray();

            //value 만들기
            int wordValue = 0;
            //char[] cho_temp = m_Cho.ToCharArray();

            //초성 value 
            for (int i = 0; i < m_cho_Tbl.Length; i++)
            {
                // i : 0 ~ 
                if (m_Cho[0] == m_cho_Tbl[i])
                {
                    wordValue = i + 10;
                    /*
                    ㄱ 일경우 10 
                    ㅎ 일경우 28
                    */
                }
            }

            jaeum += wordValue.ToString();

            //모음 value
            wordValue = 0;
            for (int i = 0; i < m_jung_Tbl.Length; i++)
            {
                if (m_Jung[0] == m_jung_Tbl[i])
                {
                    wordValue = i + 10;
                    // ㅏ일경우 10
                }

            }
            moeum += wordValue;

            //종성 유무
            isExistedJong = isExistedJong || (!(m_Jong[0] == m_jong_Tbl[0]));//종성 없을경우
        }
        string jong = "";
        if (isExistedJong == true)
        {
            jong = "1";
        }
        else
            jong = "0";

        return jaeum + moeum + jong;

    }


    void wordCount(string value)
    {
        for (int i = 0; i < countKey_arr.Length; i++)
        {
            if (countKey_arr[i] == value)
            {
                countValue_arr[i]++;
                break;
            }
        }
    }

    void MakeKeyTabel()
    {

        int word1 = 1000;
        int word2 = 10;
        int defaultindex = 1010;
        int indexCount = 0;

        for (int i = 0; i < 19; i++)
        {
            for (int j = 0; j < 19; j++)
            {
                int temp = defaultindex + i * 100 + j;
                countValue_arr[indexCount] = 0;
                countKey_arr[indexCount] = temp.ToString();
                choQuest_arr[indexCount++] = m_cho_Tbl[i].ToString() + m_cho_Tbl[j].ToString();
            }
        }

    }

}
