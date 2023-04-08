using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class NPCStates 
{
    public abstract void EnterState(NpcFSM fsm);
    public abstract void UpdateState(NpcFSM fsm);
    public abstract void ExitState(NpcFSM fsm);
}
