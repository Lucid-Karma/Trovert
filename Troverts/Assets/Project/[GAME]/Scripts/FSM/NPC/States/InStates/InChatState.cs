using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InChatState : IntrovertNPCStates
{
    public override void EnterState(IntrovertNpcFsm fsm)
    {
        FsmManager.Instance.IsCharacterCommunicating = true;
        fsm.IsNpcMet = true;
        EventManager.OnPreGreet.Invoke();
        EventManager.OnNpcGreet.Invoke();
        fsm.pcPoint = fsm.pc.position;
        fsm.OnNpcIdle.Invoke();
    }

    public override void UpdateState(IntrovertNpcFsm fsm)
    {
        if(fsm.executingNpcState == ExecutingNpcState.CHAT)
        {
            fsm.RotateToPC(fsm.pcPoint);
            fsm.Chat(EventManager.OnPointLose);
        }
        else
            ExitState(fsm);
    }

    public override void ExitState(IntrovertNpcFsm fsm)
    {
        FsmManager.Instance.IsCharacterCommunicating = false;
        fsm.ChangeColor();

        if(fsm.executingNpcState == ExecutingNpcState.PATROL)
            fsm.SwitchState(fsm.inPatrolState);
    }
}
