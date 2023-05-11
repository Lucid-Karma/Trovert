using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimState : ShooterStates
{
    public override void EnterState(CharacterShooterFsm fsm)
    {
        
    }

    public override void UpdateState(CharacterShooterFsm fsm)
    {
        if (fsm.executingState == ExecutingShooterState.AIM)
        {
            
        }
        else   ExitState(fsm);
    }

    public override void ExitState(CharacterShooterFsm fsm)
    {
        if(fsm.executingState == ExecutingShooterState.SHOOT)
        {
            fsm.SwitchState(fsm.shootState);
        }
        else if(fsm.executingState == ExecutingShooterState.EASE)
        {
            fsm.SwitchState(fsm.easeState);
        }
    }
}
