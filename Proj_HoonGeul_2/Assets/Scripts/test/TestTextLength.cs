using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestTextLength : MonoBehaviour
{

    string text = "내용은 간단합니다. 마우스의 좌 우클릭에 따라 선택되는 버튼이 다른 것 뿐이지만, 이것은 딱 '메인 메뉴'가 처음 켜졌을 때만 필요한 것이기 때문에, 더이상 첫 화면이 아닌 메뉴에서 저런 조건을 검사해 봤자 쓸모가 없습니다. 예를 들어 Extra메뉴로 들어가서 더 이상 버튼이 존재하지 않게 되었을 때는 저 구문이 전혀 필요가 없어지죠.";
    Text textDisplay;
    public float waitTime;

    string[] script;
    int[] convv_state;
    int scriptInd;
    // Start is called before the first frame update
    void Start()
    {
        textDisplay = GetComponent<Text>();

        StartCoroutine(_PlayDialogueText(text, waitTime));

        scriptInd = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator _PlayDialogueText(string text, float duration)
    {
        float timer = 0;
        int separator = 0;
        textDisplay.text = "";

        while (timer < duration)
        {
            // Find midpoint in string.
            separator = (int)Mathf.Lerp(0, text.Length, timer / duration);

            // Divide string in 2 and add color at separator.
            string left = text.Substring(0, separator);
            string right = text.Substring(separator, text.Length - separator);
            textDisplay.text = left + "<color=#00000000>" + right + "</color>";

            timer += Time.deltaTime;
            yield return null;
        }

        textDisplay.text = text;
    }
    public void OnClickNextSentence()
    {
        if(scriptInd<script.Length)
        {
            scriptInd++;
            textDisplay.text = "";

        }
        else
        {
            textDisplay.text = "";
            //continueButton.SetActive(false);
            
        }
    }
}
