using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainSceneManager : MonoBehaviour
{
    GameManager m_gameManager;
    public InputField InputText;
    public GameObject Input;
    public GameObject chunjiin_keyboard;

    public SceneData sceneData;
    public MainSceneChange MainSceneChange;
    public Unity_Cunjiin_Keyboard Unity_Cunjiin_Keyboard;

    public GameObject[] mainButtonArray;
    public Animator ButtonsAnimator, doorAnimator;

    private void Awake()
    {
        m_gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }

    public void Start()
    {
        chunjiin_keyboard.SetActive(true);
        Input.SetActive(true);
        foreach (GameObject i in mainButtonArray)
        {
            i.SetActive(false);
        }
    }
    public void onClick() // 메인화면에서 "시작"을 입력하면 넘어가는 함수.
    {
        if (InputText.text == "시작")
        {
            chunjiin_keyboard.SetActive(false);
            Input.SetActive(false);
            foreach (GameObject i in mainButtonArray)
            {
                i.SetActive(true);
            }
            ButtonsAnimator.enabled = true;
        }
        else
        {
            InputText.text = "";
        }
    }
    public void OnClickForGiuk()
    {
        if (InputText.text == "시작")
        {
            onClick();
            Unity_Cunjiin_Keyboard.Enter();
        }
    }


    //씬 전환 애니메이션을 위해 mainSceneChange 스크립트를 만들어서 따로 분리했습니다.
    public void StoryModeClick()
    {
        m_gameManager.SetGameMode(1); //집현전 모드 설정
        //m_gameManager.SetCurrentDialogKey(1);
        m_gameManager.SetCurrentDialogKey(0);
        MainSceneChange.nextScene = "DialogScene";

        doorAnimator.SetTrigger("nextScene!");

        //전에 하던거부터 이어하는 기능이 추가 되야해용!!!! - 성율
    }

    public void LastStoryModeClick()
    {
        MainSceneChange.nextScene = "LastStoryMode";
        doorAnimator.SetTrigger("nextScene!"); // 이 자리에 애니메이션 트리거가 들어가고, 애니메이션 끝에 이벤트로 씬 이동 함수 넣을 예정.
    }
    public void GgamJiModeClick()
    {
        MainSceneChange.nextScene = "GgamJiMode";
        doorAnimator.SetTrigger("nextScene!");
    }
    public void PuzzleModeClick()
    {
        MainSceneChange.nextScene = "PuzzleMode";
        doorAnimator.SetTrigger("nextScene!");
    }
    public void RankModeClick()
    {
        MainSceneChange.nextScene = "RankMode";
        doorAnimator.SetTrigger("nextScene!");
    }


    //public void Difficulty2Click()
    //{
    //    m_gameManager.SetGameMode(2); //세종대왕 모드 설정
    //    m_gameManager.SetCurrentDialogKey(1);
    //    m_gameManager.SetCurrentSceneKey(1);
    //}

    //public void ExitGameClick()
    //{
    //    Application.Quit();
    //}
}
