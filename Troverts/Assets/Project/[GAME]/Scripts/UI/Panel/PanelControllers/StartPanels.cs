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

    public Panel MainPowerUpPanel;
    public Panel SecondaryPowerUpPanel;

    private void Awake() 
    {
        TrovertPanel.HidePanel();
        DifficultyPanel.HidePanel();
        InformPanel.HidePanel();
        CountdownPanel.HidePanel();
        CharacterChoosePanel.HidePanel();
        MainPowerUpPanel.HidePanel();
        SecondaryPowerUpPanel.HidePanel();
        WelcomePanel.ShowPanel();
    }

    private void OnEnable()
    {
        EventManager.OnGamePreStart.AddListener(InitializeCharacterChoosePanel);
        EventManager.OnGameStart.AddListener(HideWelcomePanel);
        EventManager.OnLevelFail.AddListener(HideOnRestart);
        EventManager.OnLevelSuccess.AddListener(HideOnRestart);
        EventManager.OnCharacterChoose.AddListener(InitializeDifficultyPanel);
        EventManager.OnIDifficultyChoose.AddListener(InitializeInformPanel);
        EventManager.OnEDifficultyChoose.AddListener(InitializeInformPanel);
        EventManager.OnLevelStart.AddListener(InitializeTrovertPanel);
        EventManager.OnIntrovertFirstPowerUp.AddListener(InitializeMainPowerUpPanel);
        EventManager.OnIntrovertSecondPowerUp.AddListener(InitializeSecondaryPowerUpPanel);
    }

    private void OnDisable()
    {
        EventManager.OnGamePreStart.RemoveListener(InitializeCharacterChoosePanel);
        EventManager.OnGameStart.RemoveListener(HideWelcomePanel);
        EventManager.OnLevelFail.RemoveListener(HideOnRestart);
        EventManager.OnLevelSuccess.RemoveListener(HideOnRestart);
        EventManager.OnCharacterChoose.RemoveListener(InitializeDifficultyPanel);
        EventManager.OnIDifficultyChoose.RemoveListener(InitializeInformPanel);
        EventManager.OnEDifficultyChoose.RemoveListener(InitializeInformPanel);
        EventManager.OnLevelStart.RemoveListener(InitializeTrovertPanel);
        EventManager.OnIntrovertFirstPowerUp.RemoveListener(InitializeMainPowerUpPanel);
        EventManager.OnIntrovertSecondPowerUp.RemoveListener(InitializeSecondaryPowerUpPanel);
    }

    private void InitializeCharacterChoosePanel()
    {
        CharacterChoosePanel.ShowPanel();
        ShowPanel();
    }

    private void HideWelcomePanel()
    {
        WelcomePanel.HidePanel();
        HidePanel();
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

    private void InitializeMainPowerUpPanel()
    {
        TrovertPanel.HidePanel();
        MainPowerUpPanel.ShowPanel();
        ShowPanel();

        StartCoroutine(HideMainPowerUpPanel());
    }
    IEnumerator HideMainPowerUpPanel()
    {
        yield return new WaitForSeconds(0.3f);  // kinda 3 secs. because of the time delay -0.1f-

        PcPowerManager.Instance.IsLearning = false;     // ?!?!?!?!?!?!?!
        EventManager.OnCoinVisible.Invoke();

        MainPowerUpPanel.HidePanel();
        TrovertPanel.ShowPanel();
        ShowPanel();
    }

    private void InitializeSecondaryPowerUpPanel()
    {
        TrovertPanel.HidePanel();
        SecondaryPowerUpPanel.ShowPanel();
        ShowPanel();

        StartCoroutine(HideSecondaryPowerUpPanel());
    }
    IEnumerator HideSecondaryPowerUpPanel()
    {
        yield return new WaitForSeconds(0.3f);  // kinda 3 secs. because of the time delay -0.1f-

        PcPowerManager.Instance.IsLearning = false;     // ?!?!?!?!?!?!?!
        EventManager.OnCoinVisible.Invoke();

        SecondaryPowerUpPanel.HidePanel();
        TrovertPanel.ShowPanel();
        ShowPanel();
    }
    

    private void HideOnRestart()
    {
        CountdownPanel.HidePanel();
        TrovertPanel.HidePanel();
        HidePanel();
    }
}
