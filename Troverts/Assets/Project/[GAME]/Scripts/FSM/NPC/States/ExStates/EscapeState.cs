using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscapeState : ExtrovertNPCStates
{
    public override void EnterState(ExtrovertNpcFsm fsm)
    {
        //fsm.Agent.ResetPath();
        //fsm.Agent.SetDestination(fsm.Agent.destination);
        //fsm.Agent.remainingDistance = fsm.Agent.stoppingDistance;

        fsm.pcPoint = fsm.pc.position;
        //fsm.distanceVec = (fsm.Agent.transform.position - fsm.pcPoint).normalized;  //???

        // fsm.escapePoint = fsm.Agent.transform.position + fsm.distanceVec;
        // fsm.Agent.SetDestination(fsm.escapePoint);
        fsm.OnNpcRun.Invoke();
        fsm.Agent.speed = fsm.sprintSpeed;
    }

    public override void UpdateState(ExtrovertNpcFsm fsm)
    {
        if(fsm.executingNpcState == ExecutingNpcState.ESCAPE)
            fsm.Escape();
        else
            ExitState(fsm);
    }

    public override void ExitState(ExtrovertNpcFsm fsm)
    {
        if(fsm.executingNpcState == ExecutingNpcState.CHAT)
            fsm.SwitchState(fsm.exChatState);
        else if(fsm.executingNpcState == ExecutingNpcState.PATROL)
            fsm.SwitchState(fsm.exPatrolState);
    }
}
