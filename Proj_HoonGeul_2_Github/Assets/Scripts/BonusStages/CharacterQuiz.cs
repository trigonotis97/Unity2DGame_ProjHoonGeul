using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterQuiz : MonoBehaviour
{
    GameManager m_gameManager;
    public BonusSpellData m_data;

    private void start()
    {
        m_gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }
    public void AnsGenerator()
    {

    }
    public void AnsClick(int BtNum)
    {
        switch (BtNum){
            case 1:
                break;
            case 2:
                break;
            case 3:
                break;
            case 4:
                break;
        }
    }
}
