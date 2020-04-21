using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Xml;
using System.IO;


/* //여기서 할것

*/
public class EnemyHintBulletHandler : MonoBehaviour
{
    [Header("Show Variable (0~1)")]
    public float wordProb; //default : 30
    [Space(16)]
    public float hintProb; //default : 25
    //public float wrongHintProb; //default : 75
    public int sunbiMaxHitNum; //default : 2
    [Space(30)]
    public int sunbiHitCount = 0;
    public GameObject enemyBullet;


    Image bulletImage;
    Text bulletText;


    //bullet image variable
    Sprite[] bulletSprites=new Sprite[3];
    int bulletIndCount;

    /// 힌트관련 변수
    public Dictionary<string, Dictionary<string, string>> chosungValHintTable = new Dictionary<string, Dictionary<string, string>>();
    Dictionary<string, string[]> chosungWrongHintTable = new Dictionary<string, string[]>();

    //메잌뉴퀘스천 공유를 위함
    public Animator[] tile = new Animator[3];
    public connectToMakeNewQ[] m_connectToMakeNewQ = new connectToMakeNewQ[3];
    public BackGroundWordGen backgroundWordGen;

    BattleManager mbattleManager;
    public ChosungGeneratorDefault chosungGenerator;
    ///xml 완료 시 수정
    string[] wrongHintTable= { "바보","옥냥","국밥"};
    string[] rightHintTable= { "힌일","힌이","힌삼"};

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
    // key=questionValue , value=hintTable

    bool isAlreadyShow = false;
    string alreadyShowWord = "";


    private void Awake()
    {
        mbattleManager = GameObject.FindGameObjectWithTag("BattleManager").GetComponent<BattleManager>();
        bulletText= enemyBullet.transform.GetChild(1).GetComponent<Text>();
        bulletImage = enemyBullet.transform.GetChild(0).GetComponent<Image>();  
    }
    private void Start()
    {

        //변수 초기화
        bulletIndCount = 0;

        //chosungValHintTable 초기화
        LoadAllHintTable();

        //bullet image load->배틀씬에서 넣어준다.

        bulletImage.enabled = false;

    }
    public void SunbiHitCounter()//Sunbi.cs
    {
        sunbiHitCount++;
    }
    public void MakeHintorImage()
    {
        int hintProb = 2;
            /*
            HintProbHandler();
        if (sunbiHitCount >= sunbiMaxHitNum)
        {
            if(isAlreadyShow)//쳐맞은담에 또 쳐맞았을때
            {
                hintProb = 3;
            }
            else
            {
                hintProb = 2;
                isAlreadyShow = true;
            }
            //sunbiHitCount = 0;
        }
        */
        switch (hintProb)
        {
            case 0:// image bullet
                bulletImage.enabled = true;
                bulletImage.sprite = bulletSprites[bulletIndCount];
                bulletIndCount++;
                if (bulletIndCount == 3)
                    bulletIndCount = 0;

                Debug.Log("이미지 발사 index:" + bulletSprites[bulletIndCount].name);

                break;

            case 1://worng hint bullet
                string oldsetValue_ = chosungGenerator.GetOldestQuestionValue();
                int randInt_ = Random.Range(0, chosungWrongHintTable[oldsetValue_].Length);
                string outWrongHintWord = chosungWrongHintTable[oldsetValue_][randInt_];

                ///xml 완료시 수정
                bulletText.enabled=true;
                bulletText.text = outWrongHintWord;
                Debug.Log("오답힌트 발사 :" + outWrongHintWord);
                break;

            case 2://right hint bullet
                //현재 문제초성 데이터 가져오기  //그중에서 가장 오래된거 골라내기
                string oldsetValue = chosungGenerator.GetOldestQuestionValue();
                int randInt = Random.Range(0, chosungValHintTable[oldsetValue].Count);
                int indexCount = 0;
                string outHintWord="";
                //해당 문제 밸류값으로 힌트 검색, 랜덤으로 선택
                foreach (KeyValuePair<string,string> hintword in chosungValHintTable[oldsetValue])
                {
                    if(indexCount==randInt)
                    {
                        outHintWord = hintword.Key;
                        break;
                    }
                    indexCount++;
                }
                //Debug.Log("정답힌트 발사:" + outHintWord);

                m_connectToMakeNewQ[chosungGenerator.GetOldestQuestIndex()].m_correctState = chosungGenerator.GetOldestQuestIndex();
                tile[chosungGenerator.GetOldestQuestIndex()].SetTrigger("correct");

                backgroundWordGen.MakeWordRandomPos(outHintWord);
                ///xml 완료시 수정
                bulletText.enabled = true;
                bulletText.text = outHintWord;
                alreadyShowWord = outHintWord;
                break;
            case 3:
                bulletText.enabled = true;
                bulletText.text = alreadyShowWord;
                Debug.Log("정답힌트 발사+다회차:" + alreadyShowWord);
                break;

        }
    }
    
    public void ResetSunbiHitCount()//chosung generator.cs
    {
        sunbiHitCount = 0;
        isAlreadyShow = false;
    }

    int HintProbHandler()
    {
        float word_percent = Random.Range(0f, 100f);

        if(word_percent <= wordProb)
        {
            float hint_percent = Random.Range(0f, 100f);
            if (hint_percent <= hintProb)
                return 2;//make right hint bullet
            else
                return 1;//make wrong hint bullet
        }
        return 0;// image bullet
    }

    ///정답+오답 힌트 뽑아주는거
    string FindHintWord(string targetValue,Dictionary<string,Dictionary<string, string>> targetTable)
    {
        string hintStr = "";

        Dictionary<string, string> hintTable=new Dictionary<string, string>();
        if (targetTable.ContainsKey(targetValue))
        {
            hintTable = targetTable[targetValue];
        }
        else
        {
            Debug.LogError("초성테이블에 없는 초성value");
        }
        int randomIndex = Random.Range(0, hintTable.Count);
        int tempIndex=0;
        foreach (var targetHint in hintTable)
        {
            if(tempIndex==randomIndex)
            {
                hintStr = targetHint.Value;
                break;
            }
            tempIndex++;
        }

        return hintStr;
    }

    ///입력한 답이 정답 테이블에 있으면 지운다.
    public void DeleteHintWord(string targetValue,string targetWord)
    {
        Dictionary<string, string> hintTable = new Dictionary<string, string>();
        if(chosungValHintTable.ContainsKey(targetValue))
        {
            hintTable = chosungValHintTable[targetValue];
            if (hintTable.ContainsKey(targetWord))
            {
                chosungValHintTable.Remove(targetWord);
                Debug.Log("맞춘단어 힌트에서 제외 : " + targetWord);
                sunbiHitCount = 0;
            }
        }
    }
    
    public void LoadBulletImage(Sprite[]sprites)
    {
        bulletSprites=sprites;
        
    }


    public string WordtoValue(string word, int type)
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

    void LoadAllHintTable()
    {
        chosungValHintTable = mbattleManager.GetUsingHint();
        chosungWrongHintTable = mbattleManager.GetUsingWrongHint();
    }



    /*
string WordToValue(string word)
{

}
*/

}
