using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Test_inputfieldCursor : MonoBehaviour
{
    //TextEditor ed

    InputField mField;
    // Start is called before the first frame update
    void Start()
    {
        mField = GetComponent<InputField>();
        if (!mField.isFocused)
        {
            mField.ActivateInputField();
        }
    }

    public void onClick()
    {
        --mField.caretPosition;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(mField.caretPosition);
    }

    
}
