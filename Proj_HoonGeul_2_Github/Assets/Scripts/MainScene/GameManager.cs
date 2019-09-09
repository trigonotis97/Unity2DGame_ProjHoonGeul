using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//FF608B4E
///FFFFA200 (서영이 주황색FFB69253,
///FF4AB3CB (하늘색
///->xml 문서주석 구분기호, 텍스트->xml문서 주석 텍스트
public class GameManager : MonoBehaviour {

    public static GameManager gameManager = null;              //Static instance of GameManager which allows it to be accessed by any other script.


    private Dictionary<string, string>[] dictionary_Tbl; //사전 데이터 테이블
    private BattleSceneData[] battleData_Tbl; //배틀씬 데이터 테이블
    private DialogData[] dialogData_Tbl; //다이얼로그 데이터 테이블
    private SceneData[] sceneData_Tbl;

    private int currentBattleStageIdx;
    private int currentDialogIdx;
    private int currentSceneDataIdx;
    private int currentMode; // 1: 집현전모드(노멀)  2: 세종대왕모드 (하드)

    private Dictionary<string, Dictionary<string, string>> chosungValHint_Tbl = new Dictionary<string, Dictionary<string, string>>();
    private Dictionary<string, string[]> chosungWrongHintTable = new Dictionary<string, string[]>();

    private bool isFirstStart = true;

    void Awake()
    {
        //Check if instance already exists
        if (gameManager == null)
        {
            //if not, set instance to this
            gameManager = this;
        }
        //If instance already exists and it's not this:
        else if (gameManager != this)
        {
            //Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
            Destroy(gameObject);
        }

        //Sets this to not be destroyed when reloading scene
        DontDestroyOnLoad(gameObject);

        PlayerPrefs.SetInt("BattleStageIndex", 0);
        PlayerPrefs.SetInt("DialogStageIndex", 0);
        PlayerPrefs.SetInt("SceneIndex", 0);

        ///저장된 체크포인트 가져오기 (체크포인트 초기화)
        currentBattleStageIdx = PlayerPrefs.GetInt("BattleStageIndex", 0);
        /*

        */
        currentDialogIdx = PlayerPrefs.GetInt("DialogStageIndex", 0);
        currentSceneDataIdx = PlayerPrefs.GetInt("SceneIndex", 0);

        Debug.Log("battle ind: " + currentBattleStageIdx);
        Debug.Log("dialog ind: " + currentDialogIdx);
        Debug.Log("scene ind: " + currentSceneDataIdx);


    }

    //체크포인트를 저장할 곳에서 호출. 주로 battle scene manager.
    public void SaveCheckPoint()
    {
        PlayerPrefs.SetInt("BattleStageIndex", currentBattleStageIdx);
        PlayerPrefs.SetInt("DialogStageIndex", currentDialogIdx);
        PlayerPrefs.SetInt("SceneIndex", currentSceneDataIdx);
    }

  
    
    /// 데이터 초기화

    //xml load 씬에서 호출. game manager 의 데이터를 초기화해준다
    public void SetXmlDictData(Dictionary<string,string> []inputDict)
    {
        dictionary_Tbl = inputDict;
    }
    public Dictionary<string,string>[] GetXmlDictData()
    {
        return dictionary_Tbl;
    }
    public void SetXmlBattleSceneData(BattleSceneData []inputData)
    {
        battleData_Tbl = inputData;
    }
    public void SetXmlDialogData(DialogData []inputData)
    {
        dialogData_Tbl = inputData;
    }
    public void SetXmlSceneData(SceneData []inputData)
    {
        sceneData_Tbl = inputData;
    }

    

    //battle scene manager 에서 호출. battle scene 에 필요한 데이터를 가져간다.
    public BattleSceneData GetBattleSceneData()
    {
        return battleData_Tbl[currentBattleStageIdx];//class 라도 public으로 만들어진 form이 아니면 접근이 안된다...
    }
    public DialogData GetDialogData()
    {
        return dialogData_Tbl[currentDialogIdx];
    }
    public SceneData GetSceneData()
    {
        return sceneData_Tbl[currentSceneDataIdx];
    }

