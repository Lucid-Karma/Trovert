using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitState : CharacterStates
{
    public override void EnterState(CharacterFSM fsm)
    {
        fsm.OnCharacterIdle.Invoke();
        Debug.Log("WAIT");
    }

    public override void UpdateState(CharacterFSM fsm)
    {
        if (fsm.executingState == ExecutingState.WAIT)
        {
            Debug.Log("waiting.....");
        }
        else   ExitState(fsm);
    }

    public override void ExitState(CharacterFSM fsm)
    {
        Debug.Log("OUT");
        if(fsm.executingState == ExecutingState.IDLE)
        {
            fsm.SwitchState(fsm.idleState);
        }
    }
}
