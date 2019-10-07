using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CustomCursor : MonoBehaviour
{

    public float scale;
    public float spaceScale;
    public float singleCharacterScale;

    RectTransform m_defaultPos;
    RectTransform m_thisPos;

    private void Start()
    {
        m_thisPos = GetComponent<RectTransform>();
        m_defaultPos = m_thisPos;
    }

    public void AddPosSingleChar()
    {
        m_thisPos.position = new Vector3(m_thisPos.position.x + singleCharacterScale, m_thisPos.position.y, m_thisPos.position.z);
    }
    public void DeletePosSingleChar()
    {
        m_thisPos.position = new Vector3(m_thisPos.position.x - singleCharacterScale, m_thisPos.position.y, m_thisPos.position.z);
    }
    public void AddPosSpace()
    {
        m_thisPos.position = new Vector3(m_thisPos.position.x + spaceScale, m_thisPos.position.y, m_thisPos.position.z);

    }
    public void DeletePosSpace()
    {
        m_thisPos.position = new Vector3(m_thisPos.position.x - spaceScale, m_thisPos.position.y, m_thisPos.position.z);

    }
    public void MakeDefaultPos()
    {
        m_thisPos = m_defaultPos;
    }
}
