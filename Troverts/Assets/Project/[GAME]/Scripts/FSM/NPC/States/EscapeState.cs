using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscapeState : NPCStates
{
    public override void EnterState(NpcFSM fsm)
    {
        Debug.Log("npc escape");
        fsm.distance = Vector3.Distance(fsm.Agent.transform.position, fsm.pcPoint);
    }

    public override void UpdateState(NpcFSM fsm)
    {
        if(fsm.executingNpcState == ExecutingNpcState.ESCAPE)
            fsm.Escape(fsm.distance);
        else
            ExitState(fsm);
    }

    public override void ExitState(NpcFSM fsm)
    {
        if(fsm.executingNpcState == ExecutingNpcState.CHAT)
            fsm.SwitchState(fsm.chatState);
        else if(fsm.executingNpcState == ExecutingNpcState.PATROL)
            fsm.SwitchState(fsm.patrolState);
    }
}
