using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkState : CharacterStates
{
    public override void EnterState(CharacterFSM fsm)
    {
        Debug.Log("WALK");

        fsm.OnCharacterWalk.Invoke();
    }

    public override void UpdateState(CharacterFSM fsm)
    {
        if (fsm.executingState == ExecutingState.WALK)
        {
            //fsm.currentSpeed = fsm.walkSpeed;

            fsm.Rotate();
            //fsm.Move();
        }
        else   ExitState(fsm);
    }

    public override void ExitState(CharacterFSM fsm)
    {
        // if(fsm.executingState == ExecutingState.SPRINT)
        // {
        //     fsm.SwitchState(fsm.sprintState);
        // }
        // else if(fsm.executingState == ExecutingState.CROUCHEDWALK)
        // {
        //     fsm.SwitchState(fsm.crouchedWalkState);
        // }
        if(fsm.executingState == ExecutingState.IDLE)
        {
            fsm.SwitchState(fsm.idleState);
        }
        // else if(fsm.executingState == ExecutingState.DANCE)
        // {
        //     fsm.SwitchState(fsm.danceState);
        // }
        // else if(fsm.executingState == ExecutingState.DEATH)
        // {
        //     fsm.SwitchState(fsm.deathState);
        // }
    }
}
