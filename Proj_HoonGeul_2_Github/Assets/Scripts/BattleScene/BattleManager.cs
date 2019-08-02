using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class EnemyStatus
{
    public float maxHp;
    public float attack_demage;

}



/*	- 배경이미지 불러오기
- 사운드? //스테이지 별로 효과음 달라질 수 있음
- 문제 출제 범위 지정 (글자수 , 어원 등등 )
- 에너미 프리팹 스테이지에 맞게 선택해서 불러오기 

- 에너미 공격패턴 , 속도
- 에너미 공격 데미지
- (미확정) 에너미별 특수 스킬?
- hp값 
*/
public class BattleManager : MonoBehaviour
{
    
    GameManager m_gameManager;
    public int show_chapter_num;
    public int show_stage_num;
    //데이터 받아올변수
    public BattleSceneData m_data; //현재 배틀 스테이지에서 사용할 데이터


    StageState stageStatus; // 0: 게임 시작 전 1: 게임중 2: 게임 중단 3:게임종료 4: 게임 클리어
    public GameObject m_canvas;

    enum StageState
    {
        READY,
        PLAYING,
        GAMEOVER,
        STAGECLEAR
    };
    

    
    GameObject m_enemy;
    //public SpriteRenderer bg_image; // ####
    public Image bg_image_;

    public AudioClip bg_audioclip;
    AudioSource m_audioSource;

    int currentMode;

    ChosungGeneratorDefault m_generator;

    private void Awake()
    {
        m_gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        m_generator = GameObject.FindGameObjectWithTag("QuestionControl").GetComponent<ChosungGeneratorDefault>();
        m_audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        stageStatus = StageState.READY;
        
        //###나중에 받아오기
        //데이터 받아오기 (가져올 객체 : 
        m_data = m_gameManager.GetBattleSceneData();
        if(m_data.stageNum==1)
        {
            m_gameManager.SaveCheckPoint();
        }
        Debug.Log(m_data.enemyDamage);
        m_generator.SetProblempocket(m_data.problemPocket, m_data.hellProblemPocket);

        //백그라운드 오디오 가져오기 및 재생
        Debug.Log("clip :: " + m_data.BGM);
        bg_audioclip = Resources.Load("BGM/" + m_data.BGM)as AudioClip;
           
        m_audioSource.clip = bg_audioclip;
        m_audioSource.Play();
        m_audioSource.loop = true;




        show_chapter_num = m_data.chapterNum;
        show_stage_num = m_data.stageNum;

        //m_enemy = Resources.Load("EnemyPref/" + m_data.key.ToString()) as GameObject;
        if (!m_data.isBoss)
        {
            m_enemy = Instantiate(Resources.Load("EnemyPref/Mob_" + m_data.enemyPrefab.ToString()) as GameObject, new Vector3(507.392f, 405.248f, -9000f), transform.rotation) as GameObject;
        }
        else
        {
            m_enemy = Instantiate(Resources.Load("EnemyPref/Mob_" + m_data.enemyPrefab.ToString()) as GameObject, new Vector3(507.392f, 405.248f, -9000f), transform.rotation) as GameObject;
            //m_enemy = Instantiate(Resources.Load("EnemyPref/Boss_" + m_data.enemyPrefab.ToString()) as GameObject, new Vector3(507.392f, 405.248f, -9000f), transform.rotation) as GameObject;
        }
        m_enemy.transform.SetParent(m_canvas.transform, false);
        //m_enemy.GetComponent<EnemyScriptDefault>().SetEnemyData(m_data.enemyHp, m_data.enemyDamage);

        
        bg_image_.sprite = Resources.Load("Background/"+m_data.BGImage,typeof(Sprite))as Sprite;
     
     

    }

    //enemy script에서 호출.
    public EnemyStatus GetEnemyData()
    {
        Debug.Log(m_data.enemyHp+" <<"+ m_data.enemyDamage);
        EnemyStatus temp=new EnemyStatus();
        temp.maxHp = m_data.enemyHp;
        temp.attack_demage = m_data.enemyDamage;
        return temp;

    }
    public void SetStateGameover()
    {
        stageStatus = StageState.GAMEOVER;

    }
    public void SetStateStageClear()
    {
        stageStatus = StageState.STAGECLEAR;
    }

    public void testDataMapper()
    {

    }
    public bool IsBossStage()
    {
        return m_data.isBoss;
    }
    public bool Is1BossStage()
    {
        return (m_data.chapterNum == 1 && m_data.isBoss);
    }
    public int Is2to5BossStage()
    {
        int outNumInd=0;//어떤스테이지도 아닐경우
        if (m_data.chapterNum == 2 && m_data.isBoss)
        {
            outNumInd = 2;
        }
        else if (m_data.chapterNum == 3 && m_data.isBoss)
        {
            outNumInd = 3;
        }
        else if (m_data.chapterNum == 4 && m_data.isBoss)
        {
            outNumInd = 4;
        }
        else if (m_data.chapterNum == 5 && m_data.stageNum==1)
        {
            outNumInd = 5;
        }
        else if (m_data.chapterNum == 5 && m_data.stageNum == 2)
        {
            outNumInd = 6;
        }
        else if (m_data.chapterNum == 5 && m_data.stageNum == 3)
        {
            outNumInd = 7;
        }
        else if (m_data.chapterNum == 5 && m_data.stageNum == 4)
        {
            outNumInd = 8;
        }

        return outNumInd;
    }

    public int GetChapterNum()
    {
        return m_data.chapterNum;
    }

    public void NextDialogScene()
    {
        //m_gameManager.SetCurrentDialogKey(m_data.nextDialogNum);
        SceneManager.LoadScene("DialogScene", LoadSceneMode.Single);

        ////중요!!! 이부분 게임클리어 시로 넣어야함
        m_gameManager.SetCurrentBattlekey(m_gameManager.GetCurrentBattleKey() + 1);
    }

    /*
    public GameObject Keyboardlock;

    ChosungGenerator generator;
    EnemyScript callattack;
    
    void Start()
    {

       // StartCoroutine(BeforeStart());
        //generator = GameObject.Find("ChosungObject").GetComponent<ChosungGenerator>();
        //callattack = GameObject.Find("Enemy").GetComponent<EnemyScript>();
        /*for (int i = 0; i < 3; i++) //코루틴을 빼서 초반 시작 딜레이를 없애려고 했지만 
        //오브젝트 할당순서가 물리고 물려서 부득이하게 일단 넣어줌
        {
            generator.MakeNewQuestion(i);// 무작위 초성 생성
        }
        callattack.EnemyAttacks();
        


    }

    IEnumerator BeforeStart()
    {
        
        아마 게임초반 딜레이때문에 여기에 초성 초기화문을 넣은것 같은데 나중에 더 가독성있게 바꾸자.
        게임초반 딜레이도 기획부분에서 변경될것.
    
        yield return new WaitForSeconds(1.0f);
        Destroy(Keyboardlock);
        for(int i = 0; i < 3; i++)
        {
            generator.MakeNewQuestion(i);// 무작위 초성 생성
        }
        callattack.EnemyAttacks();
    }
    */


}
