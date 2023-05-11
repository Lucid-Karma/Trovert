using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CharacterStates 
{
    public abstract void EnterState(CharacterFSM fsm);
    public abstract void UpdateState(CharacterFSM fsm);
    public abstract void ExitState(CharacterFSM fsm);
}
