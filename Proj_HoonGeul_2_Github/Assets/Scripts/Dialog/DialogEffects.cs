using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class DialogEffects : MonoBehaviour
{
    public GameObject back_Korea, back_japan, man_Ka, man_Ja, H_Ka, H_Ja, H_back;
    public void BackGroundMakeUp(int i)
    {
        switch (i+1)
        {
            case 1:
                //전주, 선비맨
                LoadSprites(back_Korea); LoadSprites(man_Ka);
                break;
            case 2:
                //선비 하이라이트
                LoadSprites(H_back); LoadSprites(H_Ka);
                break;
            case 5:
                //다꺼
                HideSprites(back_Korea); HideSprites(man_Ka); HideSprites(H_back); HideSprites(H_Ka);
                break;
            case 6:
                //일본 맵 로드
                LoadSprites(back_japan);
                break;
            case 7:
                //한일맨, 선비 하이라이트
                LoadSprites(man_Ka);LoadSprites(man_Ja);
                LoadSprites(H_back); LoadSprites(H_Ka);
                break;
            case 8:
                //일본 하이라이트
                LoadSprites(H_Ja);
                HideSprites(H_Ka);
                break;
            case 9:
                //선비 하이
                 LoadSprites(H_Ka);
                HideSprites(H_Ja);
                break;
            case 10:
                //일본 하이
                LoadSprites(H_Ja);
                HideSprites(H_Ka);
                break;
            case 11:
                //선비 하이
                 LoadSprites(H_Ka);
                HideSprites(H_Ja);
                break;
            case 12:
                //일본 하이
                LoadSprites(H_Ja);
                HideSprites(H_Ka);
                break;
            case 13:
                //선비하이
                 LoadSprites(H_Ka);
                HideSprites(H_Ja);
                break;
            case 14:
                //일본 하이
                LoadSprites(H_Ja);
                HideSprites(H_Ka);
                break;
            case 15:
                SceneManager.LoadScene("Stage1_test");
                break;
        }
    }
    public void LoadSprites(GameObject go)
    {
        go.GetComponent<SpriteRenderer>().enabled = true;
    }
    public void HideSprites(GameObject go)
    {
        go.GetComponent<SpriteRenderer>().enabled = false;
    }
   
}
