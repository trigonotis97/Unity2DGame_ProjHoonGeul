using UnityEngine;
using System.Collections.Generic;

public class VirtualKeyboard : MonoBehaviour {

    public VirtualTextInputBox TextInputBox = null;
    public enum kLanguage { kKorean, kEnglish};
    public bool mPressShift = false;
    public kLanguage mLanguage = kLanguage.kKorean;

    public VirtualKey[] virtualKeys;

    protected Dictionary<char, char> CHARACTER_TABLE = new Dictionary<char, char>
    {
        {'1', '!'}, {'2', '@'}, {'3', '#'}, {'4', '$'}, {'5', '%'},{'6', '^'}, {'7', '&'}, {'8', '*'}, {'9', '('},{'0', ')'},
        { '`', '~'},   {'-', '_'}, {'=', '+'}, {'[', '{'}, {']', '}'}, {'\\', '|'}, {',', '<'}, {'.', '>'}, {'/', '?'}
    };
    
    public void SetInputBox(VirtualTextInputBox inputBox)
    {
        TextInputBox = inputBox;
    }

    void Awake()
    {
        VirtualKey._Keybord = this;
    }
	// Use this for initialization
	void Start ()
    {
        virtualKeys = FindObjectsOfType<VirtualKey>();
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    public void Clear()
    {
        if(TextInputBox != null)
        {
            TextInputBox.Clear();
        }
    }

    void OnGUI()
    {
        //Event e = Event.current;
        //if (e.isKey)
        //  Debug.Log("Detected key code: " + e.keyCode);

    }

    private void Refresh()
    {
        foreach(var key in virtualKeys)
        {
            key.RefreshKeyboard();
        }
    }

    public void KeyDown(VirtualKey _key)
    {
        if(TextInputBox != null)
        {
            switch(_key.KeyType)
            {
                case VirtualKey.kType.kShift:
                    {
                        mPressShift = !mPressShift;
                        Refresh();
                    }
                    break;
                case VirtualKey.kType.kHangul:
                    mPressShift = false;
                    mLanguage = kLanguage.kKorean;
                    Refresh();
                    break;
                case VirtualKey.kType.kEnglish:
                    mPressShift = false;
                    mLanguage = kLanguage.kEnglish;
                    Refresh();
                    break;
                case VirtualKey.kType.kSpace:
                case VirtualKey.kType.kBackspace:
                    {
                        TextInputBox.KeyDown(_key);
                    }
                    break;
                case VirtualKey.kType.kReturn:
                    {
                        //do somehing
                    }
                    break;
                case VirtualKey.kType.kCharacter:
                    {
                        char keyCharacter = _key.KeyCharacter;
                        if (mPressShift)
                        {
                            keyCharacter = char.ToUpper(keyCharacter);
                            mPressShift = false;
                            Refresh();
                        }

                        if (mLanguage == kLanguage.kKorean)
                        {
                            TextInputBox.KeyDownHangul(keyCharacter);
                        }
                        else if (mLanguage == kLanguage.kEnglish)
                        {
                            TextInputBox.KeyDown(keyCharacter);
                        }
                    }
                    break;
                case VirtualKey.kType.kOther:
                    {
                        char keyCharacter = _key.KeyCharacter;
                        if (mPressShift)
                        {
                            keyCharacter = CHARACTER_TABLE[keyCharacter];
                            mPressShift = false;
                            Refresh();
                        }
                        TextInputBox.KeyDown(keyCharacter);
                    }
                    break;
            }
        }
    }
}
