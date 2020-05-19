using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Sunbi : MonoBehaviour
{

    //변수 조정 부분
    [Header("for TEST")]
    public float maxHP;
    public float currentHp; //현재 sunbi의  hp
    public Text sunbiHpText;

    public float attackDamage; //어차피 작용하는건 enemy의 데미지인데 선비공격데미지를 왜 가지고 있지?
    public float attackSpeed_temp;
    public float healValue;

    [Header("default")]
    ///데이터 초기화부분 
    GameManager m_gameManager;
    BattleManager m_battleSceneManager;

    //투사체 프리팹 관련
    public GameObject bulletPref_defalut;
    Text bulletPrefText;//받아오기

    public Animator m_animator;
    //public TimeBar timeSlider;
    public Slider sunbiHpSlider;
    public Animator hpAnimator;
    BoxCollider2D m_boxCollider;

    public AudioClip sunbiAudioClip;
    public GameObject canvasObj;//프리팹 캔버스 하위에 생성하기 위해서 가져오기

    //적 받아오기
    //public GameObject enemy;
    public EnemyScriptDefault m_enemy;
    public float enemyDamage;

    //적 힌트 투사체를 위한 선비 피격 카운트 보낼 오브젝트
    public EnemyHintBulletHandler m_enemybulletHandler;

    //effect audio
    AudioSource effectAudioSource;
    public AudioClip sunbi_hit;

    /*
    Awake는 모든 오브젝트가 초기화되고 호출되기 때문에, 
    GameObject.FindWithTag를 이용해서 해당 게임 오브젝트를 요청하거나, 
    다른 오브젝트와 안전하게 연동해서 사용할 수 있습니다.
    */
    private void Awake()
    {
        m_gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        m_battleSceneManager = GameObject.FindGameObjectWithTag("BattleManager").GetComponent<BattleManager>();
        m_animator = GetComponent<Animator>();
        m_boxCollider = GetComponent<BoxCollider2D>();
    }

    private void Start()
    {
        currentHp = maxHP;
        hpBarUpdate();
        effectAudioSource = GameObject.FindGameObjectWithTag("effectAudioComp").GetComponent<AudioSource>();
    }



    /// player attack prefab 생성
    public void Attack(string inputString) //test_input 스크립트의 textInputEnter()에서 호출 +(19.04.28) i로 불러오는 값을 문자열로 수정. switch문 삭제
    {
        m_animator.SetTrigger("attackT"); //애니메이션 설정
        
        GameObject bullet = Instantiate(bulletPref_defalut, new Vector3(0, 0, 0), transform.rotation) as GameObject;  //공격 생성.
        //생성된 프리팹 캔버스 하위로 상속
        bullet.transform.SetParent(canvasObj.transform, false);
        
        //프리팹 컴포넌트에 입력 스트링값 전달
        bullet.GetComponent<Text>().text= inputString;
        Debug.Log(bullet.GetComponent<Text>().text);

        //m_enemy.EnemyDamage();

    }
    public void Heal()
    {
        //currentHp += healValue;
        hpAnimator.SetTrigger("hp_heal");
        currentHp += healValue;
        Debug.Log(currentHp);
        //timeSlider.IncreaseTimeBar(healValue / maxHP);
        hpBarUpdate();

    }

    
    // 아래 콜라이더 ontrigger에서 호출
    public void Damage() //선비가 피격당함
    {
        //선비 hp 감소
        hpAnimator.SetTrigger("hp_heat");
        currentHp -= enemyDamage;
        //hp bar value 변경을 위한 변환 (value : 0~1f)

        effectAudioSource.PlayOneShot(sunbi_hit);
        
        if(currentHp<=0f)
        {
            currentHp = 0;
            sunbiHpSlider.value = 0;
            //게임오버 판정
            m_battleSceneManager.SetStateGameover();
            
            //battle scene 으로 게임오버 함수 실행
        }
        else
        {
            hpBarUpdate();
        }
    }
    void hpBarUpdate()
    {
        sunbiHpSlider.value = currentHp / maxHP;
        sunbiHpText.text = currentHp.ToString() + " / " + maxHP.ToString();
    }
    


    //충돌 검사
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "EnemyBullet")
        {
            m_animator.SetTrigger("hitT");
            Damage();
            m_enemybulletHandler.SunbiHitCounter();
            //Debug.Log(currentHp);
        }
       
    }

    //enemyscript에서 호출, 에너미 데이터 가져와서 초기화
    public void SetEnemyDamage(float enemyDamage)
    {
        this.enemyDamage = enemyDamage;
    }
    public void AccessEnemyObject()
    {
        m_enemy = GameObject.FindGameObjectWithTag("Enemy").GetComponent<EnemyScriptDefault>();
    }
    
    public float GetSunbiDamage()
    {
        return attackDamage;
    }
    
}
