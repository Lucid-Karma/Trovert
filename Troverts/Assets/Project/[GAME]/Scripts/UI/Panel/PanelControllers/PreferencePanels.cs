using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreferencePanels : Panel
{
    public Panel CharacterModePanel;
    public Panel LevelModePanel;

    public Panel IntrovertPanel;
    public Panel ExtrovertPanel;

    public Panel CountdownPanel;


    private void Awake() 
    {
        LevelModePanel.HidePanel();
        IntrovertPanel.HidePanel();
        ExtrovertPanel.HidePanel();
        CountdownPanel.HidePanel();
    }

    private void OnEnable()
    {
        EventManager.OnCharacterChoose.AddListener(InitializeLevelModePanel);
        EventManager.OnExtrovertLevelStart.AddListener(InitializeExtrovertPanel);
        EventManager.OnIntrovertLevelStart.AddListener(InitializeIntrovertPanel);
    }

    private void OnDisable()
    {
        EventManager.OnCharacterChoose.RemoveListener(InitializeLevelModePanel);
        EventManager.OnExtrovertLevelStart.RemoveListener(InitializeExtrovertPanel);
        EventManager.OnIntrovertLevelStart.RemoveListener(InitializeIntrovertPanel);
    }

    private void InitializeLevelModePanel()
    {
        CharacterModePanel.HidePanel();
        LevelModePanel.ShowPanel();
        ShowPanel();
    }

    private void InitializeExtrovertPanel()
    {
        LevelModePanel.HidePanel();
        //IntrovertPanel.HidePanel();
        InitializeCountdownPanel();
        ExtrovertPanel.ShowPanel();
        ShowPanel();
    }

    private void InitializeIntrovertPanel()
    {
        LevelModePanel.HidePanel();
        //ExtrovertPanel.HidePanel();
        InitializeCountdownPanel();
        IntrovertPanel.ShowPanel();
        ShowPanel();
    }

    private void InitializeCountdownPanel()
    {
        CountdownPanel.ShowPanel();
        ShowPanel();
    }
}
