using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IDifficultyButtons : MonoBehaviour
{
    public void Easy()
    {
        PlayerPrefs.SetInt("selected_difficulty", 0);

        EventManager.OnIDifficultyChoose.Invoke();
    }

    public void Medium()
    {
        PlayerPrefs.SetInt("selected_difficulty", 1);

        EventManager.OnIDifficultyChoose.Invoke();
    }

    public void Hard()
    {
        PlayerPrefs.SetInt("selected_difficulty", 2);

        EventManager.OnIDifficultyChoose.Invoke();
    }
}
