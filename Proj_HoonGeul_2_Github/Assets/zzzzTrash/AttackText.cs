using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AttackText : MonoBehaviour
{
    public Text Output; // Attack.text입니다
    public InputField InputText;

    public void ShowInputText()
    {
        Output.text = InputText.text; // Test_Input으로부터. Attack.text의 값을 InputText.text(입력창)안의 스트링과 같게 한다.
    }
    public void TextDelete()
    {
        Output.text = ""; // DeleteBullet.cs에서 불러옴 = 공격 모션이 끝나면 떠있는 텍스트도 삭제
    }
}
