using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Xml;
using System;

public class Dialog2 : MonoBehaviour
{

    string[] script;
    string[] now_conv_state;

    public Text textDisplay;
    public DialogData dialogData;
    public DialogEffects dialogEffects;
    public float duration;
    public GameObject continueButton;
    public DialogManager dialogManager;
    public SceneChange SceneChange;
    private int index = 0;

    public ConvStateHandler convStateHandler;
    
    private void Start()
    {
        duration = 1;
        StartCoroutine(_PlayDialogueText(script[index], duration));
        convStateHandler.Effect(now_conv_state[index]);

    }
    void Update()
    {
        
    }

    public void SetScriptloader(string[] ScriptTbl, string[] ConvTbl)
    {
        script = ScriptTbl;
        now_conv_state = ConvTbl;
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
                SceneChange.NextScene();
            }
            Debug.Log(index);
            
            index++;
            convStateHandler.Effect(now_conv_state[index]);
            StartCoroutine(_PlayDialogueText(script[index], duration));
        }
    }
}