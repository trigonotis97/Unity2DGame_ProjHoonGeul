using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class VocaQuiz : MonoBehaviour
{
    public AudioClip o, x;
    public AudioSource audio;
    GameManager m_gameManager;
    

    public Text question;
    public Text num1;
    public Text num2;

    public SceneData sceneData;
    public SceneChange SceneChange;

    int selectAns = 0;
    int correctAns;
    string[,] answerStr = new string[6, 3] { { "일깨워서 알게 하다", "가르치다", "가리키다"},
                                             { "(잘못 치닫거나 기우는 형세 따위를) 붙들어 바로잡다.", "걷잡다", "겉잡다" },
                                             { "앞의 내용이 뒤에 오는 내용의 원인·전제·조건이 됨을 나타내는 접속 부사", "그러므로", "그럼으로"},
                                             { "문이나 창 따위를 힘주어 닫다", "닫치다","닫히다" },
                                             { "결정할 권한이 있는 자가 부하 직원이 제출한 안건을 허가하거나 승인하는 것","결재", "결제" },
                                             { "아이를 밴 여자", "임신부", "임산부"  } };
    string[] nowAnsStr = new string[3];

    private void Start()
    {
        m_gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        m_gameManager.SetCurrentSceneKey(m_gameManager.GetCurrentSceneKey() + 1);
        AnsGenerator();
        sceneData = m_gameManager.GetSceneIndData(m_gameManager.GetGameMode());
    }

    public void AnsGenerator()
    {
        correctAns = Random.Range(1, 3);    //정답 문항 랜덤
        for (int i = 0; i < 3; i++)
        {
            nowAnsStr[i] = answerStr[selectAns, i]; //중간 매개 배열
        }
        // 정답 문항으로 각 문제[1] 을 이동시키기 위한 코드.
        string temp = nowAnsStr[correctAns];
        nowAnsStr[correctAns] = nowAnsStr[1];
        nowAnsStr[1] = temp;
        Debug.Log(nowAnsStr[correctAns]);
        Debug.Log(correctAns);


        //텍스트로 문자열 출력
        question.GetComponent<Text>().text = nowAnsStr[0];
        num1.GetComponent<Text>().text = nowAnsStr[1];
        num2.GetComponent<Text>().text = nowAnsStr[2];
    }
    public void Ansclick(int BtNum)
    {
        if (BtNum == correctAns)
        {
            audio.clip = o;
            audio.PlayOneShot(o);
            Debug.Log("정답");
            if (selectAns < 5)
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
            audio.clip = x;
            audio.PlayOneShot(x);
            Debug.Log("오답");
            SceneChange.BonusNextScene(false);
        }
    }
}
