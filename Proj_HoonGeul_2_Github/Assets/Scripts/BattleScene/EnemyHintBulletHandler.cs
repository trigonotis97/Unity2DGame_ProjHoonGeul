using System.Collections;
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
    public void SunbiHitCounter()//Sunbi.cs
    {
        sunbiHitCount++;
        if(sunbiHitCount==sunbiMaxHitNum)
        {
            // make hint bullet
        }
    }

    
    public void ResetSunbiHitCount()//chosung generator.cs
    {
        sunbiHitCount = 0;
    }

    void HintProbHandler()
    {
        float word_percent = Random.Range(0f, 100f);

        if(word_percent >= wordProb)
        {
            float hint_percent = Random.Range(0f, 100f);
            if(hint_percent>=hintProb)
            {
                //make hint bullet
            }
        }
    }
}
