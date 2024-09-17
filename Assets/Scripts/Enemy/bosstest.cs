using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bosstest : MonoBehaviour
{
    public Animator animator;
    public int test;

    // Update is called once per frame
    void Update()
    {
        testAnimation();
    }

    private void testAnimation()
    {
        if(test == 1)
        {
            animator.SetBool("Walk", true);
            animator.SetBool("Idle", false);
        }
        else if(test == 0)
        {
            animator.SetBool("Idle", true);
            animator.SetBool("Walk", false);
        }
    }
}
