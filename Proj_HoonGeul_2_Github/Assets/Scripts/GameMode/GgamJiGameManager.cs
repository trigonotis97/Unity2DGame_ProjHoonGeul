using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GgamJiGameManager : MonoBehaviour
{
    GameManager m_gameManager;
    //public Text problem;
    public InputField InputText;
    public Text[] texts;
    int nowLine;
    public Text answerSpace;

    public SceneData sceneData;
    public AudioSource AudioSource;
    public AudioClip correct, incorrect;

    public MainSceneChange MainSceneChange;

    int questionNum;

    float time,sec, min;
    string secString, minString;
    public Text timer;
    public enum GgState
    {
        PAUSE,
        PLAYING
    }
    public GgState m_GgState;

    public string[,] answerStr = new string[4, 4]
    {
        {"동해물과 백두산이 마르고 닳도록",
        "하느님이 보우하사 우리나라 만세",
        "무궁화 삼천리 화려강산",
        "대한 사람 대한으로 길이 보전하세"},
        {"남산 위에 저 소나무 철갑을 두른 듯",
        "바람서리 불변함은 우리 기상일세",
        "무궁화 삼천리 화려강산",
        "대한 사람 대한으로 길이 보전하세"},
        {"가을 하늘 공활한데 높고 구름 없이",
        "밝은 달은 우리 가슴 일편단심일세",
        "무궁화 삼천리 화려강산",
        "대한 사람 대한으로 길이 보전하세"},
        {"이 기상과 이 맘으로 충성을 다하여",
        "괴로우나 즐거우나 나라 사랑하세",
        "무궁화 삼천리 화려강산",
        "대한 사람 대한으로 길이 보전하세"}
    };

    void Start()
    {
        if (GameObject.FindGameObjectWithTag("GameManager") != null)
        {
            m_gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
            sceneData = m_gameManager.GetSceneIndData(m_gameManager.GetGameMode());
        }

        nowLine = 0;

        questionNum =m_gameManager.GetGgamJiStageNum();
        Debug.Log(questionNum);
        answerSpace.text = "";
        for (int i = 0; i < 4; i++)
        {
            answerSpace.text += answerStr[questionNum, i] + "\n";
            
        }

        time = 90f;
        m_GgState = GgState.PAUSE;
    }

    void Update()
    {
        if (m_GgState == GgState.PLAYING)
        {
            time -= Time.deltaTime;
            
            //if (min < 10)
            //{
            //    minString = "0" + Mathf.Floor(min).ToString();
            //}

            if (time > 0)
            {
                min = time / 60;
                sec = time % 60;

                if (sec < 10)
                {
                    secString = "0";
                }
                else
                {
                    secString = "";
                }
                timer.text = "0" + Mathf.Floor(min) + ":" + secString + Mathf.Floor(sec).ToString();
            }       
            else
            {
                m_GgState = GgState.PAUSE;
                GameOver();
            }
        }
    }

    public void Check()
    {
        if (InputText.text == answerStr[questionNum,nowLine])
        {
            //정답 사운드
            AudioSource.clip = correct;
            AudioSource.PlayOneShot(correct);
            nowLine += 1;
            if (nowLine == 4)
            {
                m_GgState = GgState.PAUSE;
                GameClear();
                
            }
            else
            {   
            InputText.textComponent = texts[nowLine];
            InputText.text = "";
            Debug.Log("일치!");
            }

        }
        else
        {
            //오답 사운드
            AudioSource.clip = incorrect;
            AudioSource.PlayOneShot(incorrect);
            InputText.text = "";
            Debug.Log("틀렸어요");
            Debug.Log(questionNum);
            Debug.Log(answerStr[questionNum, nowLine]);
        }
    }

    public void SetState(string state)
    {
        if (state == "PAUSE") m_GgState = GgState.PAUSE;
        if (state == "PLAYING") m_GgState = GgState.PLAYING;
    }

    public void GameOver()
    {
        timer.text = "00:00";
        // 게임끗 애니 (씬이동 포함) 트리거 ㄱㄱ
        Debug.Log("gameOver");
    }
    public void GameClear()
    {
        //time 값을 내 현재 스코어 보여주는 창에 넣는다
        if (!PlayerPrefs.HasKey("ggBestScore" + questionNum.ToString()) ||
            m_gameManager.GetFloatPlayerPrefs("ggBestScore" + questionNum.ToString()) < time) //최고기록이면!
        {
            m_gameManager.SetFloatPlayerPrefs("ggBestScore" + questionNum.ToString(), time); //최고기록에 저장            
            Debug.Log("최고기록갱신! :" + m_gameManager.GetFloatPlayerPrefs("ggBestScore" + questionNum.ToString())); 
        }
        else //최고기록이 아니면
        {
            Debug.Log("클리어했지만 최고기록은 아니네요.\n현재기록:"+time.ToString()+"\n최고기록:"+m_gameManager.GetFloatPlayerPrefs("ggBestScore" + questionNum.ToString()));
        }
        
        //성공!, 내 현재 기록 (소요시간), 갱신했니? 보여주는 애니메이션 트리거. (씬 이동까지 함께)

    }
    //public void AdButton()
    //{
    //    //광고 재생 후 다음 씬으로
    //    m_gameManager.SetCurrentSceneKey(m_gameManager.GetCurrentSceneKey() - 2);
    //    sceneData = m_gameManager.GetSceneIndData();
    //    switch (sceneData.nextScene)
    //    {
    //        case 3:
    //           MainSceneChange.SetSceneName("BonusStageVoca");
    //            break;
    //        case 4:
    //           MainSceneChange.SetSceneName("BonusStageCharacter");
    //            break;
    //        case 5:
    //           MainSceneChange.SetSceneName("BonusStageSpelling");
    //            break;
    //        case 6:
    //           MainSceneChange.SetSceneName("BonusStageSukBong");
    //            break;
    //    }
    //}
    //public void AnsGenerator()
    //{
    //    selectAns = Random.Range(0, 2);
    //    for (int i = 0; i < 8; i++)
    //    {
    //        nowAnsStr[i] = answerStr[selectAns, i]; //중간 매개 배열
    //    }

    //    //problem.GetComponent<Text>().text = nowAns;
    //}

    /*public void textInputEnter()
    {
        string inputWord = InputText.text;
        if (nowAns == inputWord)
        {
            Debug.Log("정답");
            m_gameManager.SetCurrentSceneKey(m_gameManager.GetCurrentSceneKey() + 1);
            switch (sceneData.nextScene)
            {
                case 0:
                   MainSceneChange.SetSceneName("StartScene");
                    break;
                case 1:
                    m_gameManager.SetCurrentDialogKey(sceneData.nextSceneKey);
                   MainSceneChange.SetSceneName("DialogScene");
                    break;
                case 2:
                    m_gameManager.SetCurrentBattlekey(sceneData.nextSceneKey);
                   MainSceneChange.SetSceneName("BattleScene");
                    break;
                case 3:
                   MainSceneChange.SetSceneName("BonusStageVoca");
                    break;
                case 4:
                   MainSceneChange.SetSceneName("BonusStageCharacter");
                    break;
                case 5:
                   MainSceneChange.SetSceneName("BonusStageSpelling");
                    break;
                case 6:
                   MainSceneChange.SetSceneName("BonusStageSukBong");
                    break;
            }
        }
        else
        {
            Debug.Log("오답");
            //깜지 씬으로 이동
        }
        InputText.text = "";
    }
    */
}
