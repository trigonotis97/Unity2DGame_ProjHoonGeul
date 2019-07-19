using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class FocusInputField : InputField
{

    public override void OnDeselect(BaseEventData eventData)
    {
        Debug.Log("Overrides InputField.Deselect");
    }
}