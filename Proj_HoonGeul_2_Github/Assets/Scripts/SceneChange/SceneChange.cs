using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    SceneData sceneData;
    GameManager m_gameManager;

    private void Start()
    {
        m_gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        sceneData = m_gameManager.GetSceneData();
    }
    public void NextScene()
    {
        Debug.Log(sceneData.nextScene);
        Debug.Log(sceneData.nextSceneKey);
        switch (sceneData.nextScene)
        {
            case 0:
                SceneManager.LoadScene("StartScene", LoadSceneMode.Single);
                break;
            case 1:
                if (m_gameManager.GetCurrentSceneKey() + 1 < 0)
                {
                    m_gameManager.SetCurrentDialogKey(sceneData.nextSceneKey);
                    SceneManager.LoadScene("DialogScene", LoadSceneMode.Single);
                }
                else
                {
                    m_gameManager.SetCurrentSceneKey(m_gameManager.GetCurrentSceneKey() - 1);
                    m_gameManager.SetCurrentDialogKey(sceneData.nextSceneKey);
                    SceneManager.LoadScene("DialogScene", LoadSceneMode.Single);
                }
                break;
            case 2:
                m_gameManager.SetCurrentBattlekey(sceneData.nextSceneKey);
                SceneManager.LoadScene("BattleScene", LoadSceneMode.Single);
                break;
            case 3:
                SceneManager.LoadScene("BonusStageVoca", LoadSceneMode.Single);
                break;
            case 4:
                SceneManager.LoadScene("BonusStageCharacter", LoadSceneMode.Single);
                break;
            case 5:
                SceneManager.LoadScene("BonusStageSpelling", LoadSceneMode.Single);
                break;
            case 6:
                SceneManager.LoadScene("BonusStageSukBong", LoadSceneMode.Single);
                break;
        }
    }
}

