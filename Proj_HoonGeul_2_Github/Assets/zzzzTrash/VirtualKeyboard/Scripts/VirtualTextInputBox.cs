using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class VirtualTextInputBox : MonoBehaviour {

	AutomateKR mAutomateKR = new AutomateKR();
    InputField field;

    public int lastIndex = -1;
    public int textLength;
    public bool isEnd = true;

    public string front;
    public string back;

    protected UnityEngine.UI.InputField mTextField = null;
    protected string TextField
    {
        set
        {
            if (mTextField != null)
            {
                mTextField.text = value;
            }
        }
        get
        {
            if (mTextField != null)
            {
                return mTextField.text;
            }
            return "";
        }
    }

    void Start () {
        mTextField = GetComponent<InputField>();
        field = GetComponent<InputField>();
    }
	
	void Update ()
    {
        field.selectionAnchorPosition = field.text.Length;
        field.selectionFocusPosition = field.selectionAnchorPosition;

        //TextField = front + mAutomateKR.ingWord + back;

        //if(lastIndex == -1)
        //{
        //    front = mAutomateKR.completeText;
        //}

        //Debug.Log(mAutomateKR.completeText);

        //if (textLength != field.text.Length)
        //{
        //    field.selectionAnchorPosition++;
        //    field.selectionFocusPosition = field.selectionAnchorPosition;
        //    textLength = mAutomateKR.completeText.Length;
        //    if(mAutomateKR.ingWord != null)
        //    {
        //        textLength += mAutomateKR.ingWord.Length;
        //    }
        //    lastIndex = field.selectionAnchorPosition;
        //}

        //if(field.selectionAnchorPosition != lastIndex)
        //{
        //    front = mAutomateKR.completeText.Substring(0, field.selectionAnchorPosition);
        //    back = mAutomateKR.completeText.Substring(field.selectionAnchorPosition, field.text.Length - field.selectionAnchorPosition);

        //    lastIndex = field.selectionAnchorPosition;
        //}
    }

    public void Clear()
    {
        mAutomateKR.Clear();
        mAutomateKR = new AutomateKR();

    }
    

    public void KeyDownHangul(char _key)
    {
        if(isEnd)
        {
            mAutomateKR.SetKeyCode(_key);
        }

        TextField = mAutomateKR.completeText + mAutomateKR.ingWord;
    }

    public void KeyDown(char _key)
    {
        if(isEnd)
        {
            mAutomateKR.SetKeyString(_key);
        }

        TextField = mAutomateKR.completeText + mAutomateKR.ingWord;
    }

    public void KeyDown(VirtualKey _key)
    {
        if(isEnd)
        {
            switch (_key.KeyType)
            {
                case VirtualKey.kType.kBackspace:
                    {
                        mAutomateKR.SetKeyCode(AutomateKR.KEY_CODE_BACKSPACE);

                    }
                    break;
                case VirtualKey.kType.kSpace:
                    {
                        mAutomateKR.SetKeyCode(AutomateKR.KEY_CODE_SPACE);
                    }
                    break;
            }
        }

        TextField = mAutomateKR.completeText + mAutomateKR.ingWord;
    }
}
