using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPanels : Panel
{
    public Panel WelcomePanel;
    public Panel CharacterChoosePanel;
    public Panel TrovertPanel;
    public Panel DifficultyPanel;
    public Panel InformPanel;

    public Panel CountdownPanel;

    private void Awake() 
    {
        TrovertPanel.HidePanel();
        DifficultyPanel.HidePanel();
        InformPanel.HidePanel();
        CountdownPanel.HidePanel();
        CharacterChoosePanel.HidePanel();
        WelcomePanel.ShowPanel();
    }

    private void OnEnable()
    {
        EventManager.OnGameStart.AddListener(InitializeCharacterChoosePanel);
        EventManager.OnCharacterChoose.AddListener(InitializeDifficultyPanel);
        EventManager.OnIDifficultyChoose.AddListener(InitializeInformPanel);
        EventManager.OnEDifficultyChoose.AddListener(InitializeInformPanel);
        EventManager.OnLevelStart.AddListener(InitializeTrovertPanel);
    }

    private void OnDisable()
    {
        EventManager.OnGameStart.RemoveListener(InitializeCharacterChoosePanel);
        EventManager.OnCharacterChoose.RemoveListener(InitializeDifficultyPanel);
        EventManager.OnIDifficultyChoose.RemoveListener(InitializeInformPanel);
        EventManager.OnEDifficultyChoose.RemoveListener(InitializeInformPanel);
        EventManager.OnLevelStart.RemoveListener(InitializeTrovertPanel);
    }

    private void InitializeCharacterChoosePanel()
    {
        WelcomePanel.HidePanel();
        CharacterChoosePanel.ShowPanel();
        ShowPanel();
    }

    private void InitializeDifficultyPanel()
    {
        CharacterChoosePanel.HidePanel();
        DifficultyPanel.ShowPanel();
        ShowPanel();
    }

    private void InitializeTrovertPanel()
    {
        InformPanel.HidePanel();
        InitializeCountdownPanel();
        TrovertPanel.ShowPanel();
        ShowPanel();
    }

    private void InitializeInformPanel()
    {
        DifficultyPanel.HidePanel();
        InformPanel.ShowPanel();
        ShowPanel();
    }

    private void InitializeCountdownPanel()
    {
        CountdownPanel.ShowPanel();
        ShowPanel();
    }
}
