using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GooglePlayGames;
using GooglePlayGames.BasicApi;
using UnityEngine.SceneManagement;
using System;

public class GooglePlayManager : MonoBehaviour
{
    bool bWait = false;
    int m_bestScore;
    //public Text debug;

    void Awake()
    {
        PlayGamesPlatform.InitializeInstance(new PlayGamesClientConfiguration.Builder().Build());
        PlayGamesPlatform.DebugLogEnabled = true;
        PlayGamesPlatform.Activate();
        Debug.Log(PlayerPrefs.GetFloat("ggBestScore1"));
        Debug.Log(Convert.ToInt64(PlayerPrefs.GetFloat("ggBestScore1") * 100));
    }
    void Start()
    {
        OnLogin();
        
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
                    //debug.text = "Success : " + Social.localUser.userName;
                }
                else
                {
                    Debug.Log("Fall");
                    //debug.text = "log Fail";
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
        Social.ReportScore(PlayerPrefs.GetInt("RankModeScore",0), GPGSIds.leaderboard, (bool bSuccess) =>
        {
            if (bSuccess)
            {
                Debug.Log("ReportLeaderBoard Success");
                //debug.text = "ReportLeaderBoard Success";
            }
            else
            {
                Debug.Log("ReportLeaderBoard Fall");
                //debug.text = "ReportLeaderBoard Fall";
            }
        }
        );
        Social.ShowLeaderboardUI();
    }

    public void OnShowLeaderBoardGG()
    {
        if (PlayerPrefs.HasKey("ggBestScore0"))
        {
            Social.ReportScore(Convert.ToInt64(PlayerPrefs.GetFloat("ggBestScore0", 90f) * 100), GPGSIds.leaderboard__1, (bool bSuccess) =>
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
        }

        if (PlayerPrefs.HasKey("ggBestScore1"))
        {
            Social.ReportScore(Convert.ToInt64(PlayerPrefs.GetFloat("ggBestScore1",90f) * 100), GPGSIds.leaderboard__2, (bool bSuccess) =>
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
        }

        if (PlayerPrefs.HasKey("ggBestScore2"))
        {
            Social.ReportScore(Convert.ToInt64(PlayerPrefs.GetFloat("ggBestScore2", 90f) * 100), GPGSIds.leaderboard__3, (bool bSuccess) =>
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
        }
        if (PlayerPrefs.HasKey("ggBestScore3"))
        {
            Social.ReportScore(Convert.ToInt64(PlayerPrefs.GetFloat("ggBestScore3", 90f) * 100), GPGSIds.leaderboard__4, (bool bSuccess) =>
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
        }

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
