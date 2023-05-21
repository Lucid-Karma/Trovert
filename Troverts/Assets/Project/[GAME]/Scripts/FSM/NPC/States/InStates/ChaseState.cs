using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseState : IntrovertNPCStates
{
    public override void EnterState(IntrovertNpcFsm fsm)
    {
        fsm.OnNpcRun.Invoke();
        
    }

    public override void UpdateState(IntrovertNpcFsm fsm)
    {
        if(fsm.executingNpcState == ExecutingNpcState.CHASE)
        {
            fsm.Agent.speed = fsm.sprintSpeed;
            fsm.Chase();
        }
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
