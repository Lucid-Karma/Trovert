using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Extrovert : CharacterBase
{
    void OnEnable()
    {
        //EventManager.OnIntrovertChoose.AddListener(() => gameObject.SetActive(false));
        if(PlayerPrefs.GetString("selected_character") == "extrovert")
            EventManager.OnDifficultyChoose.AddListener(SetEnergy);

        EventManager.OnExtrovertLevelStart.AddListener(ReceiveData);
    }
    void OnDisable()
    {
        //EventManager.OnIntrovertChoose.RemoveListener(() => gameObject.SetActive(false));
        if(PlayerPrefs.GetString("selected_character") == "extrovert")
            EventManager.OnDifficultyChoose.RemoveListener(SetEnergy);
            
        EventManager.OnExtrovertLevelStart.RemoveListener(ReceiveData);
    }

    public override void SetEnergy()
    {
        selectedDifficulty = PlayerPrefs.GetInt("selected_difficulty");
        
        switch (selectedDifficulty)
        {
            case 3: // Easy
                Energy = 1;
                break;
            case 4: // Medium
                Energy = 3;
                break;
            case 5: // Hard
                Energy = 5;
                break;
            // default:
            //     Energy = 50;
            //     break;
        }

        Debug.Log(Energy + " " + this.name);
    }

    public override void ReceiveData()
    {
        EventManager.OnECharacterDataReceive.Invoke();
    }

    public override void ManageEnergy(int score)
    {
        Score += score;

        if(Score >= Energy) Debug.Log("win");
        //base.ManageEnergy();
    }
}
