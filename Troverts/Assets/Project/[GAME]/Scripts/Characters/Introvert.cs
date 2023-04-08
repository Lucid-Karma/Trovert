using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Introvert : CharacterBase
{
    void OnEnable()
    {
        EventManager.OnDifficultyChoose.AddListener(SetEnergy);
    }
    void OnDisable()
    {
        EventManager.OnDifficultyChoose.RemoveListener(SetEnergy);
    }

    public override void SetEnergy()
    {
        selectedDifficulty = PlayerPrefs.GetInt("selected_difficulty");
        
        switch (selectedDifficulty)
        {
            case 0: // Easy
                Energy = 100;
                break;
            case 1: // Medium
                Energy = 75;
                break;
            case 2: // Hard
                Energy = 50;
                break;
            default:
                Energy = 100;
                break;
        }
    }

    public override void ManageEnergy(int damage)
    {
        Energy -= damage;

        if(Energy <= 0)
            base.ManageEnergy(damage);
    }
}
