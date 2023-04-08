using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseState : NPCStates
{
    public override void EnterState(NpcFSM fsm)
    {
        Debug.Log("npc chase");
    }

    public override void UpdateState(NpcFSM fsm)
    {
        
    }

    public override void ExitState(NpcFSM fsm)
    {

    }
}
