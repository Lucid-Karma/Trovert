using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InChatState : IntrovertNPCStates
{
    public override void EnterState(IntrovertNpcFsm fsm)
    {
        //Debug.Log("npc chat");
        fsm.OnNpcIdle.Invoke();
        fsm.hasMet = true;
        FsmManager.Instance.IsCharacterCommunicating = true;
        // EventManager.OnIntrovertCaught.Invoke();
    }

    public override void UpdateState(IntrovertNpcFsm fsm)
    {
        if(fsm.executingNpcState == ExecutingNpcState.CHAT)
            fsm.StartCoroutine(fsm.Chat());
        else
            ExitState(fsm);
    }

    public override void ExitState(IntrovertNpcFsm fsm)
    {
        if(fsm.executingNpcState == ExecutingNpcState.PATROL)
            fsm.SwitchState(fsm.inPatrolState);
    }
}
