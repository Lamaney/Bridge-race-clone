using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
   Animator animator;
    PlayerMovement playerMovement;
    Rigidbody rb;

    private void Awake()
    {
       animator = GetComponent<Animator>();
        playerMovement = GetComponent<PlayerMovement>();
        rb = GetComponent<Rigidbody>();
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SetCharacterState();
    }

    private void FixedUpdate()
    {
        
    }


    void SetCharacterState()
    {
        if (rb.velocity.magnitude == 0)
        {
            animator.SetBool("IsRunning", false);
            Debug.Log(rb.velocity.magnitude.ToString());

        }

        else if (rb.velocity.magnitude > 0)
        {
            
            animator.SetBool("IsRunning", true);
            Debug.Log(rb.velocity.magnitude.ToString());

        }
                

    }


   
}
