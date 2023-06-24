using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIHider : MonoBehaviour
{
    public GameObject UIHiderPanel;

    void Awake()
    {
        UIHiderPanel.SetActive(false);
    }

    void OnEnable()
    {
        EventManager.OnUIHide.AddListener(InitializeHider);
        EventManager.OnUIShow.AddListener(HideHider);
    }
    void OnDisable()
    {
        EventManager.OnUIHide.RemoveListener(InitializeHider);
        EventManager.OnUIShow.RemoveListener(HideHider);
    }

    private void InitializeHider()
    {
        UIHiderPanel.SetActive(true);
    }
    void HideHider()
    {
        UIHiderPanel.SetActive(false);
    }
}
