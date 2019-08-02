using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterQuiz : MonoBehaviour
{
    GameManager m_gameManager;
    public BonusSpellData m_data;

    int selectAns;
    int correctAns;
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

    private void start()
    {
        m_gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }
    public void AnsGenerator()
    {
        selectAns = Random.Range(0, 9);
        correctAns = Random.Range(1, 4); 

    }
    public void AnsClick(int BtNum)
    {
        if (BtNum == correctAns)
        {

        }
        else
        {

        }
    }
}
