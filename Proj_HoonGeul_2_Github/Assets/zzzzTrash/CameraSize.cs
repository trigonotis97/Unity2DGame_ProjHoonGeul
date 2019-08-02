using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSize : MonoBehaviour
{
    float defaultHeight;
    float defaultWidth;
    // Start is called before the first frame update
    void Start()
    {
        defaultHeight = Camera.main.orthographicSize;
        defaultWidth = Camera.main.orthographicSize * Camera.main.aspect;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
