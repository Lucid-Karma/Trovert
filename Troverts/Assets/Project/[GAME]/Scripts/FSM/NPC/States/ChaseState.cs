using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseState : NPCStates
{
    public override void EnterState(NpcFSM fsm)
    {
        Debug.Log("npc chase");
        fsm.OnNpcWalk.Invoke();
    }

    public override void UpdateState(NpcFSM fsm)
    {
        if(fsm.executingNpcState == ExecutingNpcState.CHASE)
            fsm.Chase();
        else
            ExitState(fsm);
    }

    public override void ExitState(NpcFSM fsm)
    {
        if(fsm.executingNpcState == ExecutingNpcState.PATROL)
            fsm.SwitchState(fsm.patrolState);
        else if(fsm.executingNpcState == ExecutingNpcState.CHAT)
            fsm.SwitchState(fsm.chatState);
    }
}
