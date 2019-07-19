using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManagerScript : MonoBehaviour
{
    public GameObject Keyboardlock;

    ChosungGeneratorDefault generator;
    EnemyScript callattack;
    void Start()
    {
        StartCoroutine(BeforeStart());


        generator = GameObject.Find("ChosungObject").GetComponent<ChosungGeneratorDefault>();
        callattack = GameObject.Find("Enemy").GetComponent<EnemyScript>();

        /*
        for (int i = 0; i < 3; i++) //코루틴을 빼서 초반 시작 딜레이를 없애려고 했지만 
        //오브젝트 할당순서가 물리고 물려서 부득이하게 일단 넣어줌
        {
            generator.MakeNewQuestion(i);// 무작위 초성 생성
        }
        callattack.EnemyAttacks();
        */
    }

    IEnumerator BeforeStart()
    {
        /*
        아마 게임초반 딜레이때문에 여기에 초성 초기화문을 넣은것 같은데 나중에 더 가독성있게 바꾸자.
        게임초반 딜레이도 기획부분에서 변경될것.
    */
        yield return new WaitForSeconds(1.0f);
        Destroy(Keyboardlock);
        for(int i = 0; i < 3; i++)
        {
            //generator.MakeNewQuestion(i);// 무작위 초성 생성
        }
        callattack.EnemyAttacks();
    }
}
