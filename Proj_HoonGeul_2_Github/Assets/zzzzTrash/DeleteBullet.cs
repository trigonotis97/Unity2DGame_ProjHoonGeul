using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteBullet : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        

        if((collision.tag == "Enemy")|| (collision.tag == "Boss"))
        {
            
            Destroy(gameObject);
        
        }
    }
}
