using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPanels : Panel
{
    public Panel IntrovertPanel;
    public Panel ExtrovertPanel;
    public Panel ChoosePanel;

    public Panel CountdownPanel;

    private void Awake() 
    {
        IntrovertPanel.HidePanel();
        ExtrovertPanel.HidePanel();
        CountdownPanel.HidePanel();
        //ChoosePanel.HidePanel();
    }

    private void OnEnable()
    {
        EventManager.OnExtrovertLevelStart.AddListener(InitializeExtrovertPanel);
        EventManager.OnIntrovertLevelStart.AddListener(InitializeIntrovertPanel);
        //EventManager.OnGameStart.AddListener(InitializeChoosePanel);
    }

    private void OnDisable()
    {
        EventManager.OnExtrovertLevelStart.RemoveListener(InitializeExtrovertPanel);
        EventManager.OnIntrovertLevelStart.RemoveListener(InitializeIntrovertPanel);
        //EventManager.OnGameStart.RemoveListener(InitializeChoosePanel);
    }

    private void InitializeExtrovertPanel()
    {
        ChoosePanel.HidePanel();
        IntrovertPanel.HidePanel();
        InitializeCountdownPanel();
        ExtrovertPanel.ShowPanel();
        ShowPanel();
    }

    private void InitializeIntrovertPanel()
    {
        ChoosePanel.HidePanel();
        ExtrovertPanel.HidePanel();
        InitializeCountdownPanel();
        IntrovertPanel.ShowPanel();
        ShowPanel();
    }

    private void InitializeChoosePanel()
    {
        ChoosePanel.ShowPanel();
        ShowPanel();
    }

    private void InitializeCountdownPanel()
    {
        CountdownPanel.ShowPanel();
        ShowPanel();
    }
}
