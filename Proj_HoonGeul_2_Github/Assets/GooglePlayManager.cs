using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GooglePlayGames;
using GooglePlayGames.BasicApi;
using UnityEngine.SceneManagement;

public class GooglePlayManager : MonoBehaviour
{

    bool bWait = false;
    int m_bestScore;

    void Awake()
    {
        PlayGamesPlatform.InitializeInstance(new PlayGamesClientConfiguration.Builder().Build());
        PlayGamesPlatform.DebugLogEnabled = true;
        PlayGamesPlatform.Activate();
    }
    void Start()
    {
        OnLogin();
        m_bestScore = PlayerPrefs.GetInt("PuzzleBestScore", 0);
        if (SceneManager.GetActiveScene().name == "PuzzleMode")
        {
            if (m_bestScore == 100)
            {
                OnAddAchievement100();
                OnAddAchievement75();
                OnAddAchievement50();
                OnAddAchievement25();
            }
            else if (m_bestScore >= 75)
            {
                OnAddAchievement75();
                OnAddAchievement50();
                OnAddAchievement25();
            }
            else if (m_bestScore >= 50)
            {
                OnAddAchievement50();
                OnAddAchievement25();
            }
            else if (m_bestScore >= 25)
            {
                OnAddAchievement25();
            }
        }

    }


    public void OnLogin()
    {
        if (!Social.localUser.authenticated)
        {
            Social.localUser.Authenticate((bool bSuccess) =>
            {
                if (bSuccess)
                {
                    Debug.Log("Success : " + Social.localUser.userName);
                }
                else
                {
                    Debug.Log("Fall");
                }
            });
        }
    }

    public void OnLogOut()
    {
        ((PlayGamesPlatform)Social.Active).SignOut();
    }

    public void OnShowLeaderBoard()
    {
        // 1000점을 등록
        Social.ReportScore(PlayerPrefs.GetInt("RankModeScore",0), GPGSIds.leaderboard, (bool bSuccess) =>
        {
            if (bSuccess)
            {
                Debug.Log("ReportLeaderBoard Success");

            }
            else
            {
                Debug.Log("ReportLeaderBoard Fall");

            }
        }
        );
        Social.ShowLeaderboardUI();
    }

    // 업적보기
    public void OnShowAchievement()
    {
        Social.ShowAchievementsUI();
    }

    // 업적추가
    public void OnAddAchievement25()
    {
        Social.ReportProgress(GPGSIds.achievement_9, 100.0f, (bool bSuccess) =>
        {
            if (bSuccess)
            {
                Debug.Log("AddAchievement Success");

            }
            else
            {
                Debug.Log("AddAchievement Fall");

            }
        }
        );
    }
    public void OnAddAchievement50()
    {


        Social.ReportProgress(GPGSIds.achievement_8, 100.0f, (bool bSuccess) =>
        {
            if (bSuccess)
            {
                Debug.Log("AddAchievement Success");

            }
            else
            {
                Debug.Log("AddAchievement Fall");

            }
        }
        );
    }
    public void OnAddAchievement75()
    {


        Social.ReportProgress(GPGSIds.achievement_7, 100.0f, (bool bSuccess) =>
        {
            if (bSuccess)
            {
                Debug.Log("AddAchievement Success");

            }
            else
            {
                Debug.Log("AddAchievement Fall");

            }
        }
        );
    }
    public void OnAddAchievement100()
    {


        Social.ReportProgress(GPGSIds.achievement, 100.0f, (bool bSuccess) =>
        {
            if (bSuccess)
            {
                Debug.Log("AddAchievement Success");

            }
            else
            {
                Debug.Log("AddAchievement Fall");

            }
        }
        );
    }
}
