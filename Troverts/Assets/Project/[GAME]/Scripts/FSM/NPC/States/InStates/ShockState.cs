using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShockState : IntrovertNPCStates
{
    public override void EnterState(IntrovertNpcFsm fsm)
    {
        fsm.StopNpc();
        fsm.pcPoint = fsm.pc.position;
        fsm.OnNpcPanic.Invoke();

        //Debug.Log("SHOCK");
    }

    public override void UpdateState(IntrovertNpcFsm fsm)
    {
        if(fsm.executingNpcState == ExecutingNpcState.SHOCK)
        {
            //fsm.RotateToPC(fsm.pcPoint);
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
