using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    public GameObject PlayerAttack_default;
    //public Transform Player;

    public Slider hpBar;
    public Text hpBarText;
    Animator animator;
    BoxCollider2D boxCollider;

    //프리팹 생성을 위한 변수
    Text attackPrefText;
    public GameObject canvasObj;

    private int hpValue;

    private void Start()
    {
        animator = this.GetComponent<Animator>();
        hpValue = 100;
        boxCollider = this.GetComponent<BoxCollider2D>();
    }

    /// player attack prefab 생성
    public void Attack(string i) //test_input 스크립트의 textInputEnter()에서 호출 +(19.04.28) i로 불러오는 값을 문자열로 수정. switch문 삭제
    {
        animator.SetTrigger("attackT"); //애니메이션 설정
        Debug.Log("공격! " + i+ " :: "+transform.position);
        GameObject attackPref = Instantiate(PlayerAttack_default, new Vector3(-327, 314, 0), transform.rotation) as GameObject;  //공격 생성.

        //생성된 프리팹 캔버스 하위로 상속
        attackPref.transform.SetParent(canvasObj.transform, false);
        
        //프리팹 컴포넌트에 입력 스트링값 전달
        attackPrefText = attackPref.GetComponent<Text>();
        attackPrefText.text = i;


    }

    // 아래 콜라이더 ontrigger에서 호출
    void PlayerDamage() 
    {
        int i = 10;
        if (hpValue > i)
        {
            hpValue -= i;
            hpBar.value = (hpValue) * 0.01f;
        }
        else
        {
            hpValue = 0;
            hpBar.value = 0;
        }
        hpBarText.text = (hpValue).ToString() + " / 100";
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.tag == "EnemyBullet")
        {
            PlayerDamage();
            animator.SetTrigger("hitT");
        }
    }
    /* 회피 처리 함수. 
    public void ColMakeFalse() //회피용 (자기자신 콜라이더 비활성화, 회피 애니메이션 실행)
    {
        boxCollider.enabled = false;
        animator.SetTrigger("avoidT");
    }
    public void ColMackTrue() // 회피 애니메이션 끝날때 실행. 자기자신 콜라이더 활성화
    {
        boxCollider.enabled = true;
    }
    */
}
