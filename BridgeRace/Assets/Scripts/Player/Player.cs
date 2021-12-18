using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
   Animator animator;
    AnimController controller;
    PlayerMovement playerMovement;
    Rigidbody rb;

    private void Awake()
    {
       AnimController controller = GetComponent<AnimController>();
        playerMovement = GetComponent<PlayerMovement>();
        rb = GetComponent<Rigidbody>();
    }


    

    // Update is called once per frame
    void Update()
    {
        SetCharacterState();
    }

   



    //set character state with velocity 
    void SetCharacterState()
    {
        if (rb.velocity.magnitude == 0)
        {
            
            playerMovement.SetMovementState(PlayerMovement.MovementStates.Idle);
        }

        else if (rb.velocity.magnitude > 0)
        {
            
            playerMovement.SetMovementState(PlayerMovement.MovementStates.Running);

        }
                

    }


   
}
