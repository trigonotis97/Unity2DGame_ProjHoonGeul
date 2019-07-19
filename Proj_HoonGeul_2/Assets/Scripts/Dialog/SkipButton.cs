using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SkipButton : MonoBehaviour
{
    public GameObject skipButton; //scene skipping button
    public int DeathCount; //Number of Deaths
    public int HardMode; //말 그대로 하드모드
    public string NextScene; //다음 씬을 나타내는 int
    
    public void Start()
    {
        if (HardMode == 1)
        {
            skipButton.SetActive(true); // 만약에 하드모드가 활성화 되어있으면, 시작부터 스킵 버튼 활성화
        }
        else if (HardMode == 0)
        {
            skipButton.SetActive(false); //비활성화 되어있을때 비활성화
        }
        if (DeathCount == 0)
        {
            skipButton.SetActive(false);
        }
        else
        {
            skipButton.SetActive(true);
        }
    }
    public void skipOnClick()
    {
        SceneManager.LoadScene(NextScene,LoadSceneMode.Single);
        Debug.Log("Scene Changed");
        //switch문 생각 해봐야함
        //다음씬으로 전환
    }
}


