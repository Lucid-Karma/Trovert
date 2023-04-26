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
        EventManager.OnExtrvrtGreet.AddListener(InitializeEGreetingPanel);
        EventManager.OnExtrvrtGreetingEnd.AddListener(HideEGreetingPanel);
    }
    void OnDisable()
    {
        EventManager.OnExtrvrtGreet.RemoveListener(InitializeEGreetingPanel);
        EventManager.OnExtrvrtGreetingEnd.RemoveListener(HideEGreetingPanel);
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
