using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExChatState : ExtrovertNPCStates
{
    public override void EnterState(ExtrovertNpcFsm fsm)
    {
        fsm.pcPoint = fsm.pc.position;
        fsm.OnNpcIdle.Invoke();
        FsmManager.Instance.IsCharacterCommunicating = true;
        fsm.IsNpcMet = true;
        EventManager.OnPreGreet.Invoke();
        EventManager.OnNpcGreet.Invoke();
    }

    public override void UpdateState(ExtrovertNpcFsm fsm)
    {
        if(fsm.executingNpcState == ExecutingNpcState.CHAT)
        {
            fsm.RotateToPC(fsm.pcPoint);
            fsm.Chat(EventManager.OnPointEarn);
        }
        else
            ExitState(fsm);
    }

    public override void ExitState(ExtrovertNpcFsm fsm)
    {
        FsmManager.Instance.IsCharacterCommunicating = false;
        fsm.ChangeColor();
        
        if(fsm.executingNpcState == ExecutingNpcState.PATROL)
            fsm.SwitchState(fsm.exPatrolState);
    }
}
