using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FailScript : MonoBehaviour
{
    GameManager m_gameManager;
    public SceneData sceneData;
    public SceneChange SceneChange;

    void Start()
    {
        m_gameManager.SetCurrentSceneKey(m_gameManager.GetCurrentSceneKey() + 1);
        m_gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        sceneData = m_gameManager.GetSceneData();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Failed(int sceneVal)
    {
        switch (sceneVal)
        {
            case 3:
                break;
            case 4:
                break;
            case 5:
                break;
            case 6:
                break;
        }
    }
}
