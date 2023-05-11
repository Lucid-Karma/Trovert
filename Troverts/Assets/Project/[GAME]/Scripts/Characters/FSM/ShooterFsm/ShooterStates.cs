using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ShooterStates 
{
    public abstract void EnterState(CharacterShooterFsm fsm);
    public abstract void UpdateState(CharacterShooterFsm fsm);
    public abstract void ExitState(CharacterShooterFsm fsm);
}
