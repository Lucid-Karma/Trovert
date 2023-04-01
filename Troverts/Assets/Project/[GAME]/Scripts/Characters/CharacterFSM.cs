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

    // float y;
    // float vertical;
    // float horizontal;
    // public void Rotate()
    // {
    //     // vertical = Input.GetAxis("Vertical") * 180;
    //     horizontal = Input.GetAxis("Horizontal") * 90 * Time.deltaTime;
    //     if(Input.GetKeyDown("Horizontal"))
    //     {
    //         transform.Rotate(Vector3.up * horizontal);
    //     }
    //     //y = Input.GetAxis("Vertical") * 180 + Input.GetAxis("Horizontal") * 90;  //180??  ................
    //     //y = (Input.GetAxis("Vertical") - Input.GetAxis("Horizontal")) * 180;
    //     //transform.Rotate(0, y * Time.deltaTime, 0, Space.Self);
    //     //transform.rotation = Vector3.Lerp(transform.position, new Vector3(0, y * Time.deltaTime, 0), 1f);
    //     //transform.rotation = Quaternion.Euler(0, y * Time.deltaTime, 0);
    //     //transform.rotation = Quaternion.Lerp(transform.rotation, new Quaternion(0, y * Time.deltaTime, 0, 1), 0.5f);
        
    //     //transform.rotation = Quaternion.Lerp(Quaternion.identity, Quaternion.Euler(0, y, 0), 1);
    //     //transform.position += transform.forward * currentSpeed * Time.deltaTime;

    //     //transform.Rotate(Vector3.up * horizontal);

    // }

    public void LookAround()
    {
        mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        rotationX -= mouseY;
        rotationX = Mathf.Clamp(rotationX, upLookLimit, downLookLimit);

        thirdPersonCamera.localRotation = Quaternion.Euler(rotationX, 0, 0);

        transform.Rotate(Vector3.up * mouseX);
    }

    /*Vector3 firstPressPos;
    Vector3 targetPos;
    Vector3 dist;
    private float tapInputDownTime;
    private float tapDuration;
    public void Rotate()
    {
//         if(Input.GetMouseButton(0))
//         {
//             Vector3 mousePos = Input.mousePosition;
//             mousePos.z = Camera.main.transform.position.z;
//             mousePos = Camera.main.ScreenToWorldPoint(mousePos);

//             Vector3 dis = transform.position - mousePos;
//             dis.y = 0;
//             transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(dis), 1f);
//         }
        
//         //Editor Input
#if UNITY_EDITOR
        if (Input.GetMouseButtonDown(0))
            tapInputDownTime = Time.time;

        if (Input.GetMouseButtonUp(0))
        {
            tapDuration = Mathf.Abs(tapInputDownTime - Time.time);

            if (tapDuration < 0.2f)
            {
                //EventManager.OnTapDetected.Invoke();
                Debug.Log("Tap " + tapDuration);
            }
            tapDuration = 0;

        }
#else //Android and IOS Input
        if(Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    tapInputDownTime = Time.time;
                    firstPressPos = touch.position;
                    break;
                case TouchPhase.Moved:
                    break;
                case TouchPhase.Stationary:
                    break;
                case TouchPhase.Ended:
                    tapDuration = Mathf.Abs(tapInputDownTime - Time.time);
                    targetPos = touch.position;

                    dist = targetPos - firstPressPos;
                    dist.y = 0;
                    transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(dist), 1f);

                    if (tapDuration < 0.2f)
                    {
                        //OnTapInput.Invoke();
                        Debug.Log("Tap " + tapDuration);
                    }
                    tapDuration = 0;
                    GameManager.Instance.StartGame();
                    //LevelManager.Instance.StartLevel();
                    break;
                case TouchPhase.Canceled:
                    tapDuration = Mathf.Abs(tapInputDownTime - Time.time);

                    if (tapDuration < 0.2f)
                    {
                        //OnTapInput.Invoke();
                        Debug.Log("Tap " + tapDuration);
                    }
                    tapDuration = 0;
                    break;
                default:
                    break;
            }
        }
        #endif
    }*/


    public void SwitchState(CharacterStates nextState)
    {
        currentState = nextState;
        currentState.EnterState(this);
    }
}
