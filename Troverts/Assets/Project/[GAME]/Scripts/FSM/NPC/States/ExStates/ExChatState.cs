using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExChatState : ExtrovertNPCStates
{
    public override void EnterState(ExtrovertNpcFsm fsm)
    {
        //Debug.Log("npc chat");
        fsm.OnNpcIdle.Invoke();
        fsm.hasMet = true;
        FsmManager.Instance.IsCharacterCommunicating = true;
        // EventManager.OnIntrovertCaught.Invoke();
    }

    public override void UpdateState(ExtrovertNpcFsm fsm)
    {
        if(fsm.executingNpcState == ExecutingNpcState.CHAT)
            fsm.StartCoroutine(fsm.Chat());
        else
            ExitState(fsm);
    }

    public override void ExitState(ExtrovertNpcFsm fsm)
    {
        if(fsm.executingNpcState == ExecutingNpcState.PATROL)
            fsm.SwitchState(fsm.exPatrolState);
    }
}
