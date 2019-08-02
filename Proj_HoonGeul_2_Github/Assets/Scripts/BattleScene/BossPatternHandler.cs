using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossPatternHandler : MonoBehaviour
{
    BattleManager m_battleManager;
    // Start is called before the first frame update


    /// 보스패턴관련 변수조정 
    bool isBoss;
    int chapterNum;


    //스크립트 컴포넌트 초기화
    ChosungGeneratorDefault m_generator;
    Judgement m_judgement;
    KeyboardHandler m_keyboardHandler;
    //TextinputHandler m_textinputHandler;


    private void Awake()
    {
        m_battleManager = GameObject.FindGameObjectWithTag("BattleManager").GetComponent<BattleManager>();
        m_generator = GameObject.FindGameObjectWithTag("QuestionControl").GetComponent<ChosungGeneratorDefault>();
        m_judgement = GameObject.FindGameObjectWithTag("QuestionControl").GetComponent<Judgement>();
        m_keyboardHandler = GameObject.FindGameObjectWithTag("KeyboardHandler").GetComponent<KeyboardHandler>();
        //m_textinputHandler = GameObject.FindGameObjectWithTag("TextinputHandler").GetComponent<TextinputHandler>();

    }
    void Start()
    {
        isBoss = m_battleManager.IsBossStage();

        if(isBoss)
        {
            chapterNum = m_battleManager.GetChapterNum();
        }
    }

    void SettingBossPattern(int chapterNum)
    {
        switch(chapterNum)
        {
            case 1:
                Chapter_1_BossPattern();
                break;
            case 2:
                Chapter_2_BossPattern();
                break;
            case 3:
                Chapter_3_BossPattern();
                break;
            case 4:
                Chapter_4_BossPattern();
                break;
            case 5:
                Chapter_5_BossPattern();
                break;
        }
    }
    void Chapter_1_BossPattern()
    {

    }
    void Chapter_2_BossPattern()
    {

    }
    void Chapter_3_BossPattern()
    {

    }
    void Chapter_4_BossPattern()
    {

    }
    void Chapter_5_BossPattern()
    {

    }
   
    
}
