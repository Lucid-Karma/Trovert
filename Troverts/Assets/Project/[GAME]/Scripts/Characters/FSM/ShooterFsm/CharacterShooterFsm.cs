using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ExecutingShooterState
{
    AIM,
    SHOOT,
    EASE
}
public class CharacterShooterFsm : MonoBehaviour
{
    private Camera camera;

    public ExecutingShooterState executingState;
    public ShooterStates currentState;
    public AimState aimState = new AimState();
    public ShootState shootState = new ShootState();
    public EaseState easeState = new EaseState();


    void Start()
    {
        camera = Camera.main;

        executingState =  ExecutingShooterState.EASE;
        currentState = easeState;
        currentState.EnterState(this);
    }

    void Update()
    {
        currentState.UpdateState(this);
    }

    public void Ease()
    {
        if(Input.GetKey(KeyCode.E))
        {
            executingState =  ExecutingShooterState.AIM;
        }
    }

    public void Aim()
    {
        var target = GetTargetObject();

        if(target != null)
        {
            // var interactable = target.GetComponent<IInteractable>();
            var interactable = target.GetComponent<NpcFSM>();
            if(interactable != null)
            {
                interactable?.Meet();
                Debug.Log("NPC !!!");
                // crosshair.color = Color.red;
                // pressEUI.SetActive(true);

                // if (Input.GetKey(KeyCode.F))
                if (Input.GetMouseButtonDown(0))
                {
                    interactable?.Die();
                }
            }   
            // else if(interactable == null)
            // {
            //     crosshair.color = Color.white;
            //     pressEUI.SetActive(false); 
            // }
        }
        // else if(target == null)
        // {
        //     crosshair.color = Color.white;
        //     pressEUI.SetActive(false); 
        // }    
    }
    private GameObject GetTargetObject()
    {
        GameObject result = null;
        // Vector3 fwd = transform.TransformDirection(Vector3.forward);
        Vector3 fwd = camera.transform.TransformDirection(Vector3.forward);
        RaycastHit hit;
        Ray ray = camera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));       //ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(camera.transform.position, fwd, out hit, 100))
        {
            result = hit.transform.gameObject;
        }
        return result;
    }


    public void SwitchState(ShooterStates nextState)
    {
        currentState = nextState;
        currentState.EnterState(this);
    }
}
