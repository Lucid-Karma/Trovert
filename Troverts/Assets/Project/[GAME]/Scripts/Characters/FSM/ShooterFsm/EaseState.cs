using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EaseState : ShooterStates
{
    public override void EnterState(CharacterShooterFsm fsm)
    {
        
    }

    public override void UpdateState(CharacterShooterFsm fsm)
    {
        if (fsm.executingState == ExecutingShooterState.EASE)
        {
            
        }
        else   ExitState(fsm);
    }

    public override void ExitState(CharacterShooterFsm fsm)
    {
        if(fsm.executingState == ExecutingShooterState.AIM)
        {
            fsm.SwitchState(fsm.aimState);
        }
    }
}
