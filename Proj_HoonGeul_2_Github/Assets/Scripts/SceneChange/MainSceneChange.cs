using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainSceneChange : MonoBehaviour
{
    GameManager m_gameManager;

    public SceneChange SceneChange;
    static public string nextScene;
    public Animator doorAnimator;
    
    private void Awake()
    {
        if(GameObject.FindGameObjectWithTag("GameManager") != null) { 
        m_gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        }
    }

    public void SceneLoad()
    {
        SceneManager.LoadScene(nextScene);
    }

    public void SetSceneName(string i)
    {
        nextScene = i;
        doorAnimator.SetTrigger("nextScene!");
    }

    public void StoryModeClick()
    {
        m_gameManager.SetGameMode(1); //집현전 모드 설정
        //m_gameManager.SetCurrentDialogKey(1);
        m_gameManager.SetCurrentDialogKey(0);
        ////위의 숫자들을 매개변수로 받아와서 넣는 코드로 변경 작업 필요.
        ////연습모드, 이어하기 등에서 사용하기 위함.
        ////일단 지금은 무조건 첫번째

        nextScene = "DialogScene";
        doorAnimator.SetTrigger("nextScene!");

        //전에 하던거부터 이어하는 기능이 추가 되야해용!!!! - 성율
    }

    public void NextSceneTrigger()
    {

    }
}
