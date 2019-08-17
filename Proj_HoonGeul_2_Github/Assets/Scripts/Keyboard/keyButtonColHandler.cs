using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class keyButtonColHandler : MonoBehaviour
{
    // Start is called before the first frame update
    public float speedX, speedY;
    public float dirX, dirY;

    public float speedScale;

    void Start()
    {
        speedScale = 0.12f;

        dirX = Random.Range(0, 2);
        dirY = Random.Range(0, 2);
        if (dirX == 0) dirX = -1;
        if (dirY == 0) dirY = -1;
   
        speedX = Random.Range(1f, 9f) * dirX;
        speedY = Random.Range(1f, 9f) * dirY;

        Vector2 xy = new Vector2(speedX, speedY);
        xy.Normalize();
        speedX = xy.x * speedScale;
        speedY = xy.y * speedScale;
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(speedX, speedY, 0));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "KeyColliderX")
        {
            speedX *= -1f;
        }
        if (collision.gameObject.tag == "KeyColliderY")
        {
            speedY *= -1f;
        }
    }
}       
