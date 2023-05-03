using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIStarter : MonoBehaviour
{
    public void StartLevel()
    {
        EventManager.OnGamePreStart.Invoke();
        EventManager.OnGameStart.Invoke();
        EventManager.OnCameraMove.Invoke();
    }

    public void StartCameraMove()
    {
        EventManager.OnCameraMove.Invoke();
    }

    public void SwitchNextUI()
    {
        EventManager.OnGamePreStart.Invoke();
    }
}
