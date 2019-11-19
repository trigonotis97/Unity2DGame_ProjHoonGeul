using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    SceneData sceneData;
    //DialogData m_data;
    GameManager m_gameManager;

    public Animator animator;
    public MainSceneChange MainSceneChange;
    //PracticeManager m_practiceManager;
    public int currentMode;
    public int nextscene;
    public int nextscenekey;
    private void Awake()
    {
        m_gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();

    }
    private void Start()
    {
        currentMode = m_gameManager.GetGameMode();
   
        sceneData = m_gameManager.GetSceneIndData(currentMode);
        nextscene = sceneData.nextScene;
        nextscenekey = sceneData.nextSceneKey;
        Debug.Log("CURRENT MODE ->" + currentMode);
        Debug.Log("SCENE DATA - next scene (1:dlg 2:bt) -> "+sceneData.nextScene);
        Debug.Log("SCENE DATA - next scene  key: " + sceneData.nextSceneKey);
    }
    
    public void StoryMode_SceneChanger()
    {

    }
    public void LastStoryMode_SceneChanger()
    {

    }
    
    public void NextScene()
    {
     

        //다음씬 모드 검색
        switch (sceneData.nextScene)
        {
            case 0: //메인 씬
                MainSceneChange.nextScene="StartScene"; animator.SetTrigger("nextScene!");
                break;

            case 1://다이얼로그

                if (sceneData.nextSceneKey % 9 == 0 && sceneData.nextSceneKey < 45) //다음 씬이 보너스 씬일경우
                {
                    MainSceneChange.nextScene = "BonusStagePenalty"; animator.SetTrigger("nextScene!");
                }
                else { //일반 다이얼로그 씬
                    if (currentMode == 1 || currentMode == 2)//스토리 모드
                    {
                        m_gameManager.SetCurrentDialogKey(sceneData.nextSceneKey);
                        MainSceneChange.nextScene = "DialogScene"; animator.SetTrigger("nextScene!");
                    }
                    else if(currentMode==3)//지난 이야기 모드일경우
                    {
                        bool isKnockDown = m_gameManager.GetDialogData(currentMode).isKnockDown;
                        Debug.Log("IS NOCKDOWN : " + isKnockDown.ToString());
                        if (isKnockDown)//지금이마지막 다이얼로그 씬일경우
                        {

                            MainSceneChange.nextScene = "LastStoryMode"; animator.SetTrigger("nextScene!");
                        }
                        else
                        {
                            m_gameManager.SetPracticeDialogKey(sceneData.nextSceneKey);
                            MainSceneChange.nextScene = "DialogScene"; animator.SetTrigger("nextScene!");
                        }
                    }
                }
                break;
            case 2://배틀
                if (currentMode == 1 || currentMode == 2)//스토리 모드
                {
                    m_gameManager.SetCurrentBattlekey(sceneData.nextSceneKey);
                    MainSceneChange.nextScene = "BattleScene"; animator.SetTrigger("nextScene!");
                }
                else if(currentMode ==3)// 지난이야기 모드 
                { 
                    m_gameManager.SetPracticeBattleKey(sceneData.nextSceneKey);
                    MainSceneChange.nextScene = "BattleScene"; animator.SetTrigger("nextScene!");
                }
                break;
            case 3:
                MainSceneChange.nextScene="BonusStageVoca"; animator.SetTrigger("nextScene!");
                break;
            case 4:
                MainSceneChange.nextScene="BonusStageCharacter"; animator.SetTrigger("nextScene!");
                break;
            case 5:
                MainSceneChange.nextScene="BonusStageSpelling"; animator.SetTrigger("nextScene!");
                break;
            case 6:
                MainSceneChange.nextScene="BonusStageSukBong"; animator.SetTrigger("nextScene!");
                break;
        }
    }
    public void BonusNextScene(bool isCorrect)
    {
        if (isCorrect == true)
        {
            m_gameManager.SetCurrentSceneKey(m_gameManager.GetCurrentSceneKey() + 1);
            sceneData = m_gameManager.GetSceneIndData(m_gameManager.GetGameMode());
            m_gameManager.SetCurrentDialogKey(sceneData.nextSceneKey);
            MainSceneChange.nextScene="DialogScene"; animator.SetTrigger("nextScene!");
        }
        else
        {
            m_gameManager.SetCurrentSceneKey(m_gameManager.GetCurrentSceneKey());
            sceneData = m_gameManager.GetSceneIndData(m_gameManager.GetGameMode());
            m_gameManager.SetCurrentDialogKey(sceneData.nextSceneKey);
            MainSceneChange.nextScene="DialogScene"; animator.SetTrigger("nextScene!");
        }
    }
}

