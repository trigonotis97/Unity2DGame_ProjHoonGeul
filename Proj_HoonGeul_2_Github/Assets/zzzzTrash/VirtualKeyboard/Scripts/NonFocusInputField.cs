using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class NonFocusInputField : InputField
{
    protected void Update()
    {
        DeactivateInputField();
    }
}
