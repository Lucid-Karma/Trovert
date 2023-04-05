using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Introvert : CharacterBase
{
    void OnEnable()
    {
        EventManager.OnExtrovertChoose.AddListener(() => gameObject.SetActive(false));
        EventManager.OnDifficultyChoose.AddListener(SetEnergy);
        EventManager.OnDifficultyChoose.AddListener(() => Debug.Log("what"));
    }
    void OnDisable()
    {
        EventManager.OnExtrovertChoose.RemoveListener(() => gameObject.SetActive(false));
        EventManager.OnDifficultyChoose.RemoveListener(SetEnergy);
        EventManager.OnDifficultyChoose.RemoveListener(() => Debug.Log("what"));
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
                Debug.Log("medium introvert");
                break;
            case 2: // Hard
                Energy = 50;
                break;
            default:
                Energy = 100;
                break;
        }

        Debug.Log("suspicius");
    }

    public override void ManageEnergy(int damage)
    {
        Energy -= damage;

        if(Energy <= 0)
            base.ManageEnergy(damage);
    }
}
