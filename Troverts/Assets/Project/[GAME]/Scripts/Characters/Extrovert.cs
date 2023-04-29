using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Extrovert : CharacterBase
{
    void OnEnable()
    {
        EventManager.OnEDifficultyChoose.AddListener(SetEnergy);

        EventManager.OnExtrovertLevelStart.AddListener(ReceiveData);

        EventManager.OnPointEarn.AddListener(ManageEnergy);
    }
    void OnDisable()
    {
        EventManager.OnEDifficultyChoose.RemoveListener(SetEnergy);
            
        EventManager.OnExtrovertLevelStart.RemoveListener(ReceiveData);

        EventManager.OnPointEarn.RemoveListener(ManageEnergy);
    }

    public override void SetEnergy()
    {
        selectedDifficulty = PlayerPrefs.GetInt("selected_difficulty");
        
        switch (selectedDifficulty)
        {
            case 3: // Easy
                Energy = 50;
                break;
            case 4: // Medium
                Energy = 70;
                break;
            case 5: // Hard
                Energy = 100;
                break;
            // default:
            //     Energy = 50;
            //     break;
        }

        Debug.Log("extrovert " + selectedDifficulty + " " + Energy);
        Debug.Log(PlayerPrefs.GetString("selected_character") + " " + PlayerPrefs.GetInt("selected_difficulty"));
    }

    public override void ReceiveData()
    {
        EventManager.OnECharacterDataReceive.Invoke();
    }

    public override void ManageEnergy()
    {
        Score += 5;
        EventManager.OnEScoreTxtUpdate.Invoke();

        if(Score >= Energy) EventManager.OnLevelSuccess.Invoke();
        //base.ManageEnergy();
    }
}
