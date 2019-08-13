using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
/*
//힌트, 오답 투사체 위한 변수 가져오기 
    - 선비 오브젝트의 피격 횟수
    - 정답 맞출때 체크
    - 힌트,오답 가져오기
    - 힌트: 이미 쓴거중에 똑같은거는 안나오게 검색, 사전에실제로 있는단어 검색
구현할거
    - 힌트, 오답 확률 (확률변수 인스펙터로 보이게 만들기)
    - 힌트 검색

힌트 단어 풀 생성
    - 자음 단어 별 단어 풀 생성
*/
public class EnemyScriptDefault : MonoBehaviour
{

    //변수 조정 부분 
    [Header("for TEST")]
    public float maxHP;
    public float currentHp; // 현재 enemy의 hp
    public float attackDemage;
    public float attackWaveSpeed_temp; //임시
    public bool isBoss;

    ///데이터 초기화 부분
    GameManager m_gameManager;
    public BattleManager m_battleManager;
    EnemyStatus m_enemyData;


    //에너미가 발사할 프리팹 public 으로 넣을 공간
    public GameObject [] enemyAttackPrefb; // = new GameObject[3];
    Text attackPrefText;


    Slider hpBar;
    Animator animator;
    GameObject m_canvas;
    Sunbi m_sunbi;
    public float sunbiAttackDamage;

    private int hpValue;

    ///에너미 투사체 단어관련 변수
    public int bulletState=0;// 0:image  1:worngHint 2:rightHint
    public Dictionary<string, string>[] temp_dictTable = new Dictionary<string, string>[4];

    private void Awake()
    {
        m_gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        m_battleManager = GameObject.FindGameObjectWithTag("BattleManager").GetComponent<BattleManager>();
        hpBar = GameObject.FindGameObjectWithTag("EnemyHpBar").GetComponent<Slider>();
        m_canvas = GameObject.FindGameObjectWithTag("Canvas");
        animator = this.GetComponent<Animator>();
        m_sunbi = GameObject.FindGameObjectWithTag("Sunbi").GetComponent<Sunbi>();
    }
    void Start()
    {
        attackWaveSpeed_temp = 4;
        m_enemyData = m_battleManager.GetEnemyData();
        maxHP = m_enemyData.maxHp;

        attackDemage = m_enemyData.attack_demage;

        //sunbi data 가져오기
        m_sunbi.SetEnemyDamage(attackDemage);
        sunbiAttackDamage = m_sunbi.GetSunbiDamage();
        
        StartCoroutine("AttackWave");
        currentHp = maxHP;

        //transform.position = new Vector3(507.392f,405.248f,- 9000f);

        
    }

    public void EnemyDamage(/*int i*/) //콜라이더 ontrigger 에서 호출
    {
        currentHp -= sunbiAttackDamage;
        if (currentHp <= 0f)
        {
            currentHp = 0;
            hpBar.value = 0;
            //게임오버 판정
            m_battleManager.SetStateStageClear();

           
            m_battleManager.NextDialogScene();
            //SceneManager.LoadScene("DialogScene", LoadSceneMode.Single);
        }
        else
        {
            hpBarUpdate();
        }

    }
    void hpBarUpdate()
    {
        hpBar.value = currentHp / maxHP;
    }
    public void EnemyAttack() //fire bullet
    {
        GameObject attackPref = Instantiate(enemyAttackPrefb[0], transform.position + new Vector3(0, 1.5f, 0), transform.rotation) as GameObject;
        attackPref.transform.SetParent(m_canvas.transform, false);
        attackPrefText = attackPref.transform.GetComponent<Text>();
        attackPrefText.text = "공1";//"お前";
    }

    IEnumerator AttackWave()
    {
        Debug.Log("start wave");
        yield return new WaitForSeconds(attackWaveSpeed_temp);
        EnemyAttack();
        StartCoroutine(AttackWave());
        //공격 속도 변수에 따라서 쉬는 시간의 길이도 달라짐. 
    }



    public void CallEnemyAttack()
    {
        //EnemyAttackManager의 EnemyAttacks를 호출.
    }

    /*이만큼의 내용이 아마 EnemyAttackManagerDefault.cs로 옮겨질 예정
     * public void EnemyAttacks() //IEnumerator에서 호출
    {
        AttackSeed = Random.Range(0, 3);
        animator.SetTrigger("attackT");
        switch (AttackSeed)
        {
            case 0:
                GameObject attackPref=Instantiate(EnemyAttack1, transform.position + new Vector3(0, 1.5f, 0), transform.rotation)as GameObject;
                attackPref.transform.SetParent(canvasObj.transform, false);
                //프리팹 컴포넌트에 입력 스트링값 전달
                attackPrefText = attackPref.transform.GetComponent<Text>();
                attackPrefText.text = "가다";// "おはよう";
                break;
            case 1:
                GameObject attackPref2 = Instantiate(EnemyAttack2, transform.position + new Vector3(0, 1.5f, 0), transform.rotation) as GameObject;
                attackPref2.transform.SetParent(canvasObj.transform, false);
                //프리팹 컴포넌트에 입력 스트링값 전달
                attackPrefText = attackPref2.transform.GetComponent<Text>();
                attackPrefText.text = "가다";//"お前";

                break;
            case 2:
                GameObject attackPref3 = Instantiate(EnemyAttack3, transform.position + new Vector3(0, 1.5f, 0), transform.rotation) as GameObject;
                attackPref3.transform.SetParent(canvasObj.transform, false);
                //프리팹 컴포넌트에 입력 스트링값 전달
                attackPrefText = attackPref3.transform.GetComponent<Text>();
                attackPrefText.text = "가다";//"きらい";

                break;
        }
        //StartCoroutine(WaitForIt());
    }

    //여기가 아니라 EnemyAttackPattern으로
    IEnumerator WaitForIt()
    {
        yield return new WaitForSeconds(3.0f);
        EnemyAttacks();
    } */

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.tag == "PlayerBullet") 
        {
            EnemyDamage();
        }
    }

    public void Damaged()
    {

    }
    public void SetEnemyData(float enemyHp,float enemyDemage)
    {
        m_enemyData.maxHp = enemyHp;
        m_enemyData.attack_demage = enemyDemage;
    }
}
