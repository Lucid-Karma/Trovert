using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EDifficultyButtons : MonoBehaviour
{
    public void Easy()
    {
        PlayerPrefs.SetInt("selected_difficulty", 3);

        EventManager.OnEDifficultyChoose.Invoke();
    }

    public void Medium()
    {
        PlayerPrefs.SetInt("selected_difficulty", 4);

        EventManager.OnEDifficultyChoose.Invoke();
    }

    public void Hard()
    {
        PlayerPrefs.SetInt("selected_difficulty", 5);

        EventManager.OnEDifficultyChoose.Invoke();
    }
}
