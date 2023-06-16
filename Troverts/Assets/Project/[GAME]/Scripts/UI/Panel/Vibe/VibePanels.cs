using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VibePanels : Panel
{
    public Panel HuntPanel;

    void Awake()
    {
        //HuntPanel.HidePanel();
        HuntPanel.gameObject.SetActive(false);
    }

    void OnEnable()
    {
        EventManager.OnNpcShock.AddListener(InitializeHuntPanel);
    }
    void OnDisable()
    {
        EventManager.OnNpcShock.RemoveListener(InitializeHuntPanel);   
    }

    private void InitializeHuntPanel()
    {
        // HuntPanel.ShowPanel();
        // ShowPanel();
        HuntPanel.gameObject.SetActive(true);
    }
}
