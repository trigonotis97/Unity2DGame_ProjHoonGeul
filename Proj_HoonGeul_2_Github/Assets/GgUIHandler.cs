using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GgUIHandler : MonoBehaviour
{
    GameManager m_gameManager;

    public Animator Animator;
    public MainSceneChange MainSceneChange;
    public GameObject forthButton;

    public int chapterNum, stageNum;
    public GameObject seceneBackButton, chapterBackButton;
    // Start is called before the first frame update
    private void Awake()
    {
        m_gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();

    }
    private void Start()
    {
        seceneBackButton.SetActive(true);
        chapterBackButton.SetActive(false);
    }
    public void ChapterSelect(int i)
    {
        seceneBackButton.SetActive(false);
        chapterBackButton.SetActive(true);
        chapterNum = i;
        //여기에서 챕터 넘버를 게임매니저에 넣어야함.
        if (i == 5)
        {
            forthButton.SetActive(true);
        }
        else
        {
            forthButton.SetActive(false);
        }

        Animator.SetTrigger("1to2");
    }
    public void StageSelect(int i)
    {
        m_gameManager.SetGameMode(3);
        stageNum = i;
        m_gameManager.SetPracticeBattleKey((chapterNum - 1) * 3 + stageNum - 1);
        int tempDialogkey = m_gameManager.SearchDialogInd(chapterNum, stageNum);
        m_gameManager.SetPracticeDialogKey(tempDialogkey);
        m_gameManager.SetPracticeSceneDataKey((m_gameManager.SearchSceneDataInd(tempDialogkey)));
        //게임매니저에 불러올 다이얼로그 넘버 새기고

        MainSceneChange.StoryModeClick(); // 여기에 stageNum, chpaterNum이 매개변수로 들어가야함.
    }
    public void BackToChapterSelect()
    {
        seceneBackButton.SetActive(true);
        chapterBackButton.SetActive(false);
        Animator.SetTrigger("2to1");
    }
}
