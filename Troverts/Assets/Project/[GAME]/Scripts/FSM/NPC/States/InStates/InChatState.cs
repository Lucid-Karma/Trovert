using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InChatState : IntrovertNPCStates
{
    public override void EnterState(IntrovertNpcFsm fsm)
    {
        //Debug.Log("npc chat");
        fsm.OnNpcIdle.Invoke();
        FsmManager.Instance.IsCharacterCommunicating = true;
    }

    public override void UpdateState(IntrovertNpcFsm fsm)
    {
        if(fsm.executingNpcState == ExecutingNpcState.CHAT)
            fsm.Chat(EventManager.OnPointLose);
        else
            ExitState(fsm);
    }

    public override void ExitState(IntrovertNpcFsm fsm)
    {
        if(fsm.executingNpcState == ExecutingNpcState.PATROL)
            fsm.SwitchState(fsm.inPatrolState);
    }
}
