using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscapeState : ExtrovertNPCStates
{
    public override void EnterState(ExtrovertNpcFsm fsm)
    {
        Debug.Log("npc escape");
        fsm.distance = Vector3.Distance(fsm.Agent.transform.position, fsm.pcPoint);
    }

    public override void UpdateState(ExtrovertNpcFsm fsm)
    {
        if(fsm.executingNpcState == ExecutingNpcState.ESCAPE)
            fsm.Escape(fsm.distance);
        else
            ExitState(fsm);
    }

    public override void ExitState(ExtrovertNpcFsm fsm)
    {
        if(fsm.executingNpcState == ExecutingNpcState.CHAT)
            fsm.SwitchState(fsm.exChatState);
    }
}
