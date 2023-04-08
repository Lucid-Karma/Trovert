using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolState : NPCStates
{
    public override void EnterState(NpcFSM fsm)
    {
        Debug.Log("npc patrol");
    }

    public override void UpdateState(NpcFSM fsm)
    {
        
    }

    public override void ExitState(NpcFSM fsm)
    {

    }
}
