using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseState : IntrovertNPCStates
{
    public override void EnterState(IntrovertNpcFsm fsm)
    {
        //Debug.Log("npc chase");
        fsm.OnNpcRun.Invoke();
        //fsm.Agent.stoppingDistance = 1.5f;
        fsm.Agent.speed = 7.0f;
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
        if(fsm.executingNpcState == ExecutingNpcState.CHAT)
            fsm.SwitchState(fsm.inChatState);
    }
}
