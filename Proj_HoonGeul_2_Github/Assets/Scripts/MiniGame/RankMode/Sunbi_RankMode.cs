using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sunbi_RankMode : MonoBehaviour
{
    public Animator m_animator;

    public void CorrectAnswerAnim()
    {
        m_animator.SetTrigger("attackT"); //애니메이션 설정

    }
}
