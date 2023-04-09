using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkState : CharacterStates
{
    public override void EnterState(CharacterFSM fsm)
    {
        //Debug.Log("WALK");

        fsm.OnCharacterWalk.Invoke();
    }

    public override void UpdateState(CharacterFSM fsm)
    {
        if (fsm.executingState == ExecutingState.WALK)
        {
            //fsm.currentSpeed = fsm.walkSpeed;

            fsm.LookAround();
            fsm.Move();
        }
        else   ExitState(fsm);
    }

    public override void ExitState(CharacterFSM fsm)
    {
        if(fsm.executingState == ExecutingState.IDLE)
        {
            fsm.SwitchState(fsm.idleState);
        }
    }
}
