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

    public int selectAns;
    string[] answerStr = new string[7] {"안녕하세요",
                                        "니코니코니",
                                        "덩덕쿵덕쿵덕",
                                        "말린망고한봉지",
                                        "고구마전호박전",
                                        "쿵쾅쿵쾅쿵쾅쾅",
                                        "뚜찌빠찌뽀찌"};
    string nowAns;

    public Animator SeokbongCanvasAnimator;

    void Start()
    {
        //m_gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        //sceneData = m_gameManager.GetSceneData();
        AnsGenerator();
        selectAns = 0;
        Debug.Log(answerStr.Length);
    }

    public void AnsGenerator()
    {
        nowAns = answerStr[selectAns];
        question.GetComponent<Text>().text = nowAns;
    }
    
    public void textInputEnter()
    {
        string inputWord = InputText.text;
        if (nowAns == inputWord)
        {
            Debug.Log("정답");
            if (selectAns == answerStr.Length - 1) //마지막 문제면
            {
                Debug.Log("모든 문제를 다 풀었어요.");
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
                }
            } // 마지막 문제면 씬이동
            else //아니면 다음문제
            {
                SeokbongCanvasAnimator.SetTrigger("correct");
                selectAns++;
                AnsGenerator();
            }
        }
        else
        {
            Debug.Log("오답");
            SceneManager.LoadScene("BonusStagePenalty", LoadSceneMode.Single);//깜지 씬으로 이동
        }
        InputText.text = "";
    }
}
