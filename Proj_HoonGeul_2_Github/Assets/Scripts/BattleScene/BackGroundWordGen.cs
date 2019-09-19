using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackGroundWordGen : MonoBehaviour
{
    public GameObject wordPref;
    float x;
    float y;
    float width;
    float height;

    // Start is called before the first frame update
    void Start()
    {
        x = this.transform.position.x;
        y = this.transform.position.y;
        width = GetComponent<RectTransform>().rect.width;
        height= GetComponent<RectTransform>().rect.height;
    }
    public void MakeWordRandomPos(string inputWord)
    {
        Vector3 outPos;
        outPos = new Vector3(UnityEngine.Random.Range(x, x + width), UnityEngine.Random.Range(y, y + height), 0);
        /*
        1안. 어차피 여기에 시간 투자 많이해봤자 퀄리티 좋게 나오는게 아니므로 그냥 올랜덤
        2안. width 와 height을 적당한 거리로 랜덤하게 나오게 한다 
        ex) width 를 50으로 나눠서 포지션이 잡히게
        3안. 중복되는 포지션이 없게 List<>를 이용해서 50정도의 길이로 미리 만든다)
        */
        GameObject tempWord=Instantiate(wordPref)as GameObject;
        tempWord.transform.SetParent(this.transform);
        tempWord.transform.localPosition = outPos;
        tempWord.transform.localScale = new Vector3(1,1,1);
        tempWord.GetComponent<Text>().text = inputWord;
        Debug.Log(outPos);
        

    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
