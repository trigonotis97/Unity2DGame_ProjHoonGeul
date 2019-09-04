using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class textDownCunji : MonoBehaviour
{
    RectTransform childRect;
    Text text;
    float top = 164.89f;
    float bottom = -169.93f;


    // Start is called before the first frame update
    void Start()
    {
        childRect = transform.GetChild(0).GetComponent<RectTransform>();
        text = transform.GetChild(0).GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PointerDown()
    {
        childRect.offsetMin = new Vector2(childRect.offsetMin.x, -16);
        childRect.offsetMax = new Vector2(childRect.offsetMax.x, -16);
       
    }

    public void PointerUp()
    {
        childRect.offsetMin = new Vector2(childRect.offsetMin.x, 0);
        childRect.offsetMax = new Vector2(childRect.offsetMax.x, 0);
    
    }
}
