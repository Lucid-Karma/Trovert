using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InDeadState : IntrovertNPCStates
{
    public override void EnterState(IntrovertNpcFsm fsm)
    {
        fsm.OnNpcDie.Invoke();
    }

    public override void UpdateState(IntrovertNpcFsm fsm)
    {
        if(fsm.executingNpcState == ExecutingNpcState.DEAD){}
            //fsm.Patrol();
        else
            ExitState(fsm);
    }

    public override void ExitState(IntrovertNpcFsm fsm)
    {
        // if(fsm.executingNpcState == ExecutingNpcState.CHASE)
        //     fsm.SwitchState(fsm.chaseState);
    }
}
