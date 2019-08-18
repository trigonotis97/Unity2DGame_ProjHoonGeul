using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CharacterQuiz : MonoBehaviour
{
    GameManager m_gameManager;

    public Text question;
    public Text num1;
    public Text num2;
    public Text num3;

    public SceneData sceneData;
    public SceneChange SceneChange;

    int selectAns = 0;
    int correctAns;
    //int[] problemOrderTbl = new int[9];

    string[,] answerStr = new string[9, 4] {{ "장영실", "전자시계", "물시계", "해시계" },
                                            { "이순신", "영의정", "학익진", "백의종군" },
                                            { "궁예", "고려", "관심법", "미륵" },
                                            { "문익점", "무역상", "붓", "목화씨" },
                                            { "원효", "고려", "해골물", "의상대사" },
                                            { "장희빈", "서인", "숙종", "희빈 장씨" },
                                            { "최무선", "고구려", "화통도감", "화약" },
                                            { "세종", "이산", "편경", "집현전"},
                                            { "논개", "한산대첩", "가락지", "임진왜란" } };
    string[] nowAnsStr = new string[4];

    private void Start()
    {
        m_gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        sceneData = m_gameManager.GetSceneData();
        AnsGenerator();
    }

    public void AnsGenerator()
    {
        /*selectAns = Random.Range(0, 9);     //문제 번호 랜덤
        for (int i = 0; i < 9; i++)
        {
            if (problemOrderTbl[i] == selectAns)
                AnsGenerator();
                break;
        }
        problemOrderTbl[selectAns] = selectAns;
        problemNum++;*/
        Debug.Log("현재 문항 번호: " + selectAns);
        correctAns = Random.Range(1, 4);    //정답 문항 랜덤
        for(int i = 0; i<4; i++)
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
        num3.GetComponent<Text>().text = nowAnsStr[3];
    }
    public void Ansclick(int BtNum)
    {
        if (BtNum == correctAns)
        {
            Debug.Log("정답");
            if (selectAns < 8)
            {
                selectAns++;
                AnsGenerator();
            }
            else
            {
                SceneChange.NextScene();
            }
        }
        else
        {
            Debug.Log("오답");
            SceneChange.NextScene();
        }
    }
}
