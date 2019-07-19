using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
// 사전 정보 저장할 때 2차원 배열말고 다른 방법은 없을까..?

public class SkillClassStore
{
    public string[,] skiils = new string[4, 3] // 초성 별로 단어를 배정하기 위해 2차원 배열로 수정.
    { { "고기", "가구", "기계"}, //ㄱㄱ
      { "그늘", "가난", "기능"}, //ㄱㄴ
      { "가득", "계단", "군대"}, //ㄱㄷ
      { "거리", "그릇", "구름"}, //ㄱㄹ
    };

    void Start()
    {
        TextAsset textAsset = (TextAsset)Resources.Load("WordDictionary"); // WordDictionary.xml 파일은 Resources안에 있음. 
        Debug.Log(textAsset);
        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.LoadXml(textAsset.text);

        XmlNodeList nodes = xmlDoc.SelectNodes("WordDic/WordSet"); // 가져올 노드 설정

        foreach (XmlNode node in nodes)
        {
            Debug.Log("Word :: " + node.SelectSingleNode("Word").InnerText); // foreach문을 돌면서 모든 <Word>를 불러옴.
        }
    }
}