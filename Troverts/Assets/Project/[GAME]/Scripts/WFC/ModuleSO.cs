using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "WFC/ModuleSO")]
public class ModuleSO : ScriptableObject 
{
    public GameObject modulePrefab;
    [Space]
    public int north;
    public int south;
    public int east;
    public int west;

    [HideInInspector] public int moduleUsageCount = 0;

    [HideInInspector] public List<int> moduleType = new List<int>();

    private void OnEnable()
    {
        moduleType.Add(north);
        moduleType.Add(south);
        moduleType.Add(east);
        moduleType.Add(west);
    }
}

