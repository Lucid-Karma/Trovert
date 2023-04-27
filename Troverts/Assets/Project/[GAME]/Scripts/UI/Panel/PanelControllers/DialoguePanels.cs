using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialoguePanels : Panel
{
    public Panel EChatPanel;
    public Panel EGreetingPanel;

    void Awake()
    {
        EChatPanel.HidePanel();
        EGreetingPanel.HidePanel();
    }

    void OnEnable()
    {
        EventManager.OnNpcGreet.AddListener(InitializeEGreetingPanel);
        EventManager.OnNpcGreetingEnd.AddListener(HideEGreetingPanel);
    }
    void OnDisable()
    {
        EventManager.OnNpcGreet.RemoveListener(InitializeEGreetingPanel);
        EventManager.OnNpcGreetingEnd.RemoveListener(HideEGreetingPanel);
    }

    private void InitializeEChatPanel()
    {
        EChatPanel.ShowPanel();
        ShowPanel();
    }

    private void InitializeEGreetingPanel()
    {
        EGreetingPanel.ShowPanel();
        ShowPanel();
    }
    private void HideEGreetingPanel()
    {
        EGreetingPanel.HidePanel();
    }
}
