using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscapeState : ExtrovertNPCStates
{
    public override void EnterState(ExtrovertNpcFsm fsm)
    {
        fsm.pcPoint = fsm.pc.position;
        fsm.distanceVec = (fsm.Agent.transform.position - fsm.pcPoint).normalized;
        fsm.OnNpcRun.Invoke();
        fsm.Agent.speed = 7.0f;
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
