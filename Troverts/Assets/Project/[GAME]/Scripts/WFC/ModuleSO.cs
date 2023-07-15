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

    [HideInInspector] public int[] moduleType = new int[4];

    // public ModuleSO()
    // {
    //     moduleType[0] = north;
    //     moduleType[1] = south;
    //     moduleType[2] = east;
    //     moduleType[3] = west;
    // }

    private void OnEnable()
    {
        moduleType[0] = north;
        moduleType[1] = south;
        moduleType[2] = east;
        moduleType[3] = west;
    }

}

