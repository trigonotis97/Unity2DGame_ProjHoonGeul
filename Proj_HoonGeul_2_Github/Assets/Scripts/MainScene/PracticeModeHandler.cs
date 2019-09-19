using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PracticeModeHandler : MonoBehaviour
{
    public GameObject practiceMangerObj;
    // Start is called before the first frame update
    void Start()
    {
        
    }


    public void StartPracticeMode(int chapterNum, int stageNum)
    {
        GameObject pm_obj = Instantiate(practiceMangerObj) as GameObject;
        PracticeManager tempPm = pm_obj.GetComponent<PracticeManager>();
        tempPm.SetBattleIndex((chapterNum-1)*3 + stageNum-1 );
       //tempPm.SetDialogIndex()/
    }
}
