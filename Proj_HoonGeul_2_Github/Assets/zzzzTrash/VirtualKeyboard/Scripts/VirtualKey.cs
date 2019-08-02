using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class VirtualKey : MonoBehaviour {

    static public VirtualKeyboard _Keybord = null;
    public enum kType { kCharacter, kOther, kReturn, kSpace, kBackspace, kShift, kTab, kCapsLock, kHangul, kEnglish}
    public char KeyCharacter;
    public kType KeyType = kType.kCharacter;

    public string english;
    public string shiftEnglish;
    public string korean;
    public string shiftKorean;

    Text text;
    
    private bool mKeepPresed;
    public bool KeepPressed
    {
        set { mKeepPresed = value; }
        get { return mKeepPresed; }
    }

	// Use this for initialization
	void Start () {
        text = GetComponentInChildren<Text>();

        UnityEngine.UI.Button _button = gameObject.GetComponent<UnityEngine.UI.Button>();
        if(_button != null)
        {
            _button.onClick.AddListener(onKeyClick);
        }
    }

    void onKeyClick()
    {
        //VirtualKeyboard _keybord = GameObject.FindObjectOfType< VirtualKeyboard>();
        if(_Keybord != null)
        {
            _Keybord.KeyDown(this);
        }
    }

    public void RefreshKeyboard()
    {
        if (KeyType != kType.kCharacter)
            return;

        if (_Keybord.mPressShift && _Keybord.mLanguage == VirtualKeyboard.kLanguage.kKorean && shiftKorean != "")
        {
            text.text = shiftKorean;
        }
        else if (_Keybord.mLanguage == VirtualKeyboard.kLanguage.kKorean)
        {
            text.text = korean;
        }
        else if (_Keybord.mPressShift && _Keybord.mLanguage == VirtualKeyboard.kLanguage.kEnglish)
        {
            text.text = shiftEnglish;
        }
        else if (_Keybord.mLanguage == VirtualKeyboard.kLanguage.kEnglish)
        {
            text.text = english;
        }
    }
}