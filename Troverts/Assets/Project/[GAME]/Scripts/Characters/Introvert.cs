using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Introvert : CharacterBase
{
    void OnEnable()
    {
        if(PlayerPrefs.GetString("selected_character") == "introvert")
            EventManager.OnDifficultyChoose.AddListener(SetEnergy);

        EventManager.OnIntrovertLevelStart.AddListener(ReceiveData);
    }
    void OnDisable()
    {
        if(PlayerPrefs.GetString("selected_character") == "introvert")
            EventManager.OnDifficultyChoose.RemoveListener(SetEnergy);
            
        EventManager.OnIntrovertLevelStart.RemoveListener(ReceiveData);
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
            // default:
            //     Energy = 100;
            //     break;
        }

        Debug.Log(Energy + " " + this.name);
    }

    public override void ReceiveData()
    {
        EventManager.OnICharacterDataReceive.Invoke();
    }

    public override void ManageEnergy(int damage)
    {
        Energy -= damage;

        if(Energy <= 0)
            base.ManageEnergy(damage);
    }
}
