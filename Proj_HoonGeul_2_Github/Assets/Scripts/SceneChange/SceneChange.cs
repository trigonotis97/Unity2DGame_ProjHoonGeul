using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    SceneData sceneData;
    DialogData m_data;
    GameManager m_gameManager;

    public Animator animator;
    public MainSceneChange MainSceneChange;

    private void Start()
    {
        m_gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        sceneData = m_gameManager.GetSceneData();
        m_data = m_gameManager.GetDialogData();
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
            case 1:
                if (sceneData.nextSceneKey % 9 == 0 && sceneData.nextSceneKey < 45)
                {
                    MainSceneChange.nextScene="BonusStagePenalty"; animator.SetTrigger("nextScene!");
                }
                else
                {
                    m_gameManager.SetCurrentDialogKey(sceneData.nextSceneKey);
                    MainSceneChange.nextScene="DialogScene"; animator.SetTrigger("nextScene!");
                }
                break;
            case 2:
                m_gameManager.SetCurrentBattlekey(sceneData.nextSceneKey);
                MainSceneChange.nextScene="BattleScene"; animator.SetTrigger("nextScene!");
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
            sceneData = m_gameManager.GetSceneData();
            m_gameManager.SetCurrentDialogKey(sceneData.nextSceneKey);
            MainSceneChange.nextScene="DialogScene"; animator.SetTrigger("nextScene!");
        }
        else
        {
            m_gameManager.SetCurrentSceneKey(m_gameManager.GetCurrentSceneKey());
            sceneData = m_gameManager.GetSceneData();
            m_gameManager.SetCurrentDialogKey(sceneData.nextSceneKey);
            MainSceneChange.nextScene="DialogScene"; animator.SetTrigger("nextScene!");
        }
    }
}

