using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIGenerator : MonoBehaviour
{
    [SerializeField]
    private GameObject IntrovertUI, ExtrovertUI;

    void OnEnable()
    {
        EventManager.OnIntrovertChoose.AddListener(GenerateIntrovertUI);
        EventManager.OnExtrovertChoose.AddListener(GenerateExtrovertUI);
    }
    void OnDisable()
    {
        EventManager.OnIntrovertChoose.RemoveListener(GenerateIntrovertUI);
        EventManager.OnExtrovertChoose.RemoveListener(GenerateExtrovertUI);
    }

    private void GenerateIntrovertUI()  // Does playerPrefs check really needed?
    {
        string selectedCharacter = PlayerPrefs.GetString("selected_character");

        if(selectedCharacter == "introvert")
        {
            ExtrovertUI.SetActive(false);
        }
    }

    private void GenerateExtrovertUI()
    {
        string selectedCharacter = PlayerPrefs.GetString("selected_character");

        if(selectedCharacter == "extrovert")
        {
            IntrovertUI.SetActive(false);
        }
    }
}
