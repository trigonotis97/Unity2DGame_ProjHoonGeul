using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingText : MonoBehaviour
{
    private void Start()
    {
        Debug.Log("instantiate1");
    }
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {

        
        if ((collision.tag == "Enemy") || (collision.tag == "Boss"))
        {

            Destroy(gameObject);

        }
    }
}
