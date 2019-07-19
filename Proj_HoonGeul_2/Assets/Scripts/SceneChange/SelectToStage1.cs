using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectToStage1 : MonoBehaviour
{
    public void ChangeSelectScene()
    {
        SceneManager.LoadScene("StageSelect");
    }

    public void ChangeStage1Scene()
    {
        SceneManager.LoadScene("Stage1_test");
    }
}
