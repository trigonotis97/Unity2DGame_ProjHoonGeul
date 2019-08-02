using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class connectToMakeNewQ : MonoBehaviour
{
    public ChosungGeneratorDefault chosungGeneratorDefault;
    ///애니메이션 이벤트 함수로 사용
    public void connect_makeNewQ()
    {
        Debug.Log("nowTile is:" + chosungGeneratorDefault.correctState);
        chosungGeneratorDefault.MakeNewQuestion(chosungGeneratorDefault.correctState, chosungGeneratorDefault.isChapter1Boss);
    }
}
