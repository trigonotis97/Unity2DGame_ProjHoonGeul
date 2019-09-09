using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class KeyboardHandler : MonoBehaviour
{
    BattleManager m_battleManager;


    GameObject[] keyButtonObj;
    Text[] keyText;

    bool is5_3stage;
    // Start is called before the first frame update

    //키보드 날아다니는 세종 패턴
    public bool isSejong = false;
    public GameObject frameColX, frameColY;
    public GameObject[] movingButtons;


    ///
    private InputField inputField;
    public int caretPos = 0;
    public int selectionPos = 0;

    private void Awake()
    {
        if (SceneManager.GetActiveScene().name == "BattleScene")
            m_battleManager = GameObject.FindGameObjectWithTag("BattleManager").GetComponent<BattleManager>();
    }

    void Start()
    {
        //4 스테이지 보스 일 경우 키 버튼을 영어 텍스트로 변경
        if ((SceneManager.GetActiveScene().name != "StartScene") && (m_battleManager.Is2to5BossStage() == 4))
            ChangeKeyboardKortoEng();
        //5-3 스테이지 일 경우 키 버튼 텍스트 지우기.
        else if ((SceneManager.GetActiveScene().name != "StartScene") && (m_battleManager.Is2to5BossStage() == 7))
            DeleteKeyboardText();


        //키보드 날아다니는 세종 패턴
        if (isSejong)
        {
            frameColX.SetActive(true);
            frameColY.SetActive(true);
            for (int i = 0; i < movingButtons.Length; i++)
            {
                movingButtons[i].GetComponent<BoxCollider2D>().enabled = true;
                movingButtons[i].GetComponent<keyButtonColHandler>().enabled = true;
            }
        }
        ///
        inputField = GetComponent<InputField>();
    }

    void ChangeKeyboardKortoEng()
    {
        keyButtonObj = GameObject.FindGameObjectsWithTag("ChunjiinKeyText");
        keyText = new Text[keyButtonObj.Length];
        for (int i = 0; i < keyText.Length; i++)
        {
            keyText[i] = keyButtonObj[i].GetComponent<Text>();
            switch (keyText[i].text)
            {
                case "엔터":
                    break;
                case "띄움":
                    break;
                case "ㅈㅊ":
                    keyText[i].text = "J Ch";
                    break;
                case "ㅅㅎ":
                    keyText[i].text = "S H";
                    break;
                case "ㅂㅍ":
                    keyText[i].text = "B P";
                    break;
                case "ㄷㅌ":
                    keyText[i].text = "D T";
                    break;
                case "ㄴㄹ":
                    keyText[i].text = "N R";
                    break;
                case "ㄱㅋ":
                    keyText[i].text = "G K";
                    break;
                case "ㅡ":
                    break;
                case "ㆍ":
                    break;
                case "ㅣ":
                    break;
                case "ㅇㅁ":
                    keyText[i].text = "O M";
                    break;

            }
        }
    }

    private void Update()
    {
        ///
       /* if (!inputField.isFocused)
        {
            inputField.ActivateInputField();
        }
        if (inputField.caretPosition != caretPos || caretPos != selectionPos)
        {
            inputField.caretPosition = caretPos;
            inputField.selectionAnchorPosition = caretPos;
            inputField.selectionFocusPosition = selectionPos;
            inputField.ForceLabelUpdate();
        }*/

    }

    void DeleteKeyboardText()
    {
        keyButtonObj = GameObject.FindGameObjectsWithTag("ChunjiinKeyText");
        keyText = new Text[keyButtonObj.Length];
        for (int i = 0; i < keyText.Length; i++)
        {
            keyText[i] = keyButtonObj[i].GetComponent<Text>();
            keyText[i].text = "";
        }
    }
}
