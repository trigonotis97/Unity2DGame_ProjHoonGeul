using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GgUIHandler : MonoBehaviour
{
    public Animator Animator;
    public MainSceneChange MainSceneChange;
    public GameObject forthButton;

    public int chpaterNum, stageNum;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ChapterSelect(int i)
    {
        chpaterNum = i;
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
        stageNum = i;
        //게임매니저에 불러올 다이얼로그 넘버 새기고
        MainSceneChange.StoryModeClick(); // 여기에 stageNum, chpaterNum이 매개변수로 들어가야함.
    }
    public void BackToChapterSelect()
    {
        Animator.SetTrigger("2to1");
    }
}
