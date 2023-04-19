using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ExtrovertNPCStates
{
    public abstract void EnterState(ExtrovertNpcFsm fsm);
    public abstract void UpdateState(ExtrovertNpcFsm fsm);
    public abstract void ExitState(ExtrovertNpcFsm fsm);
}
