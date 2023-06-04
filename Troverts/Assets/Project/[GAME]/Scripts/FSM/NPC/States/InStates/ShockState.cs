using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShockState : IntrovertNPCStates
{
    public override void EnterState(IntrovertNpcFsm fsm)
    {
        fsm.pcPoint = fsm.pc.position;
        fsm.OnNpcIdle.Invoke();

        Debug.Log("SHOCK");
    }

    public override void UpdateState(IntrovertNpcFsm fsm)
    {
        if(fsm.executingNpcState == ExecutingNpcState.SHOCK)
        {
            fsm.RotateToPC(fsm.pcPoint);
            fsm.StartCoroutine(fsm.DelayEscape());
        }
        else
            ExitState(fsm);
    }

    public override void ExitState(IntrovertNpcFsm fsm)
    {
        if(fsm.executingNpcState == ExecutingNpcState.DEAD)
            fsm.SwitchState(fsm.inDeadState);
        else if(fsm.executingNpcState == ExecutingNpcState.ESCAPE)
            fsm.SwitchState(fsm.inEscapeState);
    }
}
