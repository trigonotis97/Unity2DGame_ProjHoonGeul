using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainSceneChange : MonoBehaviour
{
    GameManager m_gameManager;

    static public string nextScene;
    public Animator doorAnimator;
    
    private void Awake()
    {
        if(GameObject.FindGameObjectWithTag("GameManager") != null) { 
        m_gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        }
    }

    public void SceneLoad() // 타임라인에서 쓰는 함수
    {
        SceneManager.LoadScene(nextScene);
    }

    public void SetSceneName(string i) //버튼에 씬 이름을 직접 넣어서 이동할 때 쓰는 함수.
    {
        nextScene = i;
        doorAnimator.SetTrigger("nextScene!");
    }

    public void StoryModeClick()
    {
        //m_gameManager.SetGameMode(1); //집현전 모드 설정
        //m_gameManager.SetCurrentDialogKey(1);
        
        nextScene = "DialogScene";
        doorAnimator.SetTrigger("nextScene!");

        //전에 하던거부터 이어하는 기능이 추가 되야해용!!!! - 성율
    }
}
