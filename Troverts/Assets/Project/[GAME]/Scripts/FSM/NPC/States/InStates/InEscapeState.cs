using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InEscapeState : IntrovertNPCStates
{
    public override void EnterState(IntrovertNpcFsm fsm)
    {
        fsm.OnNpcRun.Invoke();
        fsm.Agent.speed = fsm.sprintSpeed + 2.0f;   // 9.0f in total.

        //Debug.Log("ESCAPE");
    }

    public override void UpdateState(IntrovertNpcFsm fsm)
    {
        if(fsm.executingNpcState == ExecutingNpcState.ESCAPE)
            fsm.Escape();
        else
            ExitState(fsm);
    }

    public override void ExitState(IntrovertNpcFsm fsm)
    {
        if(fsm.executingNpcState == ExecutingNpcState.DEAD)
            fsm.SwitchState(fsm.inDeadState);
    }
}
