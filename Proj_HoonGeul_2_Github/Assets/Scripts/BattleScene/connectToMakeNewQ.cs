using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class connectToMakeNewQ : MonoBehaviour
{
    public QuestionGen_RankMode QuestionGen_RankMode;
    ///애니메이션 이벤트 함수로 사용
    public void connect_makeNewQ()
    {
        //Debug.Log("nowTile is:" + chosungGeneratorDefault.correctState);
        QuestionGen_RankMode.MakeNewQuestion(QuestionGen_RankMode.correctState, false);//QuestionGen_RankMode.isChapter1Boss);
    }
}
