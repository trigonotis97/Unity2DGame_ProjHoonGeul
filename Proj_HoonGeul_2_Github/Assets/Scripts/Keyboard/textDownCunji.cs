using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class textDownCunji : MonoBehaviour
{
    RectTransform childRect;
    Text text;
    float min, max;


    // Start is called before the first frame update
    void Start()
    {
        childRect = transform.GetChild(0).GetComponent<RectTransform>();
        text = transform.GetChild(0).GetComponent<Text>();
        min = childRect.offsetMin.y;
        max = childRect.offsetMax.y;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PointerDown()
    {
        childRect.offsetMin = new Vector2(childRect.offsetMin.x, min -16);
        childRect.offsetMax = new Vector2(childRect.offsetMax.x, max -16);
       
    }

    public void PointerUp()
    {
        childRect.offsetMin = new Vector2(childRect.offsetMin.x, min);
        childRect.offsetMax = new Vector2(childRect.offsetMax.x, max);
    
    }
}
