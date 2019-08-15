using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class start : MonoBehaviour
{
    string[] words = {"ㅇㅅ","ㄱㅅ","ㄱㅈ","ㅇㄱ","ㄱㅇ","ㅇㅇ","ㅇㅈ","ㄱㄱ","ㅇㅎ","ㅊㄱ","ㄱㅎ","ㄱㅊ","ㅈㄱ","ㅌㅇ","ㅁㅈ","ㅅㅊ","ㅈㄹ","ㅁㄱ","ㄷㄱ","ㅈㄷ",
        "ㄷㅇ","ㅍㅅ","ㅎㄷ","ㅍㅇ","ㅇㄹ","ㅅㄹ","ㅈㄹ","ㄱㄷ","ㅅㅍ","ㅍㄱ","ㄱㅍ","ㅌㄱ","ㅅㅌ","ㅁㄹ","ㅅㄴ","ㅊㄹ","ㅅㅅ","ㅁㅎ","ㅇㅊ","ㅁㅁ","ㅈㅁ","ㅅㅁ","ㄷㅈ",
        "ㅂㅂ","ㅂㅁ","ㅂㄹ","ㅂㄷ","ㄱㅌ","ㅅㄱ","ㅂㅅ","ㄱㅂ","ㅇㅂ","ㅂㅈ","ㅁㅅ","ㅇㅁ","ㄷㅂ","ㄴㅇ","ㄴㅁ","ㅂㅌ","ㅁㄱ",
"ㄷㅊ","ㅊㅁ","ㅊㅈ","ㅅㄹ","ㅈㅎ","ㄷㄱ","ㅂㅊ","ㅎㅂ","ㄴㅅ","ㅅㅍ","ㅊㅂ","ㄷㅁ",
"ㅊㅅ","ㅂㄱ","ㅎㅊ","ㅁㅊ","ㅌㅈ","ㅊㄷ","ㅊㅊ","ㄷㄷ",
"ㄱㄹ","ㅎㅈ","ㅊㅅ","ㅅㅎ","ㅇㄷ","ㄱㅁ","ㄷㅅ","ㅈㅊ","ㄱㄷ","ㅊㅇ","ㅂㅎ","ㅅㄷ","ㅁㅁ","ㄴㅈ","ㅌㅅ","ㅂㅍ"};

    // Start is called before the first frame update
    void Start()
    {
        for (int i =0; i < words.Length; i++)
        {
            for (int j =i+1; j<words.Length; j++)
            {
                if (words[i] == words[j])
                {
                    Debug.Log(words[j]);
                }
            }
            //Debug.Log("one words end");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
