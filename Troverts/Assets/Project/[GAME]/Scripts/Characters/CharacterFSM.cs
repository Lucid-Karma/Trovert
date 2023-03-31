using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public enum ExecutingState
{
    IDLE,
    WALK
}
[RequireComponent(typeof(CharacterController))]
public class CharacterFSM : MonoBehaviour
{
    #region Components
    private CharacterController characterController;
    public CharacterController CharacterController{ get { return(characterController == null)? characterController = GetComponent<CharacterController>() : characterController; }}
    #endregion

    #region Parameters
    [Header("Movement")]
    public float currentSpeed;

    private float verticalMove, horizontalMove;
    private Vector3 move;
    #endregion

    #region FSM
    public ExecutingState executingState;
    public CharacterStates currentState;

    public IdleState idleState = new IdleState();
    public WalkState walkState = new WalkState();
    #endregion

    #region Events
    [HideInInspector]
    public UnityEvent OnCharacterIdle = new UnityEvent();
    [HideInInspector]
    public UnityEvent OnCharacterWalk = new UnityEvent();
    #endregion

    void Start()
    {
        executingState = ExecutingState.IDLE;
        currentState = idleState;
        currentState.EnterState(this);
    }


    void Update()
    {
        if(Input.GetAxis("Vertical") != 0 || Input.GetAxis("Horizontal") != 0)
        {
            executingState = ExecutingState.WALK;
        }
        else
        {
            executingState = ExecutingState.IDLE;
        }

        currentState.UpdateState(this);
    }

    public void Move()
    {
        verticalMove = Input.GetAxis("Vertical") * currentSpeed * Time.deltaTime;
        horizontalMove = Input.GetAxis("Horizontal") * currentSpeed * Time.deltaTime;

        move = transform.right * horizontalMove + transform.forward * verticalMove;
        CharacterController.Move(move);
    }

    float y;
    float vertical;
    float horizontal;
    public void Rotate()
    {
        // vertical = Input.GetAxis("Vertical") * 180;
        // horizontal = Input.GetAxis("Horizontal") * 90;
        y = Input.GetAxis("Vertical") * 180 + Input.GetAxis("Horizontal") * 90;  //180??  ................
        //y = (Input.GetAxis("Vertical") - Input.GetAxis("Horizontal")) * 180;
        //transform.Rotate(0, y * Time.deltaTime, 0, Space.Self);
        //transform.rotation = Vector3.Lerp(transform.position, new Vector3(0, y * Time.deltaTime, 0), 1f);
        //transform.rotation = Quaternion.Euler(0, y * Time.deltaTime, 0);
        //transform.rotation = Quaternion.Lerp(transform.rotation, new Quaternion(0, y * Time.deltaTime, 0, 1), 0.5f);
        transform.rotation = Quaternion.Lerp(Quaternion.identity, Quaternion.Euler(0, y, 0), 1);

        transform.position += transform.forward * currentSpeed * Time.deltaTime;

    }

    public void SwitchState(CharacterStates nextState)
    {
        currentState = nextState;
        currentState.EnterState(this);
    }
}
