using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeleteEnemyBullet : MonoBehaviour
{
    Text m_text;
    Image m_image;
    private void Awake()
    {
        m_text = transform.GetChild(1).GetComponent<Text>();
        m_image= transform.GetChild(0).GetComponent<Image>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag =="Sunbi")
        {
            MakeBulletInvisable();                
        }
    }

    void MakeBulletInvisable()
    {
        m_image.enabled = false;
        m_text.enabled = false;
    }


}
