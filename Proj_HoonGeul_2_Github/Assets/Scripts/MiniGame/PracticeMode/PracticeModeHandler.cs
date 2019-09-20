using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class PracticeModeHandler : MonoBehaviour
{
    public GameObject practiceMangerPref;
    GameManager m_gameManager;
    int chapterNum;
    // Start is called before the first frame update
    void Start()
    {
        m_gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }

    public void SetChapterNum(int num)
    {
        this.chapterNum = num;
    }

    public void StartPracticeMode(int stageNum)
    {
        GameObject pm_obj = Instantiate(practiceMangerPref) as GameObject;
        PracticeManager tempPm = pm_obj.GetComponent<PracticeManager>();

        tempPm.SetBattleIndex((chapterNum - 1) * 3 + stageNum - 1);
        tempPm.SetDialogIndex(m_gameManager.SearchDialogInd(chapterNum, stageNum));
        SceneManager.LoadScene("DialogScene");
    }
}

