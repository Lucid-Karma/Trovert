using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterGenerator : MonoBehaviour
{
    [SerializeField] private GameObject introvert;
    [SerializeField] private GameObject extrovert;

    void Awake()
    {
        introvert.SetActive(true);
        extrovert.SetActive(true);
    }

    void OnEnable()
    {
        EventManager.OnIntrovertLevelStart.AddListener(() => extrovert.SetActive(false));
        EventManager.OnExtrovertLevelStart.AddListener(() => introvert.SetActive(false));
    }
    void OnDisable()
    {
        EventManager.OnIntrovertLevelStart.RemoveListener(() => extrovert.SetActive(false));
        EventManager.OnExtrovertLevelStart.RemoveListener(() => introvert.SetActive(false));
    }
}
