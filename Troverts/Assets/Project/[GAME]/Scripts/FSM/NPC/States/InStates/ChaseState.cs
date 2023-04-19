using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseState : IntrovertNPCStates
{
    public override void EnterState(IntrovertNpcFsm fsm)
    {
        //Debug.Log("npc chase");
        fsm.OnNpcWalk.Invoke();
        fsm.Agent.stoppingDistance = 1.5f;
    }

    public override void UpdateState(IntrovertNpcFsm fsm)
    {
        if(fsm.executingNpcState == ExecutingNpcState.CHASE)
            fsm.Chase();
        else
            ExitState(fsm);
    }

    public override void ExitState(IntrovertNpcFsm fsm)
    {
        if(fsm.executingNpcState == ExecutingNpcState.PATROL)
            fsm.SwitchState(fsm.inPatrolState);
        else if(fsm.executingNpcState == ExecutingNpcState.CHAT)
            fsm.SwitchState(fsm.inChatState);
    }
}
