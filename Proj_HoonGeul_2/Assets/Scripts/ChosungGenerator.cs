using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



    


public class ChosungGenerator : MonoBehaviour
{
    Text[] Chosung_text_arr=new Text[3];
    string[] choValStr = new string[3];
    /*
    Text Chosung2;
    Text Chosung3;
    */
    public static int ChosungRandom; // 이 ChosungNum 변수가 Test_Input.cs에서 2차원 배열을 불러올 때 사용됨. 즉 초성에 맞는 단어 사전의 주소가 되는 역할. 
    public static string ChosungStr; // 랜덤 정수 값으로 생성된 ChosungNum을 String으로 변경. 0부터 차례로 ㄱㄱ, ㄱㄴ, ㄱㄷ ... 순으로 우선 배열해 둠. 

    public static int Chosung1Num;
    public static int Chosung2Num;
    public static int Chosung3Num;

    string m_cho_Tbl = "ㄱㄲㄴㄷㄸㄹㅁㅂㅃㅅㅆㅇㅈㅉㅊㅋㅌㅍㅎ";
    string[] ques_cho_value = new string[3];
    void Start()
    {
        Chosung_text_arr[0] = GameObject.Find("chosung1").GetComponent<Text>();
        Chosung_text_arr[1] = GameObject.Find("chosung2").GetComponent<Text>();
        Chosung_text_arr[2] = GameObject.Find("chosung3").GetComponent<Text>();
        choValStr = new string[3]{ "","",""};
    }

    //scene manager 에서 호출 , test_input 에서 정답시 호출
    public void MakeNewQuestion(int index)
    {
        string questStr;
        bool isSameWord = false;

        //
        do
        {
            questStr = getRandomChoseongText();
            isSameWord = false;
            for (int t = 0; t < 3; t++)
            {
                if (Chosung_text_arr[t].text == questStr)
                {
                    isSameWord = true;
                    break;
                }
            }
        } while (isSameWord);

        int[] choVal = new int[2];
        for (int n = 0; n < 2; n++)
        {
            for (int i = 0; i < 19; i++)
            {
                if (questStr[n] == m_cho_Tbl[i])
                {
                    choVal[n] = i + 10;
                    break;
                }

            }
        }

        string cho_value = choVal[0].ToString() + choVal[1].ToString();

        Chosung_text_arr[index].text = questStr;
        choValStr[index] = cho_value;
    }

    string getRandomChoseongText()
    {
        string[] questTbl = new string[]
        {
            //"ㅇㅈ","ㄱㅅ","ㅈㅎ","ㅅㅅ","ㅂㅁ","ㅂㄱ" 32
            "ㄱㄹ","ㄱㄱ","ㅅㄱ","ㅂㅈ","ㅁㅁ","ㅈㄹ"
        };
        string outString = questTbl[Random.Range(0, questTbl.Length)];

        return outString;
    }
    public string[] getQuestValue()
    {
        return choValStr;
    }
    /*
    public int ChosungGenerate() // 이 함수에서 ChosungRandom의 난수를 생성, 각각의 ChosungNum들의 값에 대입.
    {
        ChosungRandom = Random.Range(0, 4);
        Debug.Log(ChosungRandom);
        return ChosungRandom;
    }

    public string ChosungTranslate(int i) // 이 함수에서 ChosungNum들의 값을 String으로 시각화.
    {
        switch (i)      
        {
            case 0:
                ChosungStr = "ㄱㄱ";
                break;
            case 1:
                ChosungStr = "ㄱㄴ";
                break;
            case 2:
                ChosungStr = "ㄱㄷ";
                break;
            case 3:
                ChosungStr = "ㄱㄹ";
                break;
        }
        return ChosungStr;
    }

    // 아래의 함수 3개 = EnemyScript의 IEnumerator BeforeStart에서 최초로, 그 후로는 계속 Test_Input의 textInputEnter의 if 문 안에서 호출.  

    public void ChosungText1()
    {
        Chosung1Num = ChosungGenerate();
        Chosung1.text = ChosungTranslate(Chosung1Num);
    }

    public void ChosungText2()
    {
        Chosung2Num = ChosungGenerate();
        Chosung2.text = ChosungTranslate(Chosung2Num);
    }

    public void ChosungText3()
    {
        Chosung3Num = ChosungGenerate();
        Chosung3.text = ChosungTranslate(Chosung3Num);
    }
    */

}
