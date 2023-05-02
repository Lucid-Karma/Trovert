using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIStarter : MonoBehaviour
{
    public void PrintEvent()
    {
        EventManager.OnGameStart.Invoke();
    }
}
