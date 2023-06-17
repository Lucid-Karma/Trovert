using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscapeState : ExtrovertNPCStates
{
    public override void EnterState(ExtrovertNpcFsm fsm)
    {
        fsm.OnNpcRun.Invoke();
        fsm.Agent.speed = fsm.sprintSpeed + 2.0f;   // 9.0f in total.
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
