using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolState : NPCStates
{
    public override void EnterState(NpcFSM fsm)
    {
        Debug.Log("npc patrol");
        fsm.OnNpcWalk.Invoke();
    }

    public override void UpdateState(NpcFSM fsm)
    {
        if(fsm.executingNpcState == ExecutingNpcState.PATROL)
            fsm.Patrol();
        else
            ExitState(fsm);
    }

    public override void ExitState(NpcFSM fsm)
    {
        if(fsm.executingNpcState == ExecutingNpcState.CHASE)
            fsm.SwitchState(fsm.chaseState);
    }
}
