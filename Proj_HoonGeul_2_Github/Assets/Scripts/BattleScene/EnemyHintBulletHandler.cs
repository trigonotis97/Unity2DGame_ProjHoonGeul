﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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


    /// temp variable
    Dictionary<string, Dictionary<string, string>> chosungValHintTable = new Dictionary<string, Dictionary<string, string>>();
    BattleManager mbattleManager;
    // key=questionValue , value=hintTable

    /*
//힌트, 오답 투사체 위한 변수 가져오기 
    - 선비 오브젝트의 피격 횟수
    - 정답 맞출때 체크
    - 힌트,오답 가져오기
    - 힌트: 이미 쓴거중에 똑같은거는 안나오게 검색, 사전에실제로 있는단어 검색
구현할거
    - 힌트, 오답 확률 (확률변수 인스펙터로 보이게 만들기)
    - 힌트 검색

힌트 단어 풀 생성
    - 자음 단어 별 단어 풀 생성
*/
    private void Awake()
    {
        mbattleManager = GameObject.FindGameObjectWithTag("BattleManager").GetComponent<BattleManager>();
    }
    private void Start()
    {
        //hintTable 초기화
        ///이 스테이지에서 사용할 초성 문제의 정답 데이터를 받아옴(복사)
        /// m_data->problemPocket + hellPoket
        /// 

        hintTable.Add()
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

    ///오브젝트에 넣기

    string WordToValue(string word)
    {

    }
}
