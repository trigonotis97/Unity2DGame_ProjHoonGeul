using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SukBong : MonoBehaviour
{
    GameManager m_gameManager;

    public Text question;
    public InputField InputText;

    public SceneData sceneData;
    public SceneChange SceneChange;

    int selectAns;
    string[] answerStr = new string[7] {"안녕하세요",
                                        "니코니코니",
                                        "덩덕쿵덕쿵덕",
                                        "말린망고한봉지",
                                        "고구마전호박전",
                                        "쿵쾅쿵쾅쿵쾅쾅",
                                        "뚜찌빠찌뽀찌"};
    string nowAns;

    void Start()
    {
        m_gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        m_gameManager.SetCurrentSceneKey(m_gameManager.GetCurrentSceneKey() + 1);
        sceneData = m_gameManager.GetSceneData();
        AnsGenerator();
    }

    public void AnsGenerator()
    {
        selectAns = Random.Range(0, 7);
        nowAns = answerStr[selectAns];

        question.GetComponent<Text>().text = nowAns;
    }
    
    public void textInputEnter()
    {
        string inputWord = InputText.text;
        if (nowAns == inputWord)
        {
            Debug.Log("정답");
            if (selectAns < 6)
            {
                selectAns++;
                AnsGenerator();
            }
            else
            {
                Debug.Log("클리어");
                SceneChange.BonusNextScene(true);
            }
        }
        else
        {
            Debug.Log("오답");
            SceneChange.BonusNextScene(false);
        }
        InputText.text = "";
    }
    
}
