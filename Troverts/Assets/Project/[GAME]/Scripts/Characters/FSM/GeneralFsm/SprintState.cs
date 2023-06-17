using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SprintState : CharacterStates
{
    public override void EnterState(CharacterFSM fsm)
    {
        fsm.OnCharacterRun.Invoke();
        fsm.currentSpeed = 10.0f;
        fsm.ParticleSystem.Play();
    }

    public override void UpdateState(CharacterFSM fsm)
    {
        if (fsm.executingState == ExecutingState.SPRINT)
        {
            fsm.LookAround();
            fsm.Move();
        }
        else   ExitState(fsm);
    }

    public override void ExitState(CharacterFSM fsm)
    {
        if(fsm.executingState == ExecutingState.WALK)
        {
            fsm.SwitchState(fsm.walkState);
        }
        else if(fsm.executingState == ExecutingState.IDLE)
        {
            fsm.SwitchState(fsm.idleState);
        }
    }
}
