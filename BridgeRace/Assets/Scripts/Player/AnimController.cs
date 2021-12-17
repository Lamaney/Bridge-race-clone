using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimController : MonoBehaviour
{
    
    Animator animator;

    private void Awake()
    {
       animator = GetComponent<Animator>();

    }




    public void PlayIdleAnim()
    {
        animator.SetBool("IsRunning", false);
    }

    public void PlayRunningAnim()
    {
        animator.SetBool("IsRunning", true);
    }

}
