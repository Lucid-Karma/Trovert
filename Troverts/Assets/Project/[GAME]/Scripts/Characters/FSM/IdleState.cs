using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : CharacterStates
{
    public override void EnterState(CharacterFSM fsm)
    {
        //Debug.Log("IDLE");

        fsm.OnCharacterIdle.Invoke();
    }

    public override void UpdateState(CharacterFSM fsm)
    {
        if (fsm.executingState == ExecutingState.IDLE)
        {
            fsm.LookAround();
        }
        else   ExitState(fsm);
    }

    public override void ExitState(CharacterFSM fsm)
    {
        if(fsm.executingState == ExecutingState.WALK)
        {
            fsm.SwitchState(fsm.walkState);
        }
    }
}
