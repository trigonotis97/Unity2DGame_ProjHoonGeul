using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RankModeManager : MonoBehaviour
{
    GameManager m_gameManager;
    public int currentScore=0;
    public int show_chapter_num;
    public int show_stage_num;

    StageState m_stageStatus;

    public QuestionGen_RankMode m_questionGen;
    //오디오, 이미지 등등 미리 설정해서 배치하므로 필요없음
    string[] normalQuestionAll_arr;
    string[] hellQuestionAll_arr;

    public GameObject gameOverPanel;
    public GameOverPanel_RankMode gameOverPanel_script;
    public Score score_script;
    int score;


    private void Awake()
    {
        m_gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();

    }
    void Start()
    {
        GetQuestionData();//문제 데이터 초기화

        m_questionGen.SetProblempocket(normalQuestionAll_arr,hellQuestionAll_arr);//normal, hell

        SetStatePlaying();
    }

    // Update is called once per frame


    // 문제 데이터 가져오기
    void GetQuestionData()
    {
        //이미 전체 데이터가 있을경우
        if(m_gameManager.IsAllQuestionDataExist())
        {
            normalQuestionAll_arr=m_gameManager.GetAllQuestionData( out hellQuestionAll_arr);
        }
        //없을경우 새로 만들어줌
        else
        {
            BattleSceneData[] allData= m_gameManager.GetAllBattleData();

            int tempSize = allData.Length;
            //string[,] outQuestion_arr = new string[tempSize, 2];

            List<string> normalQustion_list = new List<string>();
            List<string> hellQustion_list = new List<string>();
            for (int i = 0; i < tempSize; i++)
            {
                for (int j = 0; j < allData[i].problemPocket.Length; j++)
                {
                    normalQustion_list.Add(allData[i].problemPocket[j]);
                }
                for (int j = 0; j < allData[i].hellProblemPocket.Length; j++)
                {
                    hellQustion_list.Add(allData[i].hellProblemPocket[j]);
                }
            }
            normalQuestionAll_arr = normalQustion_list.ToArray();
            hellQuestionAll_arr = hellQustion_list.ToArray();
            m_gameManager.SetAllQuestionData(normalQuestionAll_arr, hellQuestionAll_arr);

        }
    }


    //스테이지 상태 전용 함수
    public StageState GetState()
    {
        return m_stageStatus;
    }
    public void SetStatePlaying()
    {
        m_stageStatus = StageState.PLAYING;

    }

    public void SetStatePause()
    {
        m_stageStatus = StageState.PAUSE;
    }

    public void SetStateGameover()
    {
        m_stageStatus = StageState.GAMEOVER;
        gameOverPanel.SetActive(true);
        gameOverPanel_script.SetScoreText();
        score = score_script.GetScore();

        int currentHighScore = m_gameManager.GetCurrentRankScore();
        if (score > currentHighScore)
            m_gameManager.SetRankScore(score);


    }






}
