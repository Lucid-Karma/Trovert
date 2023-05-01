using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public enum ExecutingState
{
    IDLE,
    WALK,
    SPRINT
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
    public float currentSpeed;  // 5f in the inspector.
    [Space]
    [Header("Camera")]
    [SerializeField] private Transform thirdPersonCamera;
    [Space]
    [SerializeField] private float mouseSensitivity = 750f;
    [SerializeField] float upLookLimit = -80f;
    [SerializeField] float downLookLimit = 90f;
    private float mouseX, mouseY;
    private float rotationX;

    private float verticalMove, horizontalMove;
    private Vector3 move;    
    #endregion

    #region FSM
    public ExecutingState executingState;
    public CharacterStates currentState;

    public IdleState idleState = new IdleState();
    public WalkState walkState = new WalkState();
    public SprintState sprintState = new SprintState();
    #endregion

    #region Events
    [HideInInspector]
    public UnityEvent OnCharacterIdle = new UnityEvent();
    [HideInInspector]
    public UnityEvent OnCharacterWalk = new UnityEvent();
    [HideInInspector]
    public UnityEvent OnCharacterRun = new UnityEvent();
    #endregion


    void Start()
    {
        executingState = ExecutingState.IDLE;
        currentState = idleState;
        currentState.EnterState(this);
    }

    void Update()
    {
        if(!GameManager.Instance.IsLevelStarted)    return;
        if(GameManager.Instance.IsLevelFail || GameManager.Instance.IsLevelSuccess)     return;
        
        if(FsmManager.Instance.IsCharacterCommunicating)
        {
            executingState = ExecutingState.IDLE;
        }
        else
        {
            if(Input.GetAxis("Vertical") != 0 || Input.GetAxis("Horizontal") != 0)
            {
                if(Input.GetKey(KeyCode.LeftShift))
                {
                    executingState = ExecutingState.SPRINT;
                }
                else 
                    executingState = ExecutingState.WALK;
            }
            else
            {
                executingState = ExecutingState.IDLE;
            }

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

    public void LookAround()
    {
        mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        rotationX -= mouseY;
        rotationX = Mathf.Clamp(rotationX, upLookLimit, downLookLimit);

        thirdPersonCamera.localRotation = Quaternion.Euler(rotationX, 0, 0);

        transform.Rotate(Vector3.up * mouseX);
    }

    public void SwitchState(CharacterStates nextState)
    {
        currentState = nextState;
        currentState.EnterState(this);
    }
}
