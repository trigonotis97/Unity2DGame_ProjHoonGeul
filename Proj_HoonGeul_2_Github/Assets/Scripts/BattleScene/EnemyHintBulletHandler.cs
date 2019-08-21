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
    Dictionary<string, Dictionary<string, string>> chosungValHintTable = new Dictionary<string, Dictionary<string, string>>();
    BattleManager mbattleManager;

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
"ㄷㅌ"
        };
    // key=questionValue , value=hintTable

    /*
//힌트, 오답 투사체 위한 변수 가져오기 
    - 선비 오브젝트의 피격 횟수
    - 정답 맞출때 체크
    - 힌트,오답 가져오기
    - 힌트: 이미 쓴거중에 똑같은거는 안나오게 검색, 사전에실제로 있는단어 검색
구현할거(0)
    - 힌트, 오답 확률 (확률변수 인스펙터로 보이게 만들기)(0)
    - 힌트 검색(0)

힌트 단어 풀 생성
    - 자음 단어 별 단어 풀 생성
*/
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
        //chosungValHintTable
        //bullet 이미지 로드


        //hintTable 초기화
        ///이 스테이지에서 사용할 초성 문제의 정답 데이터를 받아옴(복사)
        /// m_data->problemPocket + hellPoket
        /// 

       
    }
    public void SunbiHitCounter()//Sunbi.cs
    {
        sunbiHitCount++;
        if(sunbiHitCount==sunbiMaxHitNum)
        {
            // make hint bullet
        }
    }
    public void Loop()
    {
        int hintProb = HintProbHandler();
        switch(hintProb)
        {
            case 0:// image bullet
                bulletImage.enabled = true;
                bulletImage.sprite = bulletSprites[bulletIndCount];
                bulletIndCount++;
                if (bulletIndCount == 3)
                    bulletIndCount = 0;
                break;

            case 1://worng hint bullet
                ///xml 완료시 수정
                bulletText.enabled=true;
                bulletText.text = wrongHintTable[Random.Range(0, wrongHintTable.Length)];
                break;

            case 2://right hint bullet
                ///xml 완료시 수정
                bulletText.enabled = true;
                bulletText.text = rightHintTable[Random.Range(0, wrongHintTable.Length)];
                break;

        }
    }
    
    public void ResetSunbiHitCount()//chosung generator.cs
    {
        sunbiHitCount = 0;
    }

    int HintProbHandler()
    {
        float word_percent = Random.Range(0f, 100f);

        if(word_percent >= wordProb)
        {
            float hint_percent = Random.Range(0f, 100f);
            if (hint_percent >= hintProb)
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
    void DeleteHintWord(string targetValue,string targetWord)
    {
        Dictionary<string, string> hintTable = new Dictionary<string, string>();
        if(chosungValHintTable.ContainsKey(targetValue))
        {
            hintTable = chosungValHintTable[targetValue];
            if (hintTable.ContainsKey(targetWord))
            {
                chosungValHintTable.Remove(targetWord);
            }
        }
    }
    
    public void LoadBulletImage(Sprite[]sprites)
    {
        bulletSprites=sprites;
        
    }


        /*
    string WordToValue(string word)
    {

    }
    */

}
