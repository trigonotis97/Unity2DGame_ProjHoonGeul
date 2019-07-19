using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyScript : MonoBehaviour
{
    public GameObject EnemyAttack1;
    public GameObject EnemyAttack2;
    public GameObject EnemyAttack3;
    
    //GameObject 

    public int EnemyHP = 100;
    public int AttackSeed = -1;
    //public Transform Enemy;

    public Slider hpBar;
    public Text hpBarText;

    Animator animator;

    //프리팹 생성을 위한 변수
    Text attackPrefText;
    public GameObject canvasObj;


    private int hpValue;

    void Start()
    {
        hpValue = 100;
        animator = this.GetComponent<Animator>();
    }

    public void EnemyDamage(/*int i*/) //콜라이더 ontriger 에서 호출
    {
        int i = 50;
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
        
        hpBarText.text = (hpValue).ToString()+" / 100";
    }
    

    public void EnemyAttacks() //IEnumerator에서 호출
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
        StartCoroutine(WaitForIt());
    }

    IEnumerator WaitForIt()
    {
        yield return new WaitForSeconds(3.0f);
        EnemyAttacks();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("enemy script collider");
        if (collision.gameObject.tag == "PlayerBullet") 
        {
            EnemyDamage();
        }
    }

    


}
