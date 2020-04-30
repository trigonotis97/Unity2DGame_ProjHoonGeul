using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class connectToMakeNewQ : MonoBehaviour
{
    public ChosungGeneratorDefault ChosungGeneratorDefault;

    public int m_correctState;
    public bool m_isEnemy =false;
    ///애니메이션 이벤트 함수로 사용
    public void connect_makeNewQ()
    {

        //Debug.Log("nowTile is:" + chosungGeneratorDefault.correctState);


        //ChosungGeneratorDefault.MakeNewQuestion(ChosungGeneratorDefault.correctState, ChosungGeneratorDefault.isChapter1Boss);
        ChosungGeneratorDefault.MakeNewQuestion(m_correctState, ChosungGeneratorDefault.isChapter1Boss,m_isEnemy);
    }
}
