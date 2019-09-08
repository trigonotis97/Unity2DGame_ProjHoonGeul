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
                SceneManager.LoadScene("StartScene");
                break;
            case 1:
                if (sceneData.nextSceneKey % 9 == 0 && sceneData.nextSceneKey < 45)
                {
                    SceneManager.LoadScene("BonusStagePenalty");
                }
                else
                {
                    m_gameManager.SetCurrentDialogKey(sceneData.nextSceneKey);
                    SceneManager.LoadScene("DialogScene");
                }
                break;
            case 2:
                m_gameManager.SetCurrentBattlekey(sceneData.nextSceneKey);
                SceneManager.LoadScene("BattleScene");
                break;
            case 3:
                SceneManager.LoadScene("BonusStageVoca");
                break;
            case 4:
                SceneManager.LoadScene("BonusStageCharacter");
                break;
            case 5:
                SceneManager.LoadScene("BonusStageSpelling");
                break;
            case 6:
                SceneManager.LoadScene("BonusStageSukBong");
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
            SceneManager.LoadScene("DialogScene");
        }
        else
        {
            m_gameManager.SetCurrentSceneKey(m_gameManager.GetCurrentSceneKey());
            sceneData = m_gameManager.GetSceneData();
            m_gameManager.SetCurrentDialogKey(sceneData.nextSceneKey);
            SceneManager.LoadScene("DialogScene");
        }
    }
}

