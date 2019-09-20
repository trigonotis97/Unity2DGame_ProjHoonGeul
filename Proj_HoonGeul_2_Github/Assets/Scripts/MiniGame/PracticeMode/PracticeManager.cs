using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
    오브젝트를 하나 생성하고 이 오브젝트가 존재할경우
    일반 스토리가 아니라 연습모드로 진행하게끔 한다.
*/
public class PracticeManager : MonoBehaviour
{
    int dialogIndex;
    int battleIndex;

    //bool isDialogScene;
    bool isWin = false;
    // Start is called before the first frame update
    
    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    //데이터 초기화
    public void SetDialogIndex(int inputKey)
    {
        dialogIndex = inputKey;
    }
    public void SetBattleIndex(int inputKey)
    {
        battleIndex = inputKey;
    }

    //연습모드 종료시 삭제
    public void DistoyManager()
    {
        Destroy(gameObject);
    }
    public bool GetWinState()
    {
        return isWin;
    }

    public void ChangeDialogKey_forNextScene()
    {
        dialogIndex++;
    }


    public int GetDialogIndex()
    {
        return dialogIndex;
    }
    public int GetBattleIndex()
    {
        return battleIndex;
    }
}
