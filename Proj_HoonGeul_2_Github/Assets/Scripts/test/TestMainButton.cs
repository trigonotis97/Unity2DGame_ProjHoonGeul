using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TestMainButton : MonoBehaviour
{
    GameManager gameManager;

    DialogData m_data;
    BattleSceneData m_battledata;

    private void Awake()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }
    

    public void NextBattleScene()
    {
        //gameManager.
        SceneManager.LoadScene("BattleScene", LoadSceneMode.Single);
    }
    public void StartBattleScene()
    {
        SceneManager.LoadScene("BattleScene", LoadSceneMode.Single);
        Debug.Log("BattleScene");
    }
    public void StartDialogScene()
    {
        SceneManager.LoadScene("DialogScene", LoadSceneMode.Single);
    }
    public void NextDialogScene()
    {
        SceneManager.LoadScene("DialogScene", LoadSceneMode.Single);
    }


    ///////////////////////////////////////////////
    public void MainScene()
    {
        gameManager.SetCurrentBattlekey(0);
        gameManager.SetCurrentDialogKey(0);
        SceneManager.LoadScene("StartScene", LoadSceneMode.Single);

    }
    public void PriviousDialogScene()
    {
        gameManager.SetCurrentDialogKey(gameManager.GetCurrentDialogKey() - 1);
        if (m_data.isNextBattle == true)
        {
            gameManager.SetCurrentBattlekey(gameManager.GetCurrentDialogKey() - 1);
            SceneManager.LoadScene("BattleScene", LoadSceneMode.Single);
        }
        else
        {
            SceneManager.LoadScene("DialogScene", LoadSceneMode.Single);
        }
    }
    public void PriviousBattleScene()
    {
        gameManager.SetCurrentDialogKey(gameManager.GetCurrentDialogKey() - 1);
        SceneManager.LoadScene("DialogScene", LoadSceneMode.Single);
    }

}
