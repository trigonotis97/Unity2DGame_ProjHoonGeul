using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class VocaQuiz : MonoBehaviour
{
    GameManager m_gameManager;

    public Text question;
    public Text num1;
    public Text num2;
    public Text num3;

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

    public void Ansclick()
    {
        //if (BtNum == correctAns)
        //{
            Debug.Log("정답");
            m_gameManager.SetCurrentSceneKey(m_gameManager.GetCurrentSceneKey() + 1);
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
                //}
                //}
                /*else
                {
                    Debug.Log("오답");
                    //깜지 씬으로 이동*/
        }
    }
}
