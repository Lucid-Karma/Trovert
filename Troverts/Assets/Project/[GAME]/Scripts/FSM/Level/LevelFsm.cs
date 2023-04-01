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
    LevelData levelData;
    public LevelMode levelMode;
    public LevelStates currentState;

    public IntrovertState introvertState = new IntrovertState();
    //public ExtrovertState extrovertState = new ExtrovertState();

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
        if (levelData.CharacterMode == "INTROVERT")
        {
            levelMode = LevelMode.INTROVERT;
            currentState = introvertState;
            currentState.EnterState(this);
        }
        // else if(levelData.CharacterMode == "EXTROVERT")
        // {
        //     levelMode = LevelMode.EXTROVERT;
        //     currentState = extrovertState;
        //     currentState.EnterState(this);
        // }
    }

    // public void SwitchState(LevelStates nextState)
    // {
    //     currentState = nextState;
    //     currentState.EnterState(this);
    // }
}
