using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Xml;
using System;

public class Dialog2 : MonoBehaviour
{

    string[] script;
    int[] conv_state;

    public Text textDisplay;
    public DialogData dialogData;
    public DialogEffects dialogEffects;
    public float duration;
    public GameObject continueButton;
    public DialogManager dialogManager;
    private int index = 0;
    

    private void Start()
    {
        duration = 1;
        StartCoroutine(_PlayDialogueText(script[index], duration));
        SetState(conv_state[index]);
    }
    void Update()
    {
        
    }

    public void SetScriptloader(string[] ScriptTbl, int[] ConvTbl)
    {
        script = ScriptTbl;
        conv_state = ConvTbl;
    }

    public void SetState(int nowState)
    {
        switch (nowState)
        {
            case 0:

                break;
            case 2:
                break;
        }
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
        if (textDisplay.text != script[index])
        {
            Debug.Log("STOP");
            StopAllCoroutines();
            textDisplay.text = script[index];
        }
        else
        {
            if (index + 1 == script.Length)
            {
                dialogManager.NextScene();
            }
            index++;
            StartCoroutine(_PlayDialogueText(script[index], duration));
        }
    }
}