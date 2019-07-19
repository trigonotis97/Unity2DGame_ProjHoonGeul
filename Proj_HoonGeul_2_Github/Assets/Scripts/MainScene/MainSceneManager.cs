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
    public GameObject NewGame, ContinueGame, ExitGame;
    public GameObject Difficulty1, Difficulty2, BackButton;
    
    private void Awake()
    {
        m_gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }

    public void Start()
    {
        chunjiin_keyboard.SetActive(true);
        Input.SetActive(true);
        NewGame.SetActive(false);
        ContinueGame.SetActive(false);
        ExitGame.SetActive(false);
        Difficulty1.SetActive(false);
        Difficulty2.SetActive(false);
        BackButton.SetActive(false);
    }
    public void text(Text Test_Text) //디버그용 텍스트. 인게임에서 영향은 없다.
    {
        Test_Text.text = InputText.text;
    }
    public void onClick() // 메인화면에서 "시작"을 입력하면 넘어가는 함수.
    {        
        if (InputText.text == "시작")
        {
            chunjiin_keyboard.SetActive(false);
            Input.SetActive(false);
            NewGame.SetActive(true);
            ContinueGame.SetActive(true);
            ExitGame.SetActive(true);
        }
        InputText.text = "";
    }

    public void NewGameClick()
    {
        NewGame.SetActive(false);
        ContinueGame.SetActive(false);
        ExitGame.SetActive(false);
        Difficulty1.SetActive(true);
        Difficulty2.SetActive(true);
        BackButton.SetActive(true);
    }

    public void ContinueGameClick()
    {
        NewGame.SetActive(true);
        ContinueGame.SetActive(true);
        ExitGame.SetActive(true);
        Difficulty1.SetActive(false);
        Difficulty2.SetActive(false);
        BackButton.SetActive(false);
    }
    public void BackClick()
    {
        Difficulty1.SetActive(false);
        Difficulty2.SetActive(false);
        BackButton.SetActive(false);
        NewGame.SetActive(true);
        ContinueGame.SetActive(true);
        ExitGame.SetActive(true);
    }
    public void Difficulty1Click()
    {
        m_gameManager.SetGameMode(1); //집현전 모드 설정
        SceneManager.LoadScene("DialogScene", LoadSceneMode.Single);
    }

    public void Difficulty2Click()
    {
        m_gameManager.SetGameMode(2); //세종대왕 모드 설정
    }

    public void ExitGameClick()
    {
        Application.Quit();
    }
}
