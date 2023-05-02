using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExPatrolState : ExtrovertNPCStates
{
    public override void EnterState(ExtrovertNpcFsm fsm)
    {
        //Debug.Log("npc patrol");
        fsm.OnNpcWalk.Invoke();
        fsm.Agent.stoppingDistance = 0.0f;
        fsm.Agent.speed = 3.5f;
    }

    public override void UpdateState(ExtrovertNpcFsm fsm)
    {
        if(fsm.executingNpcState == ExecutingNpcState.PATROL)
            fsm.Patrol();
        else
            ExitState(fsm);
    }

    public override void ExitState(ExtrovertNpcFsm fsm)
    {
        if(fsm.executingNpcState == ExecutingNpcState.ESCAPE)
            fsm.SwitchState(fsm.escapeState);
    }
}
