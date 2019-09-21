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
        Debug.Log(m_gameManager.GetCurrentSceneKey());
        sceneData = m_gameManager.GetSceneIndData(currentMode);
        nextscene = sceneData.nextScene;
        nextscenekey = sceneData.nextSceneKey;

        //m_data = m_gameManager.GetDialogData();
    }
    

    public void NextScene()
    {
        Debug.Log(sceneData.nextScene);
        Debug.Log(sceneData.nextSceneKey);
        switch (sceneData.nextScene)
        {
            case 0:
                MainSceneChange.nextScene="StartScene"; animator.SetTrigger("nextScene!");
                break;
            case 1://다이얼로그
                if (sceneData.nextSceneKey % 9 == 0 && sceneData.nextSceneKey < 45)
                {
                    MainSceneChange.nextScene = "BonusStagePenalty"; animator.SetTrigger("nextScene!");
                }
                else { 
                    if (currentMode == 1 || currentMode == 2)//스토리 모드
                    {
                        m_gameManager.SetCurrentDialogKey(sceneData.nextSceneKey);
                        MainSceneChange.nextScene = "DialogScene"; animator.SetTrigger("nextScene!");
                    }
                    else if(currentMode==3)//연습모드일경우
                    {
                        m_gameManager.SetPracticeDialogKey(sceneData.nextSceneKey);
                        MainSceneChange.nextScene = "DialogScene"; animator.SetTrigger("nextScene!");
                    }
                }
                
                break;
            case 2://배틀
                if (currentMode == 1 || currentMode == 2)//스토리 모드
                {
                    m_gameManager.SetCurrentBattlekey(sceneData.nextSceneKey);
                    MainSceneChange.nextScene = "BattleScene"; animator.SetTrigger("nextScene!");
                }
                else if(currentMode ==3)
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

