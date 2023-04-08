using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Extrovert : CharacterBase
{
    void OnEnable()
    {
        //EventManager.OnIntrovertChoose.AddListener(() => gameObject.SetActive(false));
        EventManager.OnDifficultyChoose.AddListener(SetEnergy);
    }
    void OnDisable()
    {
        //EventManager.OnIntrovertChoose.RemoveListener(() => gameObject.SetActive(false));
        EventManager.OnDifficultyChoose.RemoveListener(SetEnergy);
    }

    public override void SetEnergy()
    {
        selectedDifficulty = PlayerPrefs.GetInt("selected_difficulty");
        
        switch (selectedDifficulty)
        {
            case 0: // Easy
                Energy = 50;
                break;
            case 1: // Medium
                Energy = 75;
                break;
            case 2: // Hard
                Energy = 100;
                break;
            default:
                Energy = 50;
                break;
        }
    }

    public override void ManageEnergy(int score)
    {
        Score += score;

        if(Score >= Energy) Debug.Log("win");
        //base.ManageEnergy();
    }
}
