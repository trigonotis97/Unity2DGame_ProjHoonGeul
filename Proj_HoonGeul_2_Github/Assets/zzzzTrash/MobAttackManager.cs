using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobAttackManager : MonoBehaviour
{
    // 	- 에너미 공격 패턴 생성, 제어하는 객체
    //  -> 에너미의 공격을 호출함, 필요한 변수(공격 속도라던지?)를 결정해 해당 기능을 할 객체에 공격신호를 전달.

    /* 현재 EnemyScript에 들어있는 공격 패턴들을 전부 여기로 옮겨서 EnemyScript의 역할 분산
     */


    //프리팹 생성을 위한 변수

    void Start()
    {
        //SceneManager에 있는 공격 패턴에 따른 변수들을 불러오기?
    }

    void EnemyAttack()
    {
        //공격 패턴에 맞는 변수들에 따른 다른 공격들.
        //공격 투사체들 프리팹 호출로 발사.
        //IEnumerator을 호출하여 공격 사이 쉬는 시간.
    }

    IEnumerator AttackWave(float waveTime)
    {
        yield return new WaitForSeconds(waveTime);
        //공격 속도 변수에 따라서 쉬는 시간의 길이도 달라짐. 
    }
    

}
