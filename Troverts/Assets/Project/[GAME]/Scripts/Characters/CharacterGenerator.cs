using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterGenerator : MonoBehaviour
{
    [SerializeField] private GameObject introvert;
    [SerializeField] private GameObject extrovert;

    void Awake()
    {
        introvert.SetActive(false);
        extrovert.SetActive(false);
    }

    void OnEnable()
    {
        EventManager.OnIntrovertLevelStart.AddListener(() => introvert.SetActive(true));
        EventManager.OnExtrovertLevelStart.AddListener(() => extrovert.SetActive(true));
    }
    void OnDisable()
    {
        EventManager.OnIntrovertLevelStart.RemoveListener(() => introvert.SetActive(true));
        EventManager.OnExtrovertLevelStart.RemoveListener(() => extrovert.SetActive(true));
    }
}
