using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtrovertButton : MonoBehaviour
{
    LevelData levelData;
    public void DoExtrovert()
    {
        levelData.CharacterMode = "EXTROVERT";

        EventManager.OnCharacterChoose.Invoke();
        //EventManager.OnExtrovertChoose.Invoke();
        EventManager.OnCursorLock.Invoke();
    }
}
