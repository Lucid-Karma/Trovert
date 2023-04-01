using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntrovertButton : MonoBehaviour
{
    public void DoIntrovert()
    {
        EventManager.OnCharacterChoose.Invoke();
        //EventManager.OnIntrovertChoose.Invoke();
        EventManager.OnCursorLock.Invoke();
    }
}
