using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Words : MonoBehaviour
{
    public float duration;
    public Text textDisplay;
    public string[] sentences;
    private int index;
    public float typingSpeed;
    public GameObject continueButton;
    public DialogEffects dialogEffects;
    
    private void Start()
    {
        StartCoroutine(Type());
        dialogEffects = this.GetComponent<DialogEffects>();
        duration = 2;
     }
    void Update ()
    {
        if(textDisplay.text == sentences[index])
        {
            continueButton.SetActive(true);
        }
    }
    
    IEnumerator Type()
    {
        foreach (char letter in sentences[index].ToCharArray())
        {

            Debug.Log(index);
            textDisplay.text += letter;
            Debug.Log(textDisplay.text);
            yield return new WaitForSeconds(typingSpeed);
        } 
    }
    public void NextSentence()
    {
        dialogEffects.BackGroundMakeUp(index);
        continueButton.SetActive(false);

        if(index < sentences.Length - 1)
        {
            Debug.Log(index);
            index++;
            textDisplay.text = "";
            StartCoroutine(Type());
        } else
        {
            textDisplay.text = "";
            continueButton.SetActive(false);
        }
        
    }

    //StartCoroutine("_PlayDialogueText",str,duation);
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
    
}
