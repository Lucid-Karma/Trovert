using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "WFC/CellSO")]
public class CellSO : ScriptableObject 
{
    public List<ModuleSO> modules = new List<ModuleSO>();
    [HideInInspector] public List<CellSO> neighbors = new List<CellSO>();
    [HideInInspector] public Vector3 cellPos;
    [HideInInspector] public bool isCollapsed = false;
    [HideInInspector] public int definiteState;

    public int Row { get; set; }
    public int Column { get; set; }
}
