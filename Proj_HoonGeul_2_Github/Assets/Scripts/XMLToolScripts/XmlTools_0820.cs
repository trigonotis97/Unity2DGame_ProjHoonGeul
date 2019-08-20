using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using System.IO;


public class XmlTools_0820 : MonoBehaviour
{

    private static string m_cho_Tbl = "ㄱㄲㄴㄷㄸㄹㅁㅂㅃㅅㅆㅇㅈㅉㅊㅋㅌㅍㅎ"; // 10부터 시작
    private static string m_jung_Tbl = "ㅏㅐㅑㅒㅓㅔㅕㅖㅗㅘㅙㅚㅛㅜㅝㅞㅟㅠㅡㅢㅣ";
    private static string m_jong_Tbl = " ㄱㄲㄳㄴㄵㄶㄷㄹㄺㄻㄼㄽㄾㄿㅀㅁㅂㅄㅅㅆㅇㅈㅊㅋㅌㅍㅎ";
    private static string m_alphabet_Tbl = "abcdefghijklmnopqrstuvwxyz";

    //get xml data
    public XMLLoad xmlData;
    Dictionary<string, string>[] dictTable;

    XmlDocument xmlDoc = new XmlDocument();
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
"ㄷㅌ"
        };
    string[] value_arr;
    void Start()
    {


    }

    public void Loop()
    {
        value_arr = new string[word_arr.Length];

        //value arr 초기화
        for (int i = 0; i < word_arr.Length; i++)
        {
            value_arr[i] = WordtoValue(word_arr[i], 0);
        }

        CreateXml();
        dictTable = xmlData.GetDictData();
        
        SaveHintWord();

        xmlDoc.Save("./Assets/Resources/Character.xml");

    }


    void CreateXml()
    {


        // Xml을 선언한다(xml의 버전과 인코딩 방식을 정해준다.)

        // 자식 노드 생성
        /*
        // 자식 노드에 들어갈 속성 생성
        XmlElement name = xmlDoc.CreateElement("Name");
        name.InnerText = "wergia";
        child.AppendChild(name);

        XmlElement lv = xmlDoc.CreateElement("Level");
        lv.InnerText = "1";
        child.AppendChild(lv);

        XmlElement exp = xmlDoc.CreateElement("Experience");
        exp.InnerText = "45";
        child.AppendChild(exp);
        */
    }
   

    void SaveHintWord()
    {
        xmlDoc.AppendChild(xmlDoc.CreateXmlDeclaration("1.0", "utf-8", "yes"));

        // 루트 노드 생성
        XmlNode root = xmlDoc.CreateNode(XmlNodeType.Element, "HintData", string.Empty);
        xmlDoc.AppendChild(root);




        //XmlElement name = xmlDoc.CreateElement("Name");

        for (int j = 0; j < word_arr.Length; j++)
        {

            XmlNode child = xmlDoc.CreateNode(XmlNodeType.Element, ValuetoAlphabet(value_arr[j]), string.Empty);
            root.AppendChild(child);

            Dictionary<string, string> tempWordTable = new Dictionary<string, string>();
            for (int i = 0; i < 4; i++)
            {
                int isExist = 0;
                foreach (KeyValuePair<string, string> items in dictTable[i])
                {
                    if (items.Value.Substring(2, 4) == value_arr[j])
                    {
                        if (!tempWordTable.ContainsKey(items.Key))
                        {
                            tempWordTable.Add(items.Key, items.Value);
                            isExist = 1;
                        }
                    }
                }
                Debug.Log(tempWordTable.Count);
            }

            int[] ind_arr = new int[10];
            string []indVall_arr = new string[10];
            for (int h = 0; h < 10; h++)
            {

                int randint = MakeRandomInd(tempWordTable.Count, ind_arr, h);

                ind_arr[h] = randint;
                int indCount = 0;
                foreach (KeyValuePair<string, string> items in tempWordTable)
                {
                    if (indCount == randint)
                    {
                        

                        XmlNode wordset = xmlDoc.CreateNode(XmlNodeType.Element, "WordSet", string.Empty);
                        child.AppendChild(wordset);
                        XmlElement key = xmlDoc.CreateElement("Key");
                        key.InnerText = items.Key;
                        child.AppendChild(key);

                        XmlElement value = xmlDoc.CreateElement("Value");
                        value.InnerText = items.Value;
                        child.AppendChild(value);
                        break;
                    }
                    else
                        indCount++;
                }

            }

        }

    }
    int MakeRandomInd(int size, int[] ind_arr, int arrMaxNum)
    {

        bool isExist = false;
        int randint;
        do
        {
            isExist = false;
            randint = Random.Range(0, size);
            for (int g = 0; g < arrMaxNum; g++)
            {
                if (ind_arr[g] == randint)
                    isExist = true;
            }
        } while (isExist);

        return randint;
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

    string ValuetoWord(string value, int type)
    {
        string outWord = "";
        if (type == 0)//자음
        {
            for (int i = 0; i < 2; i++)
                outWord += m_cho_Tbl[int.Parse(value.Substring(i * 2, 2)) - 10].ToString();
        }
        else//모음
        {
            for (int i = 0; i < 2; i++)
                outWord += m_jung_Tbl[int.Parse(value.Substring(i * 2, 2)) - 10].ToString();
        }
        return outWord;
    }

    string ValuetoAlphabet(string value)
    {
        string outAlpha= "";
        
            for (int i = 0; i < 2; i++)
                outAlpha += m_alphabet_Tbl[int.Parse(value.Substring(i * 2, 2)) - 10].ToString();
        return outAlpha;
    }

}

