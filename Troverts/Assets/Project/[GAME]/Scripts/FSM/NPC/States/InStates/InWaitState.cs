using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InWaitState : IntrovertNPCStates
{
    public override void EnterState(IntrovertNpcFsm fsm)
    {
        fsm.OnNpcIdle.Invoke();
    }

    public override void UpdateState(IntrovertNpcFsm fsm)
    {
        if(fsm.executingNpcState == ExecutingNpcState.WAIT)
        {
            fsm.Agent.SetDestination(fsm.transform.position);
        }
        else
            ExitState(fsm);
    }

    public override void ExitState(IntrovertNpcFsm fsm)
    {
        if(fsm.executingNpcState == ExecutingNpcState.CHASE)
            fsm.SwitchState(fsm.chaseState);
    }
}
