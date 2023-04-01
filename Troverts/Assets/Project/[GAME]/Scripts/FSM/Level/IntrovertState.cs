using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntrovertState : LevelStates
{
    public override void EnterState(LevelFsm fsm)
    {
        EventManager.OnIntrovertChoose.Invoke();
    }
}
