using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkState : CharacterStates
{
    public override void EnterState(CharacterFSM fsm)
    {
        fsm.OnCharacterWalk.Invoke();
        fsm.currentSpeed = 5.0f;
        fsm.ParticleSystem.Stop();
    }

    public override void UpdateState(CharacterFSM fsm)
    {
        if (fsm.executingState == ExecutingState.WALK)
        {
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
        else if (fsm.executingState == ExecutingState.SPRINT)
        {
            fsm.SwitchState(fsm.sprintState);
        }
    }
}
