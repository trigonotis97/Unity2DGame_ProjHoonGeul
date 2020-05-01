using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[System.Serializable]
public class tutoImageArray
{
    public Sprite[] tutoImages = new Sprite[4];
}
public class tutoPanel : MonoBehaviour
{
    public tutoImageArray[] tutoImageResources = new tutoImageArray[5];
    public Animator StartAnimator;
    public BattleManager m_battleManager;
    public Image tutoImage;
  
    // Start is called before the first frame update
    void Start()
    {
        m_battleManager = GameObject.FindWithTag("BattleManager").GetComponent<BattleManager>();
        int chapNum = m_battleManager.show_chapter_num;
        int stageNum = m_battleManager.show_stage_num;

        if((chapNum ==2 || chapNum ==3) && (stageNum==2 || stageNum == 3))
        {
            CloseOnClick();
        }
        else if (chapNum == 4 && stageNum == 2)
        {
            CloseOnClick();
        }
        else
        {
            tutoImage.sprite = tutoImageResources[chapNum - 1].tutoImages[stageNum-1];
            gameObject.GetComponent<Canvas>().enabled = true;
        }
           

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void CloseOnClick()
    {
        StartAnimator.SetTrigger("tutoOff");
        gameObject.SetActive(false);
    }
}
