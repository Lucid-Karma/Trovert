using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FsmManager : Singleton<FsmManager>
{
    private bool isCharacterCommunicating;

    [HideInInspector]
    public bool IsCharacterCommunicating { get { return isCharacterCommunicating; } set { isCharacterCommunicating = value; } }

}
