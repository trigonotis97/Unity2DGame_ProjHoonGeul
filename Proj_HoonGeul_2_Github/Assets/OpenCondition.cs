using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenCondition : MonoBehaviour
{
    int currentDialogStage;
    public int myOpenCondition;
    public bool isOpened;
    Text conditionText;
    Image btImage;
    Button bt;
    string chapterName;

    void Start()
    {
        currentDialogStage = PlayerPrefs.GetInt("DialogStageIndex", 0);
        conditionText = transform.GetChild(1).GetComponent<Text>();
        btImage = GetComponent<Image>();
        bt = GetComponent<Button>();

        if (myOpenCondition <= currentDialogStage) isOpened = true;
        else isOpened = false;

        if (!isOpened)
        {
            GetComponent<textDownCunji>().enabled = false;

            switch (myOpenCondition)
            {
                case 7:
                    chapterName = "학교";
                    break;
                case 16:
                    chapterName = "일본";
                    break;
                case 25:
                    chapterName = "중국";
                    break;
                case 34:
                    chapterName = "미국";
                    break;
                case 45:
                    chapterName = "조선";
                    break;
                case 10:
                    chapterName = "흥선대원군";
                    break;
                case 19:
                    chapterName = "흥선대원군2";
                    break;
                case 28:
                    chapterName = "신사임당";
                    break;
                case 37:
                    chapterName = "한석봉";
                    break;
            }

            conditionText.text += chapterName + " 정복 완료";
            conditionText.enabled = true;

            btImage.color = new Color(0.55f,0.55f,0.55f);
            //bt.enabled = false; 디버깅용으로 빼놓음

        }
        else
        {
            conditionText.enabled = false;

            btImage.color = new Color(1,1,1);
            bt.enabled = true;
        }
    }

    
}
