using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Introvert : CharacterBase
{
    public override void OnEnable()
    {
        base.OnEnable();

        EventManager.OnIDifficultyChoose.AddListener(SetEnergy);

        EventManager.OnIntrovertLevelStart.AddListener(ReceiveData);

        EventManager.OnPointLose.AddListener(ManageEnergy);
    }
    public override void OnDisable()
    {
        base.OnDisable();

        EventManager.OnIDifficultyChoose.RemoveListener(SetEnergy);
            
        EventManager.OnIntrovertLevelStart.RemoveListener(ReceiveData);

        EventManager.OnPointLose.RemoveListener(ManageEnergy);
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

        // Debug.Log("introvert " + selectedDifficulty + " " + Energy);
        // Debug.Log(PlayerPrefs.GetString("selected_character") + " " + PlayerPrefs.GetInt("selected_difficulty"));
    }

    public override void ReceiveData()
    {
        EventManager.OnICharacterDataReceive.Invoke();
    }

    public override void ManageEnergy()
    {
        Energy -= 5;
        EventManager.OnIScoreTxtUpdate.Invoke();

        if(Energy <= 0)
            base.ManageEnergy();
    }
}
