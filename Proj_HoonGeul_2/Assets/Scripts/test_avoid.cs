using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test_avoid : MonoBehaviour
{
    public Animator animator;
    public BoxCollider2D collider2D;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ColliderMakeFalse()
    {
        animator.SetBool("voidBool", true);
        collider2D.enabled=false;
    }
    public void ColliderMakeTrue()
    {
        animator.SetBool("voidBool", false);
        collider2D.enabled = true;
    }
}
