using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement Values")]
    public float movementSpeed = 5f;
    public float turnSpeed = 3f;
    public float lerpValue = 3f;


    [Header("Movement states")]
    public MovementStates movementStates;

    public enum MovementStates
    {
        Running,
        Idle
    }

    AnimController animController;
    Animator animator;


    private Camera cam;
    public LayerMask layerMask;

    



    Rigidbody rb;


    void Start()
    {
        cam = Camera.main;
        

    }
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        animController = GetComponent<AnimController>();
        animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
       
       

    }
    private void Update()
    {
        PlayAnimBasedOnState();
        if (Input.GetMouseButton(0))
        {
            HandleMovement();
        }
    }



   


    /// <summary>
    /// Handle movement with Ray.
    /// </summary>

    void HandleMovement()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = cam.transform.localPosition.z;


        Ray ray = cam.ScreenPointToRay(mousePos);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask))
        {
            Vector3 hitVector = hit.point;
            hitVector.y = transform.position.y;

            rb.MovePosition(Vector3.MoveTowards(transform.position, Vector3.Lerp(transform.position, hitVector, lerpValue), Time.deltaTime * movementSpeed));
            
            //transform.position = Vector3.MoveTowards(transform.position, Vector3.Lerp(transform.position, hitVector, lerpValue),Time.deltaTime*movementSpeed);
            Vector3 newMovePoint = new Vector3(hit.point.x, transform.position.y, hit.point.z);
            //transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(newMovePoint - transform.position),turnSpeed*Time.deltaTime);
            rb.MoveRotation(Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(newMovePoint - transform.position), turnSpeed * Time.deltaTime));
           

        }




    }



    void PlayAnimBasedOnState()
    {

        switch (movementStates)
        {
            case MovementStates.Running:
                animController.PlayRunningAnim();
                break;
            case MovementStates.Idle:
                animController.PlayIdleAnim();
                break;
            default:
                break;
        }

    }


    public void SetMovementState(MovementStates movementState)
    {
        movementStates = movementState;
    }


}
