using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayButton : MonoBehaviour
{
    public void PlayIntrovert()
    {
        EventManager.OnLevelStart.Invoke();
        EventManager.OnIntrovertLevelStart.Invoke();
        EventManager.OnCursorLock.Invoke();
    }

    public void PlayExtrovert()
    {
        EventManager.OnLevelStart.Invoke();
        EventManager.OnExtrovertLevelStart.Invoke();
        EventManager.OnCursorLock.Invoke();
    }
}
