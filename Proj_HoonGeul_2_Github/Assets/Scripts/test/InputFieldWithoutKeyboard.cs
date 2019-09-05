using UnityEngine;
using UnityEngine.UI;
 
public class InputFieldWithoutKeyboard : InputField
{
    protected override void Start()
    {
        keyboardType = (TouchScreenKeyboardType)(-1);
        base.Start();
    }
}