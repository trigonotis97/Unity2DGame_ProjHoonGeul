using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Test_BattleScenePortal : MonoBehaviour
{
    GameManager m_gameManager;
    public InputField inputField;
    
    // Start is called before the first frame update
    private void Awake()
    {
        m_gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }

    public void JumpToBattleScene()
    {
        string inputText = inputField.text;
        int chapterNum = int.Parse(inputText[0].ToString());
        int stageNum = int.Parse(inputText[2].ToString());
        m_gameManager.SetCurrentBattlekey((chapterNum - 1) * 3 + stageNum-1);
        /*
        get battle data-> xml 데이터의 키값이 아닌 인덱스로 접근한다.
        key는 1부터 시작하고 index 는 0부터시작하므로 그 차이를 -1 해준다.
        */
        SceneManager.LoadScene("BattleScene", LoadSceneMode.Single);

    }
}
