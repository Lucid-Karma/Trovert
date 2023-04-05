using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum LevelMode
{
    INTROVERT,
    EXTROVERT
}
public class LevelFsm : MonoBehaviour
{
    public LevelMode levelMode;
    public LevelStates currentState;

    public IntrovertState introvertState = new IntrovertState();
    public ExtrovertState extrovertState = new ExtrovertState();

    void OnEnable()
    {
        EventManager.OnCharacterChoose.AddListener(SetState);
    }
    void OnDisable()
    {
        EventManager.OnCharacterChoose.RemoveListener(SetState);
    }

    private void SetState()
    {
        string selectedCharacter = PlayerPrefs.GetString("selected_character");

        if (selectedCharacter == "introvert")
        {
            levelMode = LevelMode.INTROVERT;
            currentState = introvertState;
            currentState.EnterState(this);
        }
        else if(selectedCharacter == "extrovert")
        {
            levelMode = LevelMode.EXTROVERT;
            currentState = extrovertState;
            currentState.EnterState(this);
        }
    }

    // public void SwitchState(LevelStates nextState)
    // {
    //     currentState = nextState;
    //     currentState.EnterState(this);
    // }
}
