using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtrovertButton : MonoBehaviour
{
    public void DoExtrovert()
    {
        //LevelData.CharacterMode = "EXTROVERT";
        //PlayerPrefs.DeleteAll();
        PlayerPrefs.SetString("selected_character", "extrovert");

        EventManager.OnExtrovertChoose.Invoke();
        EventManager.OnCharacterChoose.Invoke();
    }
}
