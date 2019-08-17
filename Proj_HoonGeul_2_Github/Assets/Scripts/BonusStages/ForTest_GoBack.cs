using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ForTest_GoBack : MonoBehaviour
{
    GameManager m_gameManager;
    public SceneData sceneData;
    // Start is called before the first frame update
    void Start()
    {
        m_gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        sceneData = m_gameManager.GetSceneData();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BtnClick()
    {
        m_gameManager.SetCurrentSceneKey(m_gameManager.GetCurrentSceneKey() - 1);
        switch (sceneData.nextScene)
        {
            case 0:
                SceneManager.LoadScene("StartScene", LoadSceneMode.Single);
                break;
            case 1:
                m_gameManager.SetCurrentDialogKey(sceneData.nextSceneKey);
                SceneManager.LoadScene("DialogScene", LoadSceneMode.Single);
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