    ///씬 이동 관련 변수
    public int GetCurrentDialogKey()
    {
        return currentDialogIdx;
    }
    public int GetCurrentBattleKey()
    {
        return currentBattleStageIdx;
    }
    public int GetCurrentSceneKey()
    {
        return currentSceneDataIdx;
    }

    public void SetCurrentDialogKey(int input)
    {
        currentDialogIdx = input;
    }
    public void SetCurrentBattlekey(int input)
    {
        currentBattleStageIdx = input;
    }
    public void SetCurrentSceneKey(int input)
    {
        currentSceneDataIdx = input;
    }

    //모드 관련 함수
    public void SetGameMode(int modeNum)
    {
        currentMode = modeNum;
    }
    public int GetGameMode()
    {
        return currentMode;
    }
    /*
    public MoeumData GetMoeumData()
    {
        
    }
    */
    public Dictionary<string,string> GetSingleHintDictionary(string inputValue)
    {
        Dictionary<string, string> outDict = new Dictionary<string, string>();
        if(chosungValHint_Tbl.ContainsKey(inputValue))
        {
            outDict = chosungValHint_Tbl[inputValue];
        }
        else
        {
            Debug.LogError("didnt have right hint table for : " + inputValue);
        }

        return outDict;
    }
    public string[] GetSingleWrongHintArray(string inputChoWord)
    {
        string[] outArr=new string[1];
        if (chosungWrongHintTable.ContainsKey(inputChoWord))
        {
            outArr = chosungWrongHintTable[inputChoWord];
        }
        else
        {
            Debug.LogError("didnt have right hint table for : " + inputChoWord);
        }
        return outArr;
    }
    public void SetAllHintData(Dictionary<string,Dictionary<string,string>> hintTable,Dictionary<string,string[]> wrongHintTable)
    {
        chosungValHint_Tbl = hintTable;
        chosungWrongHintTable = wrongHintTable;
    }
    public void SetisFirstStart()
    {
        isFirstStart = false;
    }
    public bool GetisFirstStart()
    {
        return isFirstStart;
    }

}
public class BattleSceneData
{
    public int key;
    public int chapterNum;
    public int stageNum;
    public string[] problemPocket; //xml load 에서 뜯어서 넣어줌
    public string[] hellProblemPocket;
    public float enemyHp;
    public float enemyDamage;
    public int enemyPrefab;
    public bool isBoss;
    public int bossPattern;
    public int nextDialogNum;
    //추가
    public string BGImage;
    public string BGM;   
}

/*
 * key : 배틀 씬 키값
 * chapter num : 챕터 넘버
 * stageNum: 스테이지 넘버
 * problum pocket : 문제 초성 정보
 * hell problem pocket : 높은 난이도 문제 초성 정보
 * enemy hp
 * enemy damage : 에너미 투사체 데미지값
 * next dialog num : 다음 다이얼로그 씬으로 넘어갈 때 쓸 키값
 */


public class MoeumData
{ 
    public string[] problemPocket; //xml load 에서 뜯어서 넣어줌
    public string[] hellProblemPocket;

}

public class DialogData
{
    public int key;
    public int chapterNum;
    public int stageNum;
    public string[] script;
    public string[] conv_state;
    public bool isKnockDown;
    //추가
    public string BGImage;
    //public string sunbiImage;
    public string enemyImage;
    public string enemyWholeImage;
    public string BGM;
}

public class SceneData
{
    public int key;
    public int nextScene;
    public int nextSceneKey;
}

/*

key : 다이얼로그 키값
chapter num : 챕터 넘버
stageNum : 스테이지 넘버
script [] : 대사
conv state [] : 이미지 함수 파라미터 (1~한 4까지? 일듯)`
is next scene battle : 다음 씬이 배틀 씬인지
nextscenekey: 다음 배틀씬으로 넘어갈때 쓸 키값 

*/
