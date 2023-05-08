using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : CharacterStates
{
    public override void EnterState(CharacterFSM fsm)
    {
        Debug.Log("YEPPP");
        if (PlayerPrefs.GetString("selected_character") == "introvert")
        {
            if(FsmManager.Instance.IsCharacterCommunicating)
                EventManager.OnIntrovertCaught.Invoke();
            else
                fsm.OnCharacterIdle.Invoke();
        }
        else if(PlayerPrefs.GetString("selected_character") == "extrovert")
        {
            fsm.OnCharacterIdle.Invoke();
        } 
    }

    public override void UpdateState(CharacterFSM fsm)
    {
        if (fsm.executingState == ExecutingState.IDLE)
        {
            fsm.LookAround();
        }
        else   ExitState(fsm);
    }

    public override void ExitState(CharacterFSM fsm)
    {
        if(fsm.executingState == ExecutingState.WALK)
        {
            fsm.SwitchState(fsm.walkState);
        }
    }
}
