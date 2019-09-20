using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConnectToMakeNewQ_RankMode : MonoBehaviour
{
    public QuestionGen_RankMode m_generator;

    public void connect_makeNewQ()
    {
        //Debug.Log("nowTile is:" + m_rankModeManager.correctState);
        m_generator.MakeNewQuestion(m_generator.correctState, false/*isChapter1Boss*/);
    }
}


