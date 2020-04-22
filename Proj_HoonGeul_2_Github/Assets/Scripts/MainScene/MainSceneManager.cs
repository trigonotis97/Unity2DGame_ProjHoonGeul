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
    public Animator ButtonsAnimator;

    //연습모드를 위한 변수
    bool isPracticeMode = false;


    private void Awake()
    {
        m_gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }

    public void Start()
    {
        bool param = m_gameManager.GetisFirstStart();

        chunjiin_keyboard.SetActive(param);
        Input.SetActive(param);
        foreach (GameObject i in mainButtonArray)
        {
            i.SetActive(!param);
        }
    }
    
    public void OnClickForGiuk()
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

            m_gameManager.SetisFirstStart();
            InputText.text = "";
        }

    }





    //씬 전환 애니메이션을 위해 mainSceneChange 스크립트를 만들어서 따로 분리했습니다.
    //public void StoryModeClick()
    //{
    //    m_gameManager.SetGameMode(1); //집현전 모드 설정
    //    //m_gameManager.SetCurrentDialogKey(1);
    //    m_gameManager.SetCurrentDialogKey(0);
    //    MainSceneChange.nextScene = "DialogScene";

    //    doorAnimator.SetTrigger("nextScene!");

    //    //전에 하던거부터 이어하는 기능이 추가 되야해용!!!! - 성율
    //}



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
