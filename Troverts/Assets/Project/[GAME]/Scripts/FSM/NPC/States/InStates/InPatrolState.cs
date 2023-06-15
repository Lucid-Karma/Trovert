using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InPatrolState : IntrovertNPCStates
{
    public override void EnterState(IntrovertNpcFsm fsm)
    {
        fsm.OnNpcWalk.Invoke();
        fsm.Agent.stoppingDistance = 0.0f;
        fsm.distanceVec = (fsm.Agent.transform.position - fsm.pcPoint).normalized;
        fsm.escapePoint = fsm.Agent.transform.position + fsm.distanceVec;
        fsm.Agent.SetDestination(fsm.escapePoint);
        fsm.Agent.speed = 5.0f;
    }

    public override void UpdateState(IntrovertNpcFsm fsm)
    {
        if(fsm.executingNpcState == ExecutingNpcState.PATROL)
            fsm.Patrol();
        else
            ExitState(fsm);
    }

    public override void ExitState(IntrovertNpcFsm fsm)
    {
        if(fsm.executingNpcState == ExecutingNpcState.CHASE)
            fsm.SwitchState(fsm.chaseState);
        else if(fsm.executingNpcState == ExecutingNpcState.DEAD)    //???????????
            fsm.SwitchState(fsm.inDeadState);
        else if(fsm.executingNpcState == ExecutingNpcState.SHOCK)    //???????????
            fsm.SwitchState(fsm.shockState);
    }
}
