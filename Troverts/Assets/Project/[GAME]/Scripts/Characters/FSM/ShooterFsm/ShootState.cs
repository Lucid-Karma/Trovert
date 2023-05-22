using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootState : ShooterStates
{
    public override void EnterState(CharacterShooterFsm fsm)
    {
        Debug.Log("SHOOT");
        EventManager.OnBulletShoot.Invoke();
    }

    public override void UpdateState(CharacterShooterFsm fsm)
    {
        if (fsm.executingState == ExecutingShooterState.SHOOT)
        {
            fsm.Shoot();
        }
        else   ExitState(fsm);
    }

    public override void ExitState(CharacterShooterFsm fsm)
    {
        if(fsm.executingState == ExecutingShooterState.AIM)
        {
            fsm.SwitchState(fsm.aimState);
        }
        else if(fsm.executingState == ExecutingShooterState.EASE)
        {
            fsm.SwitchState(fsm.easeState);
        }
    }
}
