using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class IntrovertNPCStates 
{
    public abstract void EnterState(IntrovertNpcFsm fsm);
    public abstract void UpdateState(IntrovertNpcFsm fsm);
    public abstract void ExitState(IntrovertNpcFsm fsm);
}
