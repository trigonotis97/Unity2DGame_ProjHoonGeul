using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class connectToMakeNewQ : MonoBehaviour
{
    public ChosungGeneratorDefault chosungGeneratorDefault;
    
    public void connect_makeNewQ()
    {
        Debug.Log("nowTile is:" + chosungGeneratorDefault.CorrectIdx);
        chosungGeneratorDefault.MakeNewQuestion(chosungGeneratorDefault.CorrectIdx, chosungGeneratorDefault.isChapter1Boss);
    }
}
