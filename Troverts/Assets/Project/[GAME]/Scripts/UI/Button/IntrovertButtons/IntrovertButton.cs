using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntrovertButton : MonoBehaviour
{
    public void DoIntrovert()
    {
        //LevelData.CharacterMode = "EXTROVERT";
        PlayerPrefs.SetString("selected_character", "introvert");
        
        EventManager.OnIntrovertChoose.Invoke();
        EventManager.OnCharacterChoose.Invoke();
    }
}