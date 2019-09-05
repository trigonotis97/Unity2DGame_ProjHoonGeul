using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class tempSceneChange : MonoBehaviour
{
    public void Click()
    {
        SceneManager.LoadScene("StartScene");
    }
}
