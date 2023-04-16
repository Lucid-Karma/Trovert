using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChatState : NPCStates
{
    public override void EnterState(NpcFSM fsm)
    {
        //Debug.Log("npc chat");
        fsm.OnNpcIdle.Invoke();
        fsm.hasMet = true;
        FsmManager.Instance.IsCharacterCommunicating = true;
        // EventManager.OnIntrovertCaught.Invoke();
    }

    public override void UpdateState(NpcFSM fsm)
    {
        if(fsm.executingNpcState == ExecutingNpcState.CHAT)
            fsm.StartCoroutine(fsm.Chat());
        else
            ExitState(fsm);
    }

    public override void ExitState(NpcFSM fsm)
    {
        if(fsm.executingNpcState == ExecutingNpcState.PATROL)
            fsm.SwitchState(fsm.patrolState);
    }
}
