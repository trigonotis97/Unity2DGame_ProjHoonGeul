using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleSceneChange : MonoBehaviour
{
    public void ChangeMainScene()
    {
        SceneManager.LoadScene("Title");
    }

    public void ChangeSelectScene()
    {
        SceneManager.LoadScene("Cutscene 2");
    }
}
    