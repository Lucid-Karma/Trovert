using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EDifficultyButtons : MonoBehaviour
{
    public void Easy()
    {
        PlayerPrefs.SetInt("selected_difficulty", 3);

        EventManager.OnDifficultyChoose.Invoke();
    }

    public void Medium()
    {
        PlayerPrefs.SetInt("selected_difficulty", 4);

        EventManager.OnDifficultyChoose.Invoke();
    }

    public void Hard()
    {
        PlayerPrefs.SetInt("selected_difficulty", 5);

        EventManager.OnDifficultyChoose.Invoke();
    }
}
