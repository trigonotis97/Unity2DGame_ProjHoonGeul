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
        m_gameManager.SetCurrentSceneKey(m_gameManager.GetCurrentSceneKey());
        sceneData = m_gameManager.GetSceneData();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BtnClick()
    {
        m_gameManager.SetCurrentSceneKey(m_gameManager.GetCurrentSceneKey() - 3);
        sceneData = m_gameManager.GetSceneData();
        Debug.Log(sceneData.nextScene);
        Debug.Log(sceneData.nextSceneKey);
        m_gameManager.SetCurrentBattlekey(sceneData.nextSceneKey);
        SceneManager.LoadScene("BattleScene", LoadSceneMode.Single);
            
        
    }
}
