using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimState : ShooterStates
{
    public override void EnterState(CharacterShooterFsm fsm)
    {
        EventManager.OnIntrovertAim.Invoke();
        fsm.gameObject.GetComponentInChildren<SkinnedMeshRenderer>().enabled = false;
    }

    public override void UpdateState(CharacterShooterFsm fsm)
    {
        if (fsm.executingState == ExecutingShooterState.AIM)
        {
            fsm.Aim();
        }
        else   ExitState(fsm);
    }

    public override void ExitState(CharacterShooterFsm fsm)
    {
        EventManager.OnIntrovertEndAim.Invoke();
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
