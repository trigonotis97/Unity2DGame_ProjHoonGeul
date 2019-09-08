using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainSceneChange : MonoBehaviour
{
    static public string nextScene;

    // Start is called before the first frame update

    public void SceneLoad()
    {
        SceneManager.LoadScene(nextScene);
    }

    //public void StoryLoad()
    //{
    //    SceneManager.LoadScene("DialogScene");
    //}
    //public void LastStroyLoad()
    //{
    //    SceneManager.LoadScene("LastStoryMode");
    //}
    //public void GgamJiLoad()
    //{
    //    SceneManager.LoadScene("GgamJiMode");
    //}
    //public void PuzzleLoad()
    //{
    //    SceneManager.LoadScene("PuzzleMode");
    //}
    //public void RankLoad()
    //{
    //    SceneManager.LoadScene("RankMode");
    //}
}
