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
    #endregion

    #region Events
    [HideInInspector]
    public UnityEvent OnCharacterIdle = new UnityEvent();
    [HideInInspector]
    public UnityEvent OnCharacterWalk = new UnityEvent();
    #endregion

    bool isCaught = false;
    void OnEnable()
    {
        EventManager.OnIntrovertCaught.AddListener(() => executingState = ExecutingState.IDLE);
        EventManager.OnIntrovertCaught.AddListener(() => isCaught = true);
        EventManager.OnIntrovertLeave.AddListener(() => executingState = ExecutingState.WALK);
        EventManager.OnIntrovertLeave.AddListener(() => isCaught = false);
    }
    void OnDisable()
    {
        EventManager.OnIntrovertCaught.RemoveListener(() => executingState = ExecutingState.IDLE);
        EventManager.OnIntrovertCaught.RemoveListener(() => isCaught = true);
        EventManager.OnIntrovertLeave.RemoveListener(() => executingState = ExecutingState.WALK);
        EventManager.OnIntrovertLeave.RemoveListener(() => isCaught = false);
    }

    void Start()
    {
        executingState = ExecutingState.IDLE;
        currentState = idleState;
        currentState.EnterState(this);
    }


    void Update()
    {
        if(isCaught)    return;

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
